using System;
using System.Data.SQLite;
using System.IO;

namespace FinanceTracker.Classes.Database
{
    public static class DatabaseManager
    {
        private static readonly object _initLock = new object();
        private static bool _initialized = false;

        private static string _dbFolder;
        private static string _dbPath;
        private const string DbFileName = "finance.db";

        public static string ConnectionString => $"Data Source={_dbPath};Version=3;Foreign Keys=True;";

        public static void Initialize()
        {
            if (_initialized) return;

            lock (_initLock)
            {
                if (_initialized) return;

                _dbFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
                if (!Directory.Exists(_dbFolder))
                    Directory.CreateDirectory(_dbFolder);

                _dbPath = Path.Combine(_dbFolder, DbFileName);

                var newDb = !File.Exists(_dbPath);
                if (newDb)
                {
                    SQLiteConnection.CreateFile(_dbPath);
                }

                using (var conn = GetConnection())
                {
                    conn.Open();
                    EnableForeignKeys(conn);
                    CreateSchemaIfNeeded(conn);
                    EnsureDefaults(conn);
                }

                _initialized = true;
            }
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }

        private static void EnableForeignKeys(SQLiteConnection conn)
        {
            using (var cmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", conn))
                cmd.ExecuteNonQuery();
        }

        private static void CreateSchemaIfNeeded(SQLiteConnection conn)
        {
            var sqlCategories = @"
CREATE TABLE IF NOT EXISTS Categories (
    Id         INTEGER PRIMARY KEY AUTOINCREMENT,
    Name       TEXT    NOT NULL UNIQUE,
    IsDeleted  INTEGER NOT NULL DEFAULT 0
);";

            var sqlTransactions = @"
CREATE TABLE IF NOT EXISTS Transactions (
    Id         INTEGER PRIMARY KEY AUTOINCREMENT,
    Date       TEXT    NOT NULL,
    Type       INTEGER NOT NULL,                -- 0 = Expense, 1 = Income
    CategoryId INTEGER NOT NULL,
    Amount     REAL    NOT NULL,
    Comment    TEXT,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);";

            var sqlBudgets = @"
CREATE TABLE IF NOT EXISTS Budgets (
    Id           INTEGER PRIMARY KEY AUTOINCREMENT,
    Amount       REAL    NOT NULL,
    StartDate    TEXT    NOT NULL,
    EndDate      TEXT    NOT NULL,
    AppliesToAll INTEGER NOT NULL DEFAULT 0
);";

            var sqlBudgetCategories = @"
CREATE TABLE IF NOT EXISTS BudgetCategories (
    BudgetId   INTEGER NOT NULL,
    CategoryId INTEGER NOT NULL,
    PRIMARY KEY (BudgetId, CategoryId),
    FOREIGN KEY (BudgetId)  REFERENCES Budgets(Id),
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);";

            using (var tx = conn.BeginTransaction())
            {
                using (var cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = sqlCategories; cmd.ExecuteNonQuery();
                    cmd.CommandText = sqlTransactions; cmd.ExecuteNonQuery();
                    cmd.CommandText = sqlBudgets; cmd.ExecuteNonQuery();
                    cmd.CommandText = sqlBudgetCategories; cmd.ExecuteNonQuery();
                }
                tx.Commit();
            }

            using (var cmd = new SQLiteCommand(@"
CREATE INDEX IF NOT EXISTS idx_transactions_date ON Transactions(Date);
CREATE INDEX IF NOT EXISTS idx_transactions_category ON Transactions(CategoryId);
", conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private static void EnsureDefaults(SQLiteConnection conn)
        {
            using (var cmd = new SQLiteCommand("SELECT Id FROM Categories WHERE Name = @name LIMIT 1;", conn))
            {
                cmd.Parameters.AddWithValue("@name", "Прочее");
                var exists = cmd.ExecuteScalar();
                if (exists == null || exists == DBNull.Value)
                {
                    using (var cmdIns = new SQLiteCommand("INSERT INTO Categories(Name, IsDeleted) VALUES(@n, 0);", conn))
                    {
                        cmdIns.Parameters.AddWithValue("@n", "Прочее");
                        cmdIns.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
