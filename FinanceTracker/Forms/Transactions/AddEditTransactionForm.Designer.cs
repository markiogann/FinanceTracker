namespace FinanceTracker.Forms.Transactions
{
    partial class AddEditTransactionForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(12, 14);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(140, 23);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Дата:";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(15, 40);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(220, 20);
            this.dtpDate.TabIndex = 1;
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(250, 14);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(120, 23);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Тип:";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Расход",
            "Доход"});
            this.cmbType.Location = new System.Drawing.Point(253, 40);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(140, 21);
            this.cmbType.TabIndex = 3;
            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(12, 75);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(140, 23);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Категория:";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(15, 101);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(378, 21);
            this.cmbCategory.TabIndex = 5;
            this.cmbCategory.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbCategory_Format);
            // 
            // lblAmount
            // 
            this.lblAmount.Location = new System.Drawing.Point(12, 137);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(140, 23);
            this.lblAmount.TabIndex = 6;
            this.lblAmount.Text = "Сумма:";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(15, 163);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(180, 20);
            this.txtAmount.TabIndex = 7;
            // 
            // lblComment
            // 
            this.lblComment.Location = new System.Drawing.Point(12, 198);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(140, 23);
            this.lblComment.TabIndex = 8;
            this.lblComment.Text = "Комментарий:";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(15, 224);
            this.txtComment.MaxLength = 500;
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(378, 88);
            this.txtComment.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(212, 327);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 32);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(306, 327);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 32);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddEditTransactionForm
            // 
            this.ClientSize = new System.Drawing.Size(411, 375);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.MinimumSize = new System.Drawing.Size(427, 414);
            this.Name = "AddEditTransactionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Транзакция";
            this.Load += new System.EventHandler(this.AddEditTransactionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
