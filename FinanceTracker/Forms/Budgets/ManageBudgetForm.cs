using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FinanceTracker.Classes.Models;
using FinanceTracker.Classes.Repositories;
using FinanceTracker.Classes.UI;

namespace FinanceTracker.Forms.Budgets
{
    public partial class ManageBudgetForm : Form
    {
        private readonly BudgetRepository _repo = new BudgetRepository();
        private readonly CategoryRepository _catRepo = new CategoryRepository();

        private readonly HashSet<int> _selectedIds = new HashSet<int>();

        public ManageBudgetForm()
        {
            InitializeComponent();
            try { Theme.Apply(this); } catch { }
        }

        private void ManageBudgetForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadBudgets();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки лимитов: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBudgets()
        {
            var list = _repo.GetAll();
            var cats = _catRepo.GetAll(false);

            dgvBudgets.Rows.Clear();
            int no = 1;

            foreach (var b in list)
            {
                string scopeText = b.AppliesToAll
                    ? "Все категории"
                    : string.Join(", ", cats.Where(c => b.CategoryIds.Contains(c.Id)).Select(c => c.Name));

                bool isChecked = _selectedIds.Contains(b.Id);

                int idx = dgvBudgets.Rows.Add(
                    isChecked,
                    no++,
                    b.Id,
                    string.Format("{0:dd.MM.yyyy} — {1:dd.MM.yyyy}", b.StartDate, b.EndDate),
                    b.Amount.ToString("0.##"),
                    scopeText
                );

                dgvBudgets.Rows[idx].Tag = b;
            }
        }


        private List<int> GetSelectedIdsFromSet() => new List<int>(_selectedIds);

        private BudgetLimit GetSingleSelectedOrNull(out int selectedCount)
        {
            selectedCount = _selectedIds.Count;
            if (selectedCount != 1) return null;

            foreach (DataGridViewRow row in dgvBudgets.Rows)
            {
                int id = Convert.ToInt32(row.Cells["colId"].Value);
                if (_selectedIds.Contains(id))
                    return row.Tag as BudgetLimit;
            }
            return null;
        }

        private void ToggleRowSelection(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvBudgets.Rows.Count) return;

            var row = dgvBudgets.Rows[rowIndex];
            int id = Convert.ToInt32(row.Cells["colId"].Value);

            bool nowChecked = !_selectedIds.Contains(id);
            if (nowChecked) _selectedIds.Add(id);
            else _selectedIds.Remove(id);

            var cell = row.Cells["colSelect"] as DataGridViewCheckBoxCell;
            if (cell != null) cell.Value = nowChecked;

            dgvBudgets.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dgvBudgets.EndEdit();
        }


        private void dgvBudgets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dgvBudgets.Columns["colSelect"].Index)
            {
                ToggleRowSelection(e.RowIndex);
            }
        }

        private void dgvBudgets_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvBudgets.Columns["colSelect"].Index)
                dgvBudgets.EndEdit();
        }

        private void dgvBudgets_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvBudgets.IsCurrentCellDirty)
                dgvBudgets.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var dlg = new AddEditBudgetForm())
            {
                dlg.InitForCreate();
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    LoadBudgets();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int count;
            var single = GetSingleSelectedOrNull(out count);

            if (count == 0)
            {
                MessageBox.Show("Выберите один лимит для редактирования.",
                    "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (count > 1)
            {
                MessageBox.Show("Редактировать можно только один лимит за раз.",
                    "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dlg = new AddEditBudgetForm())
            {
                dlg.InitForEdit(single);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    LoadBudgets();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var ids = GetSelectedIdsFromSet();
            if (ids.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы один лимит для удаления.",
                    "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show("Удалить выбранные лимиты?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _repo.DeleteMany(ids);
                foreach (var id in ids) _selectedIds.Remove(id);
                LoadBudgets();
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
