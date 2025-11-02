namespace FinanceTracker.Forms.Budgets
{
    partial class ManageBudgetForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvBudgets;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblHeader;

        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScope;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvBudgets = new System.Windows.Forms.DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScope = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudgets)).BeginInit();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBudgets
            // 
            this.dgvBudgets.AllowUserToAddRows = false;
            this.dgvBudgets.AllowUserToDeleteRows = false;
            this.dgvBudgets.AllowUserToResizeRows = false;
            this.dgvBudgets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBudgets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBudgets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colNo,
            this.colId,
            this.colPeriod,
            this.colAmount,
            this.colScope});
            this.dgvBudgets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBudgets.Location = new System.Drawing.Point(0, 0);
            this.dgvBudgets.MultiSelect = false;
            this.dgvBudgets.Name = "dgvBudgets";
            this.dgvBudgets.ReadOnly = false; // чекбоксы кликаемы
            this.dgvBudgets.RowHeadersVisible = false;
            this.dgvBudgets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBudgets.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvBudgets.Size = new System.Drawing.Size(724, 441);
            this.dgvBudgets.TabIndex = 0;
            this.dgvBudgets.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvBudgets_CurrentCellDirtyStateChanged);
            this.dgvBudgets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBudgets_CellContentClick);
            this.dgvBudgets.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBudgets_CellMouseUp);
            // 
            // colSelect
            // 
            this.colSelect.HeaderText = "";
            this.colSelect.Name = "colSelect";
            this.colSelect.ReadOnly = false;
            this.colSelect.ThreeState = false;
            this.colSelect.FillWeight = 30F;
            // 
            // colNo
            // 
            this.colNo.HeaderText = "№";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.FillWeight = 50F;
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.FillWeight = 1F;
            // 
            // colPeriod
            // 
            this.colPeriod.HeaderText = "Период";
            this.colPeriod.Name = "colPeriod";
            this.colPeriod.ReadOnly = true;
            this.colPeriod.FillWeight = 160F;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Сумма лимита";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.FillWeight = 120F;
            // 
            // colScope
            // 
            this.colScope.HeaderText = "На категории";
            this.colScope.Name = "colScope";
            this.colScope.ReadOnly = true;
            this.colScope.FillWeight = 220F;
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
            this.btnEdit.Text = "Редактировать выбранный";
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
            this.btnAdd.Text = "Добавить лимит";
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
            this.lblHeader.Text = "Лимиты расходов";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ManageBudgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(940, 441);
            this.Controls.Add(this.dgvBudgets);
            this.Controls.Add(this.panelRight);
            this.MinimumSize = new System.Drawing.Size(880, 460);
            this.Name = "ManageBudgetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление лимитами";
            this.Load += new System.EventHandler(this.ManageBudgetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudgets)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
