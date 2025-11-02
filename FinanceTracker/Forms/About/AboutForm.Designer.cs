namespace FinanceTracker.Forms
{
    partial class AboutForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.LinkLabel linkMail;
        private System.Windows.Forms.Button btnOk;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.linkMail = new System.Windows.Forms.LinkLabel();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(360, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "FinanceTracker";
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(12, 45);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(360, 23);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Версия: 1.0";
            // 
            // lblAuthor
            // 
            this.lblAuthor.Location = new System.Drawing.Point(12, 68);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(360, 23);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "Автор: Марк Иоганн";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(12, 91);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Почта:";
            // 
            // linkMail
            // 
            this.linkMail.Location = new System.Drawing.Point(60, 91);
            this.linkMail.Name = "linkMail";
            this.linkMail.Size = new System.Drawing.Size(312, 23);
            this.linkMail.TabIndex = 4;
            this.linkMail.TabStop = true;
            this.linkMail.Text = "mark@example.com";
            this.linkMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMail_LinkClicked);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(286, 128);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 30);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(384, 171);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.linkMail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblTitle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 210);
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "О программе";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.ResumeLayout(false);

        }
    }
}
