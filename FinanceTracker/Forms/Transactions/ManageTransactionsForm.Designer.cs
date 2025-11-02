namespace FinanceTracker.Forms.Transactions
{
    partial class ManageTransactionsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblHeader;

        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComment;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.AllowUserToResizeRows = false;
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colNo,
            this.colId,
            this.colDate,
            this.colType,
            this.colCategory,
            this.colAmount,
            this.colComment});
            this.dgvTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransactions.Location = new System.Drawing.Point(0, 0);
            this.dgvTransactions.MultiSelect = false;
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = false;
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTransactions.Size = new System.Drawing.Size(784, 461);
            this.dgvTransactions.TabIndex = 0;
            this.dgvTransactions.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvTransactions_CurrentCellDirtyStateChanged);
            this.dgvTransactions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactions_CellContentClick);
            this.dgvTransactions.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTransactions_CellMouseUp);
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
            // colDate
            // 
            this.colDate.HeaderText = "Дата";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.FillWeight = 120F;
            // 
            // colType
            // 
            this.colType.HeaderText = "Тип";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.FillWeight = 80F;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "Категория";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.FillWeight = 160F;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Сумма";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.FillWeight = 100F;
            // 
            // colComment
            // 
            this.colComment.HeaderText = "Комментарий";
            this.colComment.Name = "colComment";
            this.colComment.ReadOnly = true;
            this.colComment.FillWeight = 200F;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.btnClose);
            this.panelRight.Controls.Add(this.btnDelete);
            this.panelRight.Controls.Add(this.btnEdit);
            this.panelRight.Controls.Add(this.btnAdd);
            this.panelRight.Controls.Add(this.lblHeader);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(784, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(10);
            this.panelRight.Size = new System.Drawing.Size(216, 461);
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
            this.btnAdd.Text = "Добавить транзакцию";
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
            this.lblHeader.Text = "Транзакции";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ManageTransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1000, 461);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.panelRight);
            this.MinimumSize = new System.Drawing.Size(900, 480);
            this.Name = "ManageTransactionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление транзакциями";
            this.Load += new System.EventHandler(this.ManageTransactionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
