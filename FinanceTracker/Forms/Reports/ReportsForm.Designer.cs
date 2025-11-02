namespace FinanceTracker.Forms.Reports
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.CheckBox chkAllCategories;
        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.ListBox lbCategories;
        private System.Windows.Forms.Label lblMinAmount;
        private System.Windows.Forms.TextBox txtMinAmount;
        private System.Windows.Forms.Label lblMaxAmount;
        private System.Windows.Forms.TextBox txtMaxAmount;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.chkAllCategories = new System.Windows.Forms.CheckBox();
            this.lblCategories = new System.Windows.Forms.Label();
            this.lbCategories = new System.Windows.Forms.ListBox();
            this.lblMinAmount = new System.Windows.Forms.Label();
            this.txtMinAmount = new System.Windows.Forms.TextBox();
            this.lblMaxAmount = new System.Windows.Forms.Label();
            this.txtMaxAmount = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPeriod
            // 
            this.lblPeriod.Location = new System.Drawing.Point(12, 9);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(120, 23);
            this.lblPeriod.TabIndex = 0;
            this.lblPeriod.Text = "Период:";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "yyyy-MM-dd";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(15, 35);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(120, 23);
            this.dtStart.TabIndex = 1;
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "yyyy-MM-dd";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(141, 35);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(120, 23);
            this.dtEnd.TabIndex = 2;
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(12, 70);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(120, 23);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Тип операций:";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(15, 96);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(246, 23);
            this.cmbType.TabIndex = 4;
            // 
            // chkAllCategories
            // 
            this.chkAllCategories.AutoSize = true;
            this.chkAllCategories.Location = new System.Drawing.Point(15, 131);
            this.chkAllCategories.Name = "chkAllCategories";
            this.chkAllCategories.Size = new System.Drawing.Size(117, 19);
            this.chkAllCategories.TabIndex = 5;
            this.chkAllCategories.Text = "Все категории";
            this.chkAllCategories.UseVisualStyleBackColor = true;
            this.chkAllCategories.CheckedChanged += new System.EventHandler(this.chkAllCategories_CheckedChanged);
            // 
            // lblCategories
            // 
            this.lblCategories.Location = new System.Drawing.Point(12, 153);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(249, 23);
            this.lblCategories.TabIndex = 6;
            this.lblCategories.Text = "Категории (если не все):";
            this.lblCategories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCategories
            // 
            this.lbCategories.FormattingEnabled = true;
            this.lbCategories.Location = new System.Drawing.Point(15, 179);
            this.lbCategories.Name = "lbCategories";
            this.lbCategories.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbCategories.Size = new System.Drawing.Size(246, 94);
            this.lbCategories.TabIndex = 7;
            this.lbCategories.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lbCategories_Format);
            // 
            // lblMinAmount
            // 
            this.lblMinAmount.Location = new System.Drawing.Point(12, 284);
            this.lblMinAmount.Name = "lblMinAmount";
            this.lblMinAmount.Size = new System.Drawing.Size(120, 23);
            this.lblMinAmount.TabIndex = 8;
            this.lblMinAmount.Text = "Мин. сумма:";
            this.lblMinAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMinAmount
            // 
            this.txtMinAmount.Location = new System.Drawing.Point(15, 310);
            this.txtMinAmount.Name = "txtMinAmount";
            this.txtMinAmount.Size = new System.Drawing.Size(120, 23);
            this.txtMinAmount.TabIndex = 9;
            // 
            // lblMaxAmount
            // 
            this.lblMaxAmount.Location = new System.Drawing.Point(138, 284);
            this.lblMaxAmount.Name = "lblMaxAmount";
            this.lblMaxAmount.Size = new System.Drawing.Size(120, 23);
            this.lblMaxAmount.TabIndex = 10;
            this.lblMaxAmount.Text = "Макс. сумма:";
            this.lblMaxAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaxAmount
            // 
            this.txtMaxAmount.Location = new System.Drawing.Point(141, 310);
            this.txtMaxAmount.Name = "txtMaxAmount";
            this.txtMaxAmount.Size = new System.Drawing.Size(120, 23);
            this.txtMaxAmount.TabIndex = 11;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(15, 350);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(120, 32);
            this.btnGenerate.TabIndex = 12;
            this.btnGenerate.Text = "Сохранить PDF…";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(141, 350);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 32);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(279, 396);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtMaxAmount);
            this.Controls.Add(this.lblMaxAmount);
            this.Controls.Add(this.txtMinAmount);
            this.Controls.Add(this.lblMinAmount);
            this.Controls.Add(this.lbCategories);
            this.Controls.Add(this.lblCategories);
            this.Controls.Add(this.chkAllCategories);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.lblPeriod);
            this.MinimumSize = new System.Drawing.Size(295, 435);
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры отчёта";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
