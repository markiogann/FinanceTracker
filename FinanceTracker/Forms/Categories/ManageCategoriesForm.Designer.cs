namespace FinanceTracker.Forms.Categories
{
    partial class ManageCategoriesForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblHeader;

        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AllowUserToResizeRows = false;
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colNo,
            this.colId,
            this.colName});
            this.dgvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategories.Location = new System.Drawing.Point(0, 0);
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = false; // важно: грид не ReadOnly
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter; // кликабельность чекбоксов
            this.dgvCategories.Size = new System.Drawing.Size(724, 441);
            this.dgvCategories.TabIndex = 0;
            this.dgvCategories.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCategories_CurrentCellDirtyStateChanged);
            this.dgvCategories.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellContentClick);
            this.dgvCategories.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCategories_CellMouseUp);
            // 
            // colSelect
            // 
            this.colSelect.HeaderText = "";
            this.colSelect.Name = "colSelect";
            this.colSelect.ReadOnly = false;     // чекбокс редактируемый
            this.colSelect.ThreeState = false;
            this.colSelect.FillWeight = 30F;
            // 
            // colNo
            // 
            this.colNo.HeaderText = "№";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.FillWeight = 60F;
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.FillWeight = 1F;
            // 
            // colName
            // 
            this.colName.HeaderText = "Название категории";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true; // редактирование названия — через отдельную форму
            this.colName.FillWeight = 260F;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.btnClose);
            this.panelRight.Controls.Add(this.btnDelete);
            this.panelRight.Controls.Add(this.btnEdit);
            this.panelRight.Controls.Add(this.btnAdd);
            this.panelRight.Controls.Add(this.lblHeader);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(724, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(10);
            this.panelRight.Size = new System.Drawing.Size(216, 441);
            this.panelRight.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClose.Location = new System.Drawing.Point(10, 196);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(196, 36);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDelete.Location = new System.Drawing.Point(10, 160);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(196, 36);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Удалить выбранные";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEdit.Location = new System.Drawing.Point(10, 124);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(196, 36);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Редактировать выбранную";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdd.Location = new System.Drawing.Point(10, 88);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(196, 36);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Добавить категорию";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Location = new System.Drawing.Point(10, 10);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(196, 78);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Категории";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ManageCategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(940, 441);
            this.Controls.Add(this.dgvCategories);
            this.Controls.Add(this.panelRight);
            this.MinimumSize = new System.Drawing.Size(880, 460);
            this.Name = "ManageCategoriesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление категориями";
            this.Load += new System.EventHandler(this.ManageCategoriesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
