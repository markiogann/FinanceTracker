using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using FinanceTracker.Classes.UI;

namespace FinanceTracker.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            try { Theme.Apply(this); } catch { }
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            var v = Assembly.GetExecutingAssembly().GetName().Version;
            lblTitle.Text = "FinanceTracker";
            lblVersion.Text = "Версия: " + (v != null ? v.ToString() : "1.0");
            lblAuthor.Text = "Автор: Иоганн Марк Антонович";
            lblEmail.Text = "Почта:";
            linkMail.Text = "mark.iogann@yandex.ru";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try { Process.Start("mailto:mark@example.com"); } catch { }
        }
    }
}
