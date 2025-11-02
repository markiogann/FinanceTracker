using FinanceTracker.Classes.Models;
using FinanceTracker.Classes.Repositories;
using FinanceTracker.Classes.UI;
using FinanceTracker.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace FinanceTracker.Forms.Budgets
{
    public partial class AddEditBudgetForm : Form
    {
        private readonly BudgetRepository _repo = new BudgetRepository();
        private readonly CategoryRepository _catRepo = new CategoryRepository();

        private bool _isEdit = false;
        private int _editId = 0;

        public AddEditBudgetForm()
        {
            InitializeComponent();
            Theme.Apply(this);
        }

        public void InitForCreate()
        {
            Text = "Добавить лимит";
            _isEdit = false;

            dtStart.Value = DateTime.Today;
            dtEnd.Value = DateTime.Today.AddDays(30);
            txtAmount.Text = "";
            chkAll.Checked = true;

            LoadCategories();
            ToggleCategories();
        }

        public void InitForEdit(BudgetLimit b)
        {
            Text = "Редактировать лимит";
            _isEdit = true;
            _editId = b.Id;

            dtStart.Value = b.StartDate;
            dtEnd.Value = b.EndDate;
            txtAmount.Text = b.Amount.ToString("0.##");
            chkAll.Checked = b.AppliesToAll;

            LoadCategories();
            if (!b.AppliesToAll)
            {
                for (int i = 0; i < lbCategories.Items.Count; i++)
                {
                    var cat = lbCategories.Items[i] as Category;
                    if (cat != null && b.CategoryIds.Contains(cat.Id))
                        lbCategories.SetSelected(i, true);
                }
            }

            ToggleCategories();
        }

        private void LoadCategories()
        {
            var cats = _catRepo.GetAll(false);
            lbCategories.Items.Clear();
            foreach (var c in cats)
                lbCategories.Items.Add(c);
        }

        private void ToggleCategories()
        {
            lbCategories.Enabled = !chkAll.Checked;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            ToggleCategories();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Guard.NotNullOrWhiteSpace(txtAmount.Text, "Сумма лимита");
                var amount = MoneyUtils.ParseOrThrow(txtAmount.Text.Trim(), "Сумма лимита");
                Guard.GreaterThanZero(amount, "Сумма лимита");

                if (dtEnd.Value.Date < dtStart.Value.Date)
                    throw new ArgumentException("Дата окончания не может быть раньше даты начала.");

                var b = new BudgetLimit();
                b.Id = _editId;
                b.Amount = amount;
                b.StartDate = new DateTime(dtStart.Value.Year, dtStart.Value.Month, dtStart.Value.Day, 0, 0, 0);
                b.EndDate = new DateTime(dtEnd.Value.Year, dtEnd.Value.Month, dtEnd.Value.Day, 23, 59, 59);
                b.AppliesToAll = chkAll.Checked;
                b.CategoryIds = new List<int>();

                if (!b.AppliesToAll)
                {
                    if (lbCategories.SelectedItems.Count == 0)
                        throw new ArgumentException("Выберите хотя бы одну категорию или отметьте «для всех категорий».");

                    foreach (var item in lbCategories.SelectedItems)
                    {
                        var cat = item as Category;
                        if (cat != null) b.CategoryIds.Add(cat.Id);
                    }
                }

                if (_isEdit)
                    _repo.Update(b);
                else
                    _repo.Create(b);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void lbCategories_Format(object sender, ListControlConvertEventArgs e)
        {
            var cat = e.ListItem as Category;
            if (cat != null) e.Value = cat.Name;
        }

        private void AddEditBudgetForm_Load(object sender, EventArgs e)
        {

        }
    }
}
