using System;
using System.Collections.Generic;
using System.Data.SQLite;
using FinanceTracker.Classes.Database;
using FinanceTracker.Classes.Models;

namespace FinanceTracker.Classes.Repositories
{
    public class CategoryRepository
    {
        private const string FallbackCategoryName = "Прочее";

        // ==== ПУБЛИЧНЫЕ МЕТОДЫ ====

        public List<Category> GetAll(bool includeDeleted)
        {
            var list = new List<Category>();
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();

                // Если soft-delete не используется — логика одинаковая
                const string sql = "SELECT Id, Name FROM Categories ORDER BY Name ASC;";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new Category
                        {
                            Id = rd.GetInt32(0),
                            Name = rd.GetString(1)
                        });
                    }
                }
            }
            return list;
        }

        public Category GetById(int id)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT Id, Name FROM Categories WHERE Id=@id;", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            return new Category
                            {
                                Id = rd.GetInt32(0),
                                Name = rd.GetString(1)
                            };
                        }
                    }
                }
            }
            return null;
        }

        // ✅ Добавлено: получить категорию по имени (без учёта регистра)
        public Category GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;

            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "SELECT Id, Name FROM Categories WHERE LOWER(Name)=LOWER(@n) LIMIT 1;", conn))
                {
                    cmd.Parameters.AddWithValue("@n", name.Trim());
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            return new Category
                            {
                                Id = rd.GetInt32(0),
                                Name = rd.GetString(1)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool ExistsByName(string name, int? excludeId)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();

                string sql = excludeId == null
                    ? "SELECT COUNT(1) FROM Categories WHERE LOWER(Name)=LOWER(@n);"
                    : "SELECT COUNT(1) FROM Categories WHERE LOWER(Name)=LOWER(@n) AND Id<>@id;";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    if (excludeId != null) cmd.Parameters.AddWithValue("@id", excludeId.Value);

                    var cnt = Convert.ToInt32((long)cmd.ExecuteScalar());
                    return cnt > 0;
                }
            }
        }

        public int Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название категории не может быть пустым.");

            if (ExistsByName(name, null))
                throw new InvalidOperationException("Категория с таким названием уже существует.");

            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "INSERT INTO Categories(Name) VALUES(@n); SELECT last_insert_rowid();", conn))
                {
                    cmd.Parameters.AddWithValue("@n", name.Trim());
                    return Convert.ToInt32((long)cmd.ExecuteScalar());
                }
            }
        }

        public void Update(int id, string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Название категории не может быть пустым.");

            if (ExistsByName(newName, id))
                throw new InvalidOperationException("Категория с таким названием уже существует.");

            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "UPDATE Categories SET Name=@n WHERE Id=@id;", conn))
                {
                    cmd.Parameters.AddWithValue("@n", newName.Trim());
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ✅ Добавлено: совместимая обёртка под сигнатуру из сервиса
        public void UpdateName(int id, string newName)
        {
            Update(id, newName);
        }

        /// <summary>
        /// Массовое удаление категорий с переносом операций в «Прочее».
        /// Если «Прочее» отсутствует — создаём.
        /// </summary>
        public void DeleteMany(IEnumerable<int> ids)
        {
            var idList = ids == null ? new List<int>() : new List<int>(ids);
            if (idList.Count == 0) return;

            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    int fallbackId = EnsureFallbackCategory(conn, tx);

                    foreach (var id in idList)
                    {
                        if (id == fallbackId) continue;

                        using (var cmdRe = new SQLiteCommand(
                            "UPDATE Transactions SET CategoryId=@newId WHERE CategoryId=@oldId;", conn, tx))
                        {
                            cmdRe.Parameters.AddWithValue("@newId", fallbackId);
                            cmdRe.Parameters.AddWithValue("@oldId", id);
                            cmdRe.ExecuteNonQuery();
                        }

                        using (var cmdDel = new SQLiteCommand(
                            "DELETE FROM Categories WHERE Id=@id;", conn, tx))
                        {
                            cmdDel.Parameters.AddWithValue("@id", id);
                            cmdDel.ExecuteNonQuery();
                        }
                    }

                    tx.Commit();
                }
            }
        }

        // ✅ Добавлено: если в проекте ожидался soft-delete — даём безопасный алиас
        public void SoftDeleteMany(IEnumerable<int> ids)
        {
            // Если soft-delete не реализован, выполняем безопасное реальное удаление
            DeleteMany(ids);
        }

        // ✅ Добавлено: получить/создать «Прочее», вернуть его Id (без внешней транзакции)
        public int EnsureDefaultOther()
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    int id = EnsureFallbackCategory(conn, tx);
                    tx.Commit();
                    return id;
                }
            }
        }

        // ==== ПРИВАТНЫЕ ПОМОЩНИКИ ====

        private int EnsureFallbackCategory(SQLiteConnection conn, SQLiteTransaction tx)
        {
            using (var cmdFind = new SQLiteCommand(
                "SELECT Id FROM Categories WHERE LOWER(Name)=LOWER(@n) LIMIT 1;", conn, tx))
            {
                cmdFind.Parameters.AddWithValue("@n", FallbackCategoryName);
                var obj = cmdFind.ExecuteScalar();
                if (obj != null && obj != DBNull.Value)
                    return Convert.ToInt32((long)obj);
            }

            using (var cmdIns = new SQLiteCommand(
                "INSERT INTO Categories(Name) VALUES(@n); SELECT last_insert_rowid();", conn, tx))
            {
                cmdIns.Parameters.AddWithValue("@n", FallbackCategoryName);
                return Convert.ToInt32((long)cmdIns.ExecuteScalar());
            }
        }
    }
}
