using System.Drawing;
using System.Windows.Forms;

namespace FinanceTracker.Classes.UI
{
    public static class Theme
    {
        public static readonly Color BgMain = Color.WhiteSmoke;
        public static readonly Color Accent = Color.FromArgb(221, 160, 221);
        public static readonly Color AccentSoft = Color.FromArgb(216, 191, 216);
        public static readonly Color Border = Color.FromArgb(200, 200, 200);
        public static readonly Color ButtonBg = Color.White;
        public static readonly Color ButtonBgHover = Color.FromArgb(245, 245, 245);

        public static readonly Font BaseFont = new Font("Segoe UI", 10.0f, FontStyle.Regular);
        public static readonly Font BoldFont = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold);

        public static void Apply(Control root)
        {
            if (root == null) return;

            root.Font = BaseFont;
            root.BackColor = BgMain;

            foreach (Control c in root.Controls)
            {
                StyleControl(c);
                Apply(c);
            }
        }

        private static void StyleControl(Control c)
        {
            if (c is Button btn)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Border;
                btn.FlatAppearance.MouseOverBackColor = ButtonBgHover;
                btn.BackColor = ButtonBg;
                btn.Font = BoldFont;
            }
            else if (c is Panel p)
            {
                p.BackColor = Color.White;
            }
            else if (c is DataGridView grid)
            {
                grid.BackgroundColor = Color.White;
                grid.EnableHeadersVisualStyles = false;
                grid.ColumnHeadersDefaultCellStyle.BackColor = AccentSoft;
                grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                grid.ColumnHeadersDefaultCellStyle.Font = BoldFont;
                grid.GridColor = Border;

                grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
                grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 210, 240);
                grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
            else if (c is Label lbl)
            {
                lbl.Font = BoldFont;
            }
            else if (c is GroupBox gb)
            {
                gb.Font = BoldFont;
                gb.BackColor = Color.White;
            }
        }
    }
}
