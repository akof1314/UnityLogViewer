using System;
using System.Windows.Forms;
using DarkUI.Forms;
using woanware;

namespace LogViewer
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FormGoToLine : DarkForm
    {
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public FormGoToLine()
        {
            InitializeComponent();
        }
        #endregion

        #region Button Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textLineNum.Text.Trim().Length == 0)
            {
                DarkMessageBox.ShowError( "The line number must be entered", String.Empty);
                textLineNum.Select();
                return;
            }

            if (Misc.IsNumber(textLineNum.Text) == false)
            {
                DarkMessageBox.ShowError( "The line number value is invalid", String.Empty);
                textLineNum.Select();
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int LineNumber
        {
            get
            {
                return Convert.ToInt32(textLineNum.Text);
            }
        }
        #endregion
    }
}
