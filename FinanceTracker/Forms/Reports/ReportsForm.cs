using FinanceTracker.Classes.Models;
using FinanceTracker.Classes.Repositories;
using FinanceTracker.Classes.Services;
using FinanceTracker.Classes.UI;
using FinanceTracker.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FinanceTracker.Forms.Reports
{
    public partial class ReportsForm : Form
    {
        private readonly CategoryRepository _catRepo = new CategoryRepository();
        private readonly ReportService _reportService = new ReportService();

        public ReportsForm()
        {
            InitializeComponent();
            Theme.Apply(this);
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            dtStart.Value = DateTime.Today.AddMonths(-1);
            dtEnd.Value = DateTime.Today;

            cmbType.Items.Clear();
            cmbType.Items.Add("Все");
            cmbType.Items.Add("Расход");
            cmbType.Items.Add("Доход");
            cmbType.SelectedIndex = 0;

            LoadCategories();
            ToggleCategories();
        }

        private void LoadCategories()
        {
            var cats = _catRepo.GetAll(false);
            lbCategories.Items.Clear();
            foreach (var c in cats) lbCategories.Items.Add(c);
        }

        private void ToggleCategories()
        {
            lbCategories.Enabled = !chkAllCategories.Checked;
        }

        private void chkAllCategories_CheckedChanged(object sender, EventArgs e)
        {
            ToggleCategories();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtEnd.Value.Date < dtStart.Value.Date)
                    throw new ArgumentException("Дата окончания не может быть раньше даты начала.");

                decimal? minAmount = null;
                decimal? maxAmount = null;

                if (!string.IsNullOrWhiteSpace(txtMinAmount.Text))
                    minAmount = MoneyUtils.ParseOrThrow(txtMinAmount.Text.Trim(), "Мин. сумма");
                if (!string.IsNullOrWhiteSpace(txtMaxAmount.Text))
                    maxAmount = MoneyUtils.ParseOrThrow(txtMaxAmount.Text.Trim(), "Макс. сумма");

                var typeFilter = default(int?);
                if (cmbType.SelectedIndex == 1) typeFilter = 0;
                else if (cmbType.SelectedIndex == 2) typeFilter = 1;

                var ids = new List<int>();
                if (!chkAllCategories.Checked)
                {
                    if (lbCategories.SelectedItems.Count == 0)
                        throw new ArgumentException("Выберите хотя бы одну категорию или отметьте «Все категории».");

                    foreach (var item in lbCategories.SelectedItems)
                    {
                        var cat = item as Category;
                        if (cat != null) ids.Add(cat.Id);
                    }
                }

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF files (*.pdf)|*.pdf";
                    sfd.FileName = "FinanceTrackerReport.pdf";
                    if (sfd.ShowDialog(this) != DialogResult.OK)
                        return;

                    var p = new ReportService.ReportParams
                    {
                        Start = new DateTime(dtStart.Value.Year, dtStart.Value.Month, dtStart.Value.Day, 0, 0, 0),
                        End = new DateTime(dtEnd.Value.Year, dtEnd.Value.Month, dtEnd.Value.Day, 23, 59, 59),
                        TypeFilter = typeFilter,
                        CategoryIds = ids.Count == 0 ? null : ids,
                        MinAmount = minAmount,
                        MaxAmount = maxAmount
                    };

                    _reportService.GeneratePdf(sfd.FileName, p);
                    MessageBox.Show("Отчёт успешно сохранён:\n" + sfd.FileName, "Готово",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbCategories_Format(object sender, ListControlConvertEventArgs e)
        {
            var cat = e.ListItem as Category;
            if (cat != null) e.Value = cat.Name;
        }
    }
}
