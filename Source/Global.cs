using System;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Forms;

namespace LogViewer
{
    public class Global
    {
        #region Enums
        /// <summary>
        /// 
        /// </summary>
        public enum SearchType
        {
            SubStringCaseInsensitive = 0,
            SubStringCaseSensitive = 1,
            RegexCaseInsensitive = 2,
            RegexCaseSensitive = 3,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ViewMode
        {
            Standard = 1,
            FilterShow = 2,
            FilterHide = 3
        }

        public enum LogType
        {
            None = 0,
            Info = 1,
            Warning = 2,
            Error = 4,
        }
        #endregion

        public static DialogResult ShowErrorDialog(
            string message)
        {
            using (DarkMessageBox darkMessageBox = new DarkMessageBox(message, "提示", DarkMessageBoxIcon.Error, DarkDialogButton.Ok))
            {
                darkMessageBox.AutoScaleMode = AutoScaleMode.Dpi;
                foreach (Control control in darkMessageBox.Controls)
                {
                    if (control.Name == "pnlFooter")
                    {
                        Panel pnlFooter = (Panel) control;
                        if (pnlFooter != null)
                        {
                            pnlFooter.Size = new Size(pnlFooter.Size.Width, Convert.ToInt32(56 * pnlFooter.DeviceDpi / 96f));
                        }

                        foreach (Control pnlFooterControl in pnlFooter.Controls)
                        {
                            if (pnlFooterControl.Name == "flowInner")
                            {
                                foreach (Control flowInnerControl in pnlFooterControl.Controls)
                                {
                                    if (flowInnerControl.Name == "btnOk")
                                    {
                                        flowInnerControl.Text = "确定";
                                        flowInnerControl.AutoSize = true;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
                return darkMessageBox.ShowDialog();
            }
        }
    }
}
