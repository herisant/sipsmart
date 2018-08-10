using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIP
{
    public partial class FormSettings : Form
    {
        FirewallSip _security = new FirewallSip();
        protected string path = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(Application.ExecutablePath)) + @"\myconfig.ini";

        FormSIP frm;
        public FormSettings(FormSIP frm)
        {
            InitializeComponent();
            this.frm = frm;
            ReadFile();
        }


        protected void ReadFile()
        {
            try
            {
                string server = string.Empty;
                string database = string.Empty;
                string user = string.Empty;
                string password = string.Empty;

                List<string> element = new List<string>();
                var list = new List<string>();
                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        element.Add(line);
                    }
                }

                server = _security.Decrypt(element[0], true);
                database = _security.Decrypt(element[1], true);
                user = _security.Decrypt(element[2], true);
                password = _security.Decrypt(element[3], true);


                txtServer.Text = server;
                txtDatabase.Text = database;
                txtUser.Text = user;
                txtPassword.Text = password;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR BACA FILE : " + ex.Message);
            }
        }


        private void btnCANCEL_Click(object sender, EventArgs e)
        {
            this.frm.Load_USB();
            Close();
        }

        //protected void getServerName()
        //{
        //    DataTable table = SqlDataSourceEnumerator.Instance.GetDataSources();

        //    foreach (DataRow server in table.Rows)
        //    {
        //        cmbServer.Items.Add(server[table.Columns["ServerName"]].ToString());
        //    }
        //}

        private void btnLOGIN_Click(object sender, EventArgs e)
        {
            string serverName = string.Empty;
            string database = string.Empty;
            string user = string.Empty;
            string password = string.Empty;

            if (string.IsNullOrEmpty(txtServer.Text))
            {
                MessageBox.Show("Server Name masih kosong");
                return;
            }

            if (string.IsNullOrEmpty(txtDatabase.Text))
            {
                MessageBox.Show("Database masih kosong");
                return;
            }


            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("User masih kosong");
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Password masih kosong");
                return;
            }


            // CEK FILE TERLEBIH DAHULU
            serverName = txtServer.Text;
            database = txtDatabase.Text;
            user = txtUser.Text;
            password = txtPassword.Text;

            using (StreamWriter writetext = new StreamWriter(path))
            {
                writetext.WriteLine(_security.Encrypt(serverName, true));
                writetext.WriteLine(_security.Encrypt(database, true));
                writetext.WriteLine(_security.Encrypt(user, true));
                writetext.WriteLine(_security.Encrypt(password, true));
            }

            MessageBox.Show("SUCCESS", "INFO SIP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }
    }
}
