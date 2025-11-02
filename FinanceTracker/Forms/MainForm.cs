using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FinanceTracker.Classes.Models;
using FinanceTracker.Classes.Repositories;
using FinanceTracker.Classes.UI;

namespace FinanceTracker.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            try { Theme.Apply(this); } catch { }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTransactionsPreview();
                RefreshActiveLimitsPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка инициализации: " + ex.Message,
                    "FinanceTracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTransactionsPreview()
        {
            var repo = new TransactionRepository();
            var items = repo.GetRecentWithCategoryName(100);

            dgvTransactions.Rows.Clear();
            int no = 1;
            foreach (var pair in items)
            {
                var tx = pair.tx;
                var categoryName = pair.categoryName;

                string typeText = tx.Type == TransactionType.Income ? "Доход" : "Расход";
                int rowIndex = dgvTransactions.Rows.Add(
                    no++,
                    tx.Id,
                    tx.Date.ToString("yyyy-MM-dd HH:mm"),
                    typeText,
                    categoryName,
                    tx.Amount.ToString("0.##"),
                    tx.Comment
                );
                dgvTransactions.Rows[rowIndex].Tag = tx.Id;
            }
        }

        private void RefreshActiveLimitsPanel()
        {
            try
            {
                var budRepo = new BudgetRepository();
                var catRepo = new CategoryRepository();
                var txRepo = new TransactionRepository();

                var active = budRepo.GetActive(DateTime.Now);
                lblLimitsHeader.Text = "Активные лимиты:";

                if (active.Count == 0)
                {
                    lblLimitsContent.Text = "Нет активных лимитов.";
                    return;
                }

                var allCats = catRepo.GetAll(false);
                var lines = new List<string>();

                foreach (var b in active)
                {
                    List<int> scopeCatIds;
                    string scopeText;

                    if (b.AppliesToAll)
                    {
                        scopeCatIds = new List<int>();
                        foreach (var c in allCats) scopeCatIds.Add(c.Id);
                        scopeText = "Все категории";
                    }
                    else
                    {
                        scopeCatIds = new List<int>(b.CategoryIds ?? new List<int>());
                        var names = allCats
                            .Where(c => scopeCatIds.Contains(c.Id))
                            .Select(c => c.Name)
                            .ToList();
                        scopeText = string.Join(", ", names);
                    }

                    var spent = txRepo.SumExpensesByCategoriesAndPeriod(scopeCatIds, b.StartDate, b.EndDate);

                    string suffix;
                    if (spent <= b.Amount)
                    {
                        var remaining = b.Amount - spent;
                        suffix = string.Format("Потрачено: {0:0.##} | Остаток: {1:0.##}", spent, remaining);
                    }
                    else
                    {
                        var exceeded = spent - b.Amount;
                        suffix = string.Format("Потрачено: {0:0.##} | Превышение: {1:0.##}", spent, exceeded);
                    }

                    lines.Add(string.Format(
                        "• {0:dd.MM.yyyy}–{1:dd.MM.yyyy} | {2} | Лимит: {3:0.##} | {4}",
                        b.StartDate, b.EndDate, scopeText, b.Amount, suffix
                    ));
                }

                lblLimitsContent.Text = string.Join(Environment.NewLine, lines);
            }
            catch (Exception ex)
            {
                lblLimitsHeader.Text = "Активные лимиты:";
                lblLimitsContent.Text = "Ошибка загрузки лимитов: " + ex.Message;
            }
        }


        private void btnManageTransactions_Click(object sender, EventArgs e)
        {
            using (var frm = new FinanceTracker.Forms.Transactions.ManageTransactionsForm())
            {
                frm.ShowDialog(this);
                LoadTransactionsPreview();
                RefreshActiveLimitsPanel();
            }
        }

        private void btnManageBudget_Click(object sender, EventArgs e)
        {
            using (var frm = new FinanceTracker.Forms.Budgets.ManageBudgetForm())
            {
                frm.ShowDialog(this);
                RefreshActiveLimitsPanel();
            }
        }

        private void btnManageCategories_Click(object sender, EventArgs e)
        {
            using (var frm = new FinanceTracker.Forms.Categories.ManageCategoriesForm())
            {
                frm.ShowDialog(this);
                LoadTransactionsPreview();
                RefreshActiveLimitsPanel();
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            using (var frm = new FinanceTracker.Forms.Reports.ReportsForm())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            using (var frm = new AboutForm())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnExit_Click(object sender, EventArgs e) => Close();

        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
