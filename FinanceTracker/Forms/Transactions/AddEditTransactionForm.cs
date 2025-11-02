using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FinanceTracker.Classes.Models;
using FinanceTracker.Classes.Repositories;
using FinanceTracker.Classes.Services;
using FinanceTracker.Classes.UI;
using FinanceTracker.Classes.Utils;

namespace FinanceTracker.Forms.Transactions
{
    public partial class AddEditTransactionForm : Form
    {
        private readonly TransactionRepository _txRepo = new TransactionRepository();
        private readonly CategoryRepository _catRepo = new CategoryRepository();

        private bool _isEdit = false;
        private int _editId = 0;

        private Transaction _originalTx = null;

        public AddEditTransactionForm()
        {
            InitializeComponent();
            Theme.Apply(this);
        }

        public void InitForCreate()
        {
            Text = "Добавить транзакцию";
            _isEdit = false;
            _editId = 0;
            _originalTx = null;

            dtpDate.Value = DateTime.Now;
            cmbType.SelectedIndex = 0;
            txtAmount.Text = "";
            txtComment.Text = "";

            LoadCategories();
        }

        public void InitForEdit(Transaction tx)
        {
            Text = "Редактировать транзакцию";
            _isEdit = true;
            _editId = tx.Id;

            dtpDate.Value = tx.Date;
            cmbType.SelectedIndex = tx.Type == TransactionType.Income ? 1 : 0;
            txtAmount.Text = tx.Amount.ToString("0.##");
            txtComment.Text = tx.Comment ?? "";

            LoadCategories();

            for (int i = 0; i < cmbCategory.Items.Count; i++)
            {
                var item = cmbCategory.Items[i] as Category;
                if (item != null && item.Id == tx.CategoryId)
                {
                    cmbCategory.SelectedIndex = i;
                    break;
                }
            }

            _originalTx = tx;
        }

        private void LoadCategories()
        {
            var cats = _catRepo.GetAll(false);
            cmbCategory.Items.Clear();
            foreach (var c in cats)
                cmbCategory.Items.Add(c);

            if (cmbCategory.Items.Count > 0 && cmbCategory.SelectedIndex < 0)
                cmbCategory.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Guard.NotNull(cmbCategory.SelectedItem, "Категория");
                Guard.NotNullOrWhiteSpace(txtAmount.Text, "Сумма");

                var category = (Category)cmbCategory.SelectedItem;
                var amount = MoneyUtils.ParseOrThrow(txtAmount.Text.Trim(), "Сумма");
                Guard.GreaterThanZero(amount, "Сумма");

                var type = cmbType.SelectedIndex == 1 ? TransactionType.Income : TransactionType.Expense;

                var tx = new Transaction
                {
                    Id = _editId,
                    Date = dtpDate.Value,
                    Type = type,
                    CategoryId = category.Id,
                    Amount = amount,
                    Comment = string.IsNullOrWhiteSpace(txtComment.Text) ? "" : txtComment.Text.Trim()
                };

                if (type == TransactionType.Expense)
                {
                    var budgetService = new BudgetService();
                    var check = budgetService.CheckExceedForExpense(
                        tx.CategoryId, tx.Amount, tx.Date, _isEdit ? _originalTx : null
                    );

                    if (check.IsExceeded)
                    {
                        var result = MessageBox.Show(
                            check.Message + "\n\nДобавить транзакцию несмотря на превышение?",
                            "Превышение лимита",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Warning
                        );

                        if (result == DialogResult.No)
                        {
                            return;
                        }
                        if (result == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                }

                if (_isEdit)
                    _txRepo.Update(tx);
                else
                    _txRepo.Create(tx);

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
        private void AddEditTransactionForm_Load(object sender, EventArgs e)
        {
        }

        private void cmbCategory_Format(object sender, ListControlConvertEventArgs e)
        {
            var category = e.ListItem as Category;
            if (category != null)
                e.Value = category.Name;
        }
    }
}
