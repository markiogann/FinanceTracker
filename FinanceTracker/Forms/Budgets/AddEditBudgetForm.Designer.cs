namespace FinanceTracker.Forms.Budgets
{
    partial class AddEditBudgetForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.ListBox lbCategories;
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
            this.lblStart = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.lblCategories = new System.Windows.Forms.Label();
            this.lbCategories = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(12, 13);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(160, 23);
            this.lblStart.TabIndex = 0;
            this.lblStart.Text = "Начало периода:";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "yyyy-MM-dd";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(15, 39);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(160, 20);
            this.dtStart.TabIndex = 1;
            // 
            // lblEnd
            // 
            this.lblEnd.Location = new System.Drawing.Point(194, 13);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(160, 23);
            this.lblEnd.TabIndex = 2;
            this.lblEnd.Text = "Окончание периода:";
            this.lblEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "yyyy-MM-dd";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(197, 39);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(160, 20);
            this.dtEnd.TabIndex = 3;
            // 
            // lblAmount
            // 
            this.lblAmount.Location = new System.Drawing.Point(12, 74);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(160, 23);
            this.lblAmount.TabIndex = 4;
            this.lblAmount.Text = "Сумма лимита:";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(15, 100);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(160, 20);
            this.txtAmount.TabIndex = 5;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(197, 102);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(128, 17);
            this.chkAll.TabIndex = 6;
            this.chkAll.Text = "Для всех категорий";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // lblCategories
            // 
            this.lblCategories.Location = new System.Drawing.Point(12, 135);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(345, 23);
            this.lblCategories.TabIndex = 7;
            this.lblCategories.Text = "Выберите категории (если не для всех):";
            this.lblCategories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCategories
            // 
            this.lbCategories.FormattingEnabled = true;
            this.lbCategories.Location = new System.Drawing.Point(15, 161);
            this.lbCategories.Name = "lbCategories";
            this.lbCategories.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbCategories.Size = new System.Drawing.Size(342, 121);
            this.lbCategories.TabIndex = 8;
            this.lbCategories.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lbCategories_Format);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(188, 298);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 32);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(281, 298);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 32);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddEditBudgetForm
            // 
            this.ClientSize = new System.Drawing.Size(372, 346);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbCategories);
            this.Controls.Add(this.lblCategories);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.lblStart);
            this.MinimumSize = new System.Drawing.Size(388, 385);
            this.Name = "AddEditBudgetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Лимит";
            this.Load += new System.EventHandler(this.AddEditBudgetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
