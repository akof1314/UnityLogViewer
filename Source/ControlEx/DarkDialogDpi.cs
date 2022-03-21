using System;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Forms;

namespace LogViewer.ControlEx
{
    public class DarkDialogDpi : DarkDialog
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AutoScaleMode = AutoScaleMode.Dpi;
            btnOk.Text = "确定";
            btnOk.AutoSize = true;
            btnCancel.Text = "取消";
            btnCancel.AutoSize = true;

            var pnl = btnOk.Parent.Parent;
            pnl.Size = new Size(767, Convert.ToInt32(56 * pnl.DeviceDpi / 96f));
        }
    }

    public class DarkMessageBoxDpi : DarkMessageBox
    {
        public DarkMessageBoxDpi(
            string message,
            string title,
            DarkMessageBoxIcon icon,
            DarkDialogButton buttons)
            : base(message, title, icon, buttons)
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AutoScaleMode = AutoScaleMode.Dpi;
            btnOk.Text = "确定";
            btnOk.AutoSize = true;
            btnCancel.Text = "取消";
            btnCancel.AutoSize = true;

            var pnl = btnOk.Parent.Parent;
            pnl.Size = new Size(767, Convert.ToInt32(56 * pnl.DeviceDpi / 96f));

            Size = new Size(Convert.ToInt32(Size.Width * DeviceDpi / 96f), Convert.ToInt32(Size.Height * DeviceDpi / 96f));
        }
    }
}
