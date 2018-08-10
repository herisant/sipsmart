using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SIP
{
    public partial class FormWebService : Form
    {
        protected FirewallSip _security = new FirewallSip();
        protected string pathAbsen = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(Application.ExecutablePath)) + @"\WebService\absen.sip";
        protected string pathHost = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(Application.ExecutablePath)) + @"\WebService\host.sip";

        FormSIP frm;
        public FormWebService(FormSIP frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAbsen.Text))
            {
                if (File.Exists(pathAbsen))
                {
                    File.Delete(pathAbsen);

                    using (StreamWriter sw = File.CreateText(pathAbsen))
                    {
                        sw.WriteLine(_security.Encrypt(txtAbsen.Text, true));
                    }
                }
                else
                {
                    using (StreamWriter sw = File.CreateText(pathAbsen))
                    {
                        sw.WriteLine(_security.Encrypt(txtAbsen.Text, true));
                    }
                }
            }

            if (!string.IsNullOrEmpty(txtMasterData.Text))
            {
                if (File.Exists(pathHost))
                {
                    File.Delete(pathHost);

                    using (StreamWriter sw = File.CreateText(pathHost))
                    {
                        sw.WriteLine(_security.Encrypt(txtMasterData.Text, true));
                    }
                }
                else
                {
                    using (StreamWriter sw = File.CreateText(pathHost))
                    {
                        sw.WriteLine(_security.Encrypt(txtMasterData.Text, true));
                    }
                }
            }

            MessageBox.Show("SUKSES", "INFO SIP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void FormWebService_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.frm.Load_USB();
        }
    }
}
