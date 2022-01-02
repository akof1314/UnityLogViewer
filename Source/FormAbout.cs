using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Forms;

namespace LogViewer
{
    public partial class FormAbout : DarkForm
    {
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public FormAbout()
        {
            InitializeComponent();

            lblApp.Text = Application.ProductName;
            lblVer.Text = "v" + Application.ProductVersion;
        }
        #endregion


        #region Button Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion

        private void FormAbout_Load(object sender, System.EventArgs e)
        {
            this.linkLabel1.Visible = false;
            Task.Run((Action) RequestNew);
        }

        private void RequestNew()
        {
            try
            {
                System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://api.github.com/repos/akof1314/UnityLogViewer/releases/latest");
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0; QQWubi 133; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; CIBA; InfoPath.2)";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                if (string.IsNullOrEmpty(content))
                {
                    return;
                }
                string findStr = "\"tag_name\"";
                int pos = content.IndexOf(findStr, StringComparison.Ordinal);
                if (pos > -1)
                {
                    int pos3 = pos + findStr.Length + 2;
                    int pos2 = content.IndexOf("\"", pos3, StringComparison.Ordinal);
                    if (pos2 > -1)
                    {
                        string ver = content.Substring(pos3, pos2 - pos3);
                        this.BeginInvoke(new Action(() =>
                        {
                            this.linkLabel1.Visible = true;
                            this.linkLabel1.Text = ver;
                        }));
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/akof1314/UnityLogViewer/releases");
        }
    }
}
