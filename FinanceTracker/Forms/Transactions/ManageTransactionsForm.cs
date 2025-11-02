using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FinanceTracker.Classes.Models;
using FinanceTracker.Classes.Repositories;
using FinanceTracker.Classes.UI;

namespace FinanceTracker.Forms.Transactions
{
    public partial class ManageTransactionsForm : Form
    {
        private readonly TransactionRepository _txRepo = new TransactionRepository();

        private readonly HashSet<int> _selectedIds = new HashSet<int>();

        public ManageTransactionsForm()
        {
            InitializeComponent();
            try { Theme.Apply(this); } catch { }
        }

        private void ManageTransactionsForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTransactions();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки транзакций: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTransactions()
        {
            var items = _txRepo.GetRecentWithCategoryName(5000);
            dgvTransactions.Rows.Clear();

            int no = 1;
            foreach (var pair in items)
            {
                var tx = pair.tx;
                var categoryName = pair.categoryName;

                string typeText = tx.Type == TransactionType.Income ? "Доход" : "Расход";

                bool isChecked = _selectedIds.Contains(tx.Id);
                int idx = dgvTransactions.Rows.Add(
                    isChecked,
                    no++,
                    tx.Id,
                    tx.Date.ToString("yyyy-MM-dd HH:mm"),
                    typeText,
                    categoryName,
                    tx.Amount.ToString("0.##"),
                    tx.Comment
                );

                dgvTransactions.Rows[idx].Tag = tx;
            }
        }


        private List<int> GetSelectedIdsFromSet()
        {
            return new List<int>(_selectedIds);
        }

        private Transaction GetSingleSelectedOrNull(out int selectedCount)
        {
            selectedCount = _selectedIds.Count;
            if (selectedCount != 1) return null;

            foreach (DataGridViewRow row in dgvTransactions.Rows)
            {
                int id = Convert.ToInt32(row.Cells["colId"].Value);
                if (_selectedIds.Contains(id))
                    return row.Tag as Transaction;
            }
            return null;
        }


        private void ToggleRowSelection(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvTransactions.Rows.Count) return;

            var row = dgvTransactions.Rows[rowIndex];
            int id = Convert.ToInt32(row.Cells["colId"].Value);

            bool nowChecked = !_selectedIds.Contains(id);
            if (nowChecked)
                _selectedIds.Add(id);
            else
                _selectedIds.Remove(id);

            var cell = row.Cells["colSelect"] as DataGridViewCheckBoxCell;
            if (cell != null)
            {
                cell.Value = nowChecked;
            }

            dgvTransactions.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dgvTransactions.EndEdit();
        }

        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dgvTransactions.Columns["colSelect"].Index)
            {
                ToggleRowSelection(e.RowIndex);
            }
        }

        private void dgvTransactions_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dgvTransactions.Columns["colSelect"].Index)
            {
                dgvTransactions.EndEdit();
            }
        }

        private void dgvTransactions_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvTransactions.IsCurrentCellDirty)
                dgvTransactions.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var dlg = new AddEditTransactionForm())
            {
                dlg.InitForCreate();
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadTransactions();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int count;
            var single = GetSingleSelectedOrNull(out count);

            if (count == 0)
            {
                MessageBox.Show("Выберите одну транзакцию для редактирования.",
                    "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (count > 1)
            {
                MessageBox.Show("Редактировать можно только одну транзакцию за раз.",
                    "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dlg = new AddEditTransactionForm())
            {
                dlg.InitForEdit(single);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadTransactions();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var ids = GetSelectedIdsFromSet();
            if (ids.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы одну транзакцию для удаления.",
                    "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show("Удалить выбранные транзакции?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _txRepo.DeleteMany(ids);
                foreach (var id in ids) _selectedIds.Remove(id);
                LoadTransactions();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
