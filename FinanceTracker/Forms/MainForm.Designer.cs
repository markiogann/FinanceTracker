namespace FinanceTracker.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Button btnManageTransactions;
        private System.Windows.Forms.Button btnManageBudget;
        private System.Windows.Forms.Button btnManageCategories;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnExit;

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblLimitsHeader;
        private System.Windows.Forms.Label lblLimitsContent;

        // Колонки БЕЗ чекбокса
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
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnManageCategories = new System.Windows.Forms.Button();
            this.btnManageBudget = new System.Windows.Forms.Button();
            this.btnManageTransactions = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblLimitsContent = new System.Windows.Forms.Label();
            this.lblLimitsHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.panelRight.SuspendLayout();
            this.panelBottom.SuspendLayout();
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
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.Size = new System.Drawing.Size(884, 432);
            this.dgvTransactions.TabIndex = 0;
            // 
            // colNo
            // 
            this.colNo.FillWeight = 48F;
            this.colNo.HeaderText = "№";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            // 
            // colId
            // 
            this.colId.FillWeight = 1F;
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colDate
            // 
            this.colDate.FillWeight = 120F;
            this.colDate.HeaderText = "Дата";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colType
            // 
            this.colType.FillWeight = 80F;
            this.colType.HeaderText = "Тип";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            // 
            // colCategory
            // 
            this.colCategory.FillWeight = 160F;
            this.colCategory.HeaderText = "Категория";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Сумма";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colComment
            // 
            this.colComment.FillWeight = 220F;
            this.colComment.HeaderText = "Комментарий";
            this.colComment.Name = "colComment";
            this.colComment.ReadOnly = true;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.btnExit);
            this.panelRight.Controls.Add(this.btnAbout);
            this.panelRight.Controls.Add(this.btnReports);
            this.panelRight.Controls.Add(this.btnManageCategories);
            this.panelRight.Controls.Add(this.btnManageBudget);
            this.panelRight.Controls.Add(this.btnManageTransactions);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(884, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(10);
            this.panelRight.Size = new System.Drawing.Size(216, 432);
            this.panelRight.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExit.Location = new System.Drawing.Point(10, 190);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(196, 36);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAbout.Location = new System.Drawing.Point(10, 154);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(196, 36);
            this.btnAbout.TabIndex = 4;
            this.btnAbout.Text = "О программе";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnReports
            // 
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.Location = new System.Drawing.Point(10, 118);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(196, 36);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "Создать отчёт";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnManageCategories
            // 
            this.btnManageCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageCategories.Location = new System.Drawing.Point(10, 82);
            this.btnManageCategories.Name = "btnManageCategories";
            this.btnManageCategories.Size = new System.Drawing.Size(196, 36);
            this.btnManageCategories.TabIndex = 2;
            this.btnManageCategories.Text = "Управление категориями";
            this.btnManageCategories.UseVisualStyleBackColor = true;
            this.btnManageCategories.Click += new System.EventHandler(this.btnManageCategories_Click);
            // 
            // btnManageBudget
            // 
            this.btnManageBudget.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageBudget.Location = new System.Drawing.Point(10, 46);
            this.btnManageBudget.Name = "btnManageBudget";
            this.btnManageBudget.Size = new System.Drawing.Size(196, 36);
            this.btnManageBudget.TabIndex = 1;
            this.btnManageBudget.Text = "Управление бюджетом";
            this.btnManageBudget.UseVisualStyleBackColor = true;
            this.btnManageBudget.Click += new System.EventHandler(this.btnManageBudget_Click);
            // 
            // btnManageTransactions
            // 
            this.btnManageTransactions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageTransactions.Location = new System.Drawing.Point(10, 10);
            this.btnManageTransactions.Name = "btnManageTransactions";
            this.btnManageTransactions.Size = new System.Drawing.Size(196, 36);
            this.btnManageTransactions.TabIndex = 0;
            this.btnManageTransactions.Text = "Управление транзакциями";
            this.btnManageTransactions.UseVisualStyleBackColor = true;
            this.btnManageTransactions.Click += new System.EventHandler(this.btnManageTransactions_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblLimitsContent);
            this.panelBottom.Controls.Add(this.lblLimitsHeader);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 432);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.panelBottom.Size = new System.Drawing.Size(1100, 89);
            this.panelBottom.TabIndex = 2;
            // 
            // lblLimitsContent
            // 
            this.lblLimitsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLimitsContent.Location = new System.Drawing.Point(10, 29);
            this.lblLimitsContent.Name = "lblLimitsContent";
            this.lblLimitsContent.Size = new System.Drawing.Size(1080, 54);
            this.lblLimitsContent.TabIndex = 1;
            this.lblLimitsContent.Text = "—";
            // 
            // lblLimitsHeader
            // 
            this.lblLimitsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLimitsHeader.Location = new System.Drawing.Point(10, 6);
            this.lblLimitsHeader.Name = "lblLimitsHeader";
            this.lblLimitsHeader.Size = new System.Drawing.Size(1080, 23);
            this.lblLimitsHeader.TabIndex = 0;
            this.lblLimitsHeader.Text = "Активные лимиты:";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1100, 521);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelBottom);
            this.MinimumSize = new System.Drawing.Size(980, 560);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FinanceTracker — Главная";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
