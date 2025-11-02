using FinanceTracker.Classes.Services;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FinanceTracker.Forms.Categories
{
    public partial class AddEditCategoryForm : Form
    {
        private readonly CategoryService _service = new CategoryService();

        public int? CategoryId { get; private set; }
        public string CategoryNameValue
        {
            get { return txtName.Text.Trim(); }
            set { txtName.Text = value ?? ""; }
        }

        public AddEditCategoryForm()
        {
            InitializeComponent();
        }

        public void InitForCreate()
        {
            Text = "Добавить категорию";
            CategoryId = null;
        }

        public void InitForEdit(int id, string currentName)
        {
            Text = "Редактировать категорию";
            CategoryId = id;
            CategoryNameValue = currentName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var name = CategoryNameValue;
                if (CategoryId == null)
                {
                    _service.CreateCategory(name);
                }
                else
                {
                    _service.RenameCategory(CategoryId.Value, name);
                }

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

        private void AddEditCategoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
