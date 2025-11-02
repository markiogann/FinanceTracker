using System;
using System.Collections.Generic;
using System.Data.SQLite;
using FinanceTracker.Classes.Database;
using FinanceTracker.Classes.Models;
using FinanceTracker.Classes.Utils;

namespace FinanceTracker.Classes.Repositories
{
    public class BudgetRepository
    {
        private BudgetLimit MapBudget(SQLiteDataReader rd)
        {
            var b = new BudgetLimit();
            b.Id = rd.GetInt32(0);
            b.Amount = Convert.ToDecimal(rd.GetDouble(1));
            b.StartDate = DateUtils.FromIsoString(rd.GetString(2));
            b.EndDate = DateUtils.FromIsoString(rd.GetString(3));
            b.AppliesToAll = rd.GetInt32(4) != 0;
            return b;
        }

        public int Create(BudgetLimit b)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    int id;
                    using (var cmd = new SQLiteCommand(@"
INSERT INTO Budgets(Amount, StartDate, EndDate, AppliesToAll)
VALUES(@a, @s, @e, @all);
SELECT last_insert_rowid();", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@a", b.Amount);
                        cmd.Parameters.AddWithValue("@s", b.StartDate.ToIsoString());
                        cmd.Parameters.AddWithValue("@e", b.EndDate.ToIsoString());
                        cmd.Parameters.AddWithValue("@all", b.AppliesToAll ? 1 : 0);
                        id = Convert.ToInt32((long)cmd.ExecuteScalar());
                    }

                    if (!b.AppliesToAll && b.CategoryIds != null && b.CategoryIds.Count > 0)
                    {
                        foreach (var catId in b.CategoryIds)
                        {
                            using (var cmd = new SQLiteCommand(@"
INSERT INTO BudgetCategories(BudgetId, CategoryId)
VALUES(@b, @c);", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@b", id);
                                cmd.Parameters.AddWithValue("@c", catId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    tx.Commit();
                    return id;
                }
            }
        }

        public void Update(BudgetLimit b)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    using (var cmd = new SQLiteCommand(@"
UPDATE Budgets
SET Amount=@a, StartDate=@s, EndDate=@e, AppliesToAll=@all
WHERE Id=@id;", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@a", b.Amount);
                        cmd.Parameters.AddWithValue("@s", b.StartDate.ToIsoString());
                        cmd.Parameters.AddWithValue("@e", b.EndDate.ToIsoString());
                        cmd.Parameters.AddWithValue("@all", b.AppliesToAll ? 1 : 0);
                        cmd.Parameters.AddWithValue("@id", b.Id);
                        cmd.ExecuteNonQuery();
                    }

                    using (var cmdDel = new SQLiteCommand("DELETE FROM BudgetCategories WHERE BudgetId=@b;", conn, tx))
                    {
                        cmdDel.Parameters.AddWithValue("@b", b.Id);
                        cmdDel.ExecuteNonQuery();
                    }

                    if (!b.AppliesToAll && b.CategoryIds != null && b.CategoryIds.Count > 0)
                    {
                        foreach (var catId in b.CategoryIds)
                        {
                            using (var cmd = new SQLiteCommand(@"
INSERT INTO BudgetCategories(BudgetId, CategoryId)
VALUES(@b, @c);", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@b", b.Id);
                                cmd.Parameters.AddWithValue("@c", catId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    tx.Commit();
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
                        using (var cmd1 = new SQLiteCommand("DELETE FROM BudgetCategories WHERE BudgetId=@b;", conn, tx))
                        {
                            cmd1.Parameters.AddWithValue("@b", id);
                            cmd1.ExecuteNonQuery();
                        }
                        using (var cmd2 = new SQLiteCommand("DELETE FROM Budgets WHERE Id=@b;", conn, tx))
                        {
                            cmd2.Parameters.AddWithValue("@b", id);
                            cmd2.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
            }
        }

        public BudgetLimit GetById(int id)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                BudgetLimit b = null;
                using (var cmd = new SQLiteCommand(@"
SELECT Id, Amount, StartDate, EndDate, AppliesToAll
FROM Budgets
WHERE Id=@id;", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            b = MapBudget(rd);
                        }
                    }
                }
                if (b == null) return null;

                b.CategoryIds = GetBudgetCategoryIds(id, conn);
                return b;
            }
        }

        public List<BudgetLimit> GetAll()
        {
            var list = new List<BudgetLimit>();
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(@"
SELECT Id, Amount, StartDate, EndDate, AppliesToAll
FROM Budgets
ORDER BY datetime(StartDate) DESC;", conn))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var b = MapBudget(rd);
                        list.Add(b);
                    }
                }

                foreach (var b in list)
                    b.CategoryIds = GetBudgetCategoryIds(b.Id, conn);
            }
            return list;
        }

        public List<BudgetLimit> GetActive(DateTime now)
        {
            var list = new List<BudgetLimit>();
            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(@"
SELECT Id, Amount, StartDate, EndDate, AppliesToAll
FROM Budgets
WHERE datetime(StartDate) <= datetime(@now)
  AND datetime(EndDate)   >= datetime(@now)
ORDER BY datetime(EndDate) ASC;", conn))
                {
                    cmd.Parameters.AddWithValue("@now", now.ToIsoString());
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var b = MapBudget(rd);
                            list.Add(b);
                        }
                    }
                }

                foreach (var b in list)
                    b.CategoryIds = GetBudgetCategoryIds(b.Id, conn);
            }
            return list;
        }

        public List<int> GetBudgetCategoryIds(int budgetId, SQLiteConnection conn)
        {
            var ids = new List<int>();
            using (var cmd = new SQLiteCommand("SELECT CategoryId FROM BudgetCategories WHERE BudgetId=@b;", conn))
            {
                cmd.Parameters.AddWithValue("@b", budgetId);
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        ids.Add(rd.GetInt32(0));
                }
            }
            return ids;
        }
    }
}
