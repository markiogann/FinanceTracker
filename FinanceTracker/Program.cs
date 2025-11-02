using System;
using System.Windows.Forms;
using FinanceTracker.Classes.Database;
using FinanceTracker.Forms;

namespace FinanceTracker
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Инициализация БД и таблиц
                DatabaseManager.Initialize();

                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критическая ошибка запуска:\n" + ex.Message,
                    "FinanceTracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
