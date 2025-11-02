using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using FinanceTracker.Classes.Database;
using FinanceTracker.Classes.Models;
using FinanceTracker.Classes.Utils;

namespace FinanceTracker.Classes.Repositories
{
    public class TransactionRepository
    {
        public int Create(Transaction t)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(@"
INSERT INTO Transactions(Date, Type, CategoryId, Amount, Comment)
VALUES (@d, @t, @c, @a, @m);
SELECT last_insert_rowid();", conn))
                {
                    cmd.Parameters.AddWithValue("@d", t.Date.ToIsoString());
                    cmd.Parameters.AddWithValue("@t", (int)t.Type);
                    cmd.Parameters.AddWithValue("@c", t.CategoryId);
                    cmd.Parameters.AddWithValue("@a", t.Amount);
                    cmd.Parameters.AddWithValue("@m", string.IsNullOrWhiteSpace(t.Comment) ? (object)DBNull.Value : t.Comment);

                    return Convert.ToInt32((long)cmd.ExecuteScalar());
                }
            }
        }

        public void Update(Transaction t)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(@"
UPDATE Transactions
SET Date=@d, Type=@t, CategoryId=@c, Amount=@a, Comment=@m
WHERE Id=@id;", conn))
                {
                    cmd.Parameters.AddWithValue("@d", t.Date.ToIsoString());
                    cmd.Parameters.AddWithValue("@t", (int)t.Type);
                    cmd.Parameters.AddWithValue("@c", t.CategoryId);
                    cmd.Parameters.AddWithValue("@a", t.Amount);
                    cmd.Parameters.AddWithValue("@m", string.IsNullOrWhiteSpace(t.Comment) ? (object)DBNull.Value : t.Comment);
                    cmd.Parameters.AddWithValue("@id", t.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteMany(IEnumerable<int> ids)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    foreach (var id in ids)
                    {
                        using (var cmd = new SQLiteCommand("DELETE FROM Transactions WHERE Id=@id;", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
            }
        }

        public void ReassignCategory(int oldCategoryId, int newCategoryId)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("UPDATE Transactions SET CategoryId=@newId WHERE CategoryId=@oldId;", conn))
                {
                    cmd.Parameters.AddWithValue("@newId", newCategoryId);
                    cmd.Parameters.AddWithValue("@oldId", oldCategoryId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Transaction> GetRecent(int limit = 50)
        {
            var list = new List<Transaction>();
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(@"
SELECT Id, Date, Type, CategoryId, Amount, Comment
FROM Transactions
ORDER BY datetime(Date) DESC
LIMIT @lim;", conn))
                {
                    cmd.Parameters.AddWithValue("@lim", limit);
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            list.Add(new Transaction
                            {
                                Id = rd.GetInt32(0),
                                Date = DateUtils.FromIsoString(rd.GetString(1)),
                                Type = (TransactionType)rd.GetInt32(2),
                                CategoryId = rd.GetInt32(3),
                                Amount = Convert.ToDecimal(rd.GetDouble(4)),
                                Comment = rd.IsDBNull(5) ? "" : rd.GetString(5)
                            });
                        }
                    }
                }
            }
            return list;
        }

        public List<(Transaction tx, string categoryName)> GetRecentWithCategoryName(int limit = 50)
        {
            var list = new List<(Transaction, string)>();
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(@"
SELECT t.Id, t.Date, t.Type, t.CategoryId, t.Amount, t.Comment, c.Name
FROM Transactions t
JOIN Categories c ON c.Id = t.CategoryId
ORDER BY datetime(t.Date) DESC
LIMIT @lim;", conn))
                {
                    cmd.Parameters.AddWithValue("@lim", limit);
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var tx = new Transaction
                            {
                                Id = rd.GetInt32(0),
                                Date = DateUtils.FromIsoString(rd.GetString(1)),
                                Type = (TransactionType)rd.GetInt32(2),
                                CategoryId = rd.GetInt32(3),
                                Amount = Convert.ToDecimal(rd.GetDouble(4)),
                                Comment = rd.IsDBNull(5) ? "" : rd.GetString(5)
                            };
                            var catName = rd.GetString(6);
                            list.Add((tx, catName));
                        }
                    }
                }
            }
            return list;
        }

        public decimal SumExpensesByCategoriesAndPeriod(IEnumerable<int> categoryIds, DateTime start, DateTime end)
        {
            var idsJoined = string.Join(",", categoryIds);
            if (string.IsNullOrWhiteSpace(idsJoined))
                return 0m;

            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                var sql = @"
SELECT IFNULL(SUM(Amount),0)
FROM Transactions
WHERE Type=0
  AND CategoryId IN (" + idsJoined + @")
  AND datetime(Date) BETWEEN datetime(@s) AND datetime(@e);";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@s", start.ToIsoString());
                    cmd.Parameters.AddWithValue("@e", end.ToIsoString());
                    var result = cmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value) return 0m;
                    return Convert.ToDecimal(result);
                }
            }
        }

        public List<(Transaction tx, string categoryName)> GetForReportWithCategoryName(
            DateTime start, DateTime end,
            int? typeFilter,
            List<int> categoryIdsOrNull,
            decimal? minAmount,
            decimal? maxAmount
        )
        {
            var list = new List<(Transaction, string)>();
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();

                var sql = new StringBuilder(@"
SELECT t.Id, t.Date, t.Type, t.CategoryId, t.Amount, t.Comment, c.Name
FROM Transactions t
JOIN Categories c ON c.Id = t.CategoryId
WHERE datetime(t.Date) BETWEEN datetime(@s) AND datetime(@e)
");

                if (typeFilter != null)
                    sql.Append(" AND t.Type = @type ");

                if (categoryIdsOrNull != null && categoryIdsOrNull.Count > 0)
                    sql.Append(" AND t.CategoryId IN (" + string.Join(",", categoryIdsOrNull) + ") ");

                if (minAmount != null)
                    sql.Append(" AND t.Amount >= @min ");

                if (maxAmount != null)
                    sql.Append(" AND t.Amount <= @max ");

                sql.Append(" ORDER BY datetime(t.Date) ASC; ");

                using (var cmd = new SQLiteCommand(sql.ToString(), conn))
                {
                    cmd.Parameters.AddWithValue("@s", start.ToIsoString());
                    cmd.Parameters.AddWithValue("@e", end.ToIsoString());
                    if (typeFilter != null) cmd.Parameters.AddWithValue("@type", typeFilter.Value);
                    if (minAmount != null) cmd.Parameters.AddWithValue("@min", minAmount.Value);
                    if (maxAmount != null) cmd.Parameters.AddWithValue("@max", maxAmount.Value);

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var tx = new Transaction
                            {
                                Id = rd.GetInt32(0),
                                Date = DateUtils.FromIsoString(rd.GetString(1)),
                                Type = (TransactionType)rd.GetInt32(2),
                                CategoryId = rd.GetInt32(3),
                                Amount = Convert.ToDecimal(rd.GetDouble(4)),
                                Comment = rd.IsDBNull(5) ? "" : rd.GetString(5)
                            };
                            var catName = rd.GetString(6);
                            list.Add((tx, catName));
                        }
                    }
                }
            }
            return list;
        }
    }
}
