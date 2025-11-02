using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FinanceTracker.Classes.Models;
using FinanceTracker.Classes.Repositories;
using FinanceTracker.Classes.UI;

namespace FinanceTracker.Forms.Categories
{
    public partial class ManageCategoriesForm : Form
    {
        private readonly CategoryRepository _catRepo = new CategoryRepository();

        private readonly HashSet<int> _selectedIds = new HashSet<int>();

        public ManageCategoriesForm()
        {
            InitializeComponent();
            try { Theme.Apply(this); } catch { }
        }

        private void ManageCategoriesForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки категорий: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            var cats = _catRepo.GetAll(false);
            dgvCategories.Rows.Clear();

            int no = 1;
            foreach (var c in cats)
            {
                bool isChecked = _selectedIds.Contains(c.Id);
                int idx = dgvCategories.Rows.Add(isChecked, no++, c.Id, c.Name);
                dgvCategories.Rows[idx].Tag = c;
            }
        }


        private List<int> GetSelectedIdsFromSet() => new List<int>(_selectedIds);

        private Category GetSingleSelectedOrNull(out int selectedCount)
        {
            selectedCount = _selectedIds.Count;
            if (selectedCount != 1) return null;

            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                int id = Convert.ToInt32(row.Cells["colId"].Value);
                if (_selectedIds.Contains(id))
                    return row.Tag as Category;
            }
            return null;
        }

        private void ToggleRowSelection(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvCategories.Rows.Count) return;

            var row = dgvCategories.Rows[rowIndex];
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

            dgvCategories.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dgvCategories.EndEdit();
        }


        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dgvCategories.Columns["colSelect"].Index)
            {
                ToggleRowSelection(e.RowIndex);
            }
        }

        private void dgvCategories_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvCategories.Columns["colSelect"].Index)
                dgvCategories.EndEdit();
        }

        private void dgvCategories_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCategories.IsCurrentCellDirty)
                dgvCategories.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var dlg = new AddEditCategoryForm())
            {
                dlg.InitForCreate();
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadCategories();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int count;
            var single = GetSingleSelectedOrNull(out count);

            if (count == 0)
            {
                MessageBox.Show("Выберите одну категорию для редактирования.",
                    "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (count > 1)
            {
                MessageBox.Show("Редактировать можно только одну категорию за раз.",
                    "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dlg = new AddEditCategoryForm())
            {
                dlg.InitForEdit(single.Id, single.Name);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadCategories();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var ids = GetSelectedIdsFromSet();
            if (ids.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы одну категорию для удаления.",
                    "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "Удалить выбранные категории?\n" +
                "Транзакции из удаляемых категорий будут перенесены в «Прочее».",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _catRepo.DeleteMany(ids);
                foreach (var id in ids) _selectedIds.Remove(id);
                LoadCategories();
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
