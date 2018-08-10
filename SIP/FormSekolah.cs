using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIP
{
    public partial class FormSekolah : Form
    {
        FormSIP frm;
        string _koneksi = "Server={0};Database={1};User Id={2};Password={3};";
        protected string pathDB = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(Application.ExecutablePath)) + @"\myconfig.ini";
        protected FirewallSip _security = new FirewallSip();

        string host = "localhost";
        string user = "root";
        string password = "";
        string database = "sip_absen";
        string ssl = "none";

        public FormSekolah(FormSIP frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        protected string Koneksi()
        {
            string server = string.Empty;
            string database = string.Empty;
            string user = string.Empty;
            string password = string.Empty;

            List<string> element = new List<string>();
            var list = new List<string>();
            var fileStream = new FileStream(pathDB, FileMode.Open, FileAccess.Read);
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

            return string.Format(_koneksi, server, database, user, password);
        }
        private void btnSimpanIdentitas_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtKode.Text))
            {
                MessageBox.Show("Kode Sekolah masih kosong", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtKode.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtNama.Text))
            {
                MessageBox.Show("Nama Sekolah masih kosong", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNama.Focus();
                return;
            }

            string connStr = "server=" + host + ";user=" + user + ";database=" + database + ";password=" + password + ";SslMode=" + ssl + ";";
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlCommand dbcmd = conn.CreateCommand();
            string sqlcount = "SELECT COUNT(*) FROM sekolah";

            conn.Open();

            dbcmd.CommandText = sqlcount;

            Int32 count = Convert.ToInt32(dbcmd.ExecuteScalar()); //proses menghitung jumlah data(count)

            conn.Close();

            if (count==0)
            {
                string sqlinsert = "insert into sekolah(sekolah_id, nama_sekolah, alamat) " + 
                    "values('" + txtKode.Text + "','" + txtNama.Text + "','-');";
                dbcmd.CommandText = sqlinsert;

                try
                {
                    
                    MySqlDataReader MyReader2;
                    conn.Open();
                    MyReader2 = dbcmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                    MessageBox.Show("Data Sekolah Berhasil Disimpan");

                    conn.Close();
                   
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if(count == 1)
            {
                MessageBox.Show("Data sekolah telah disetting. Silahkan kontak admin jika ingin merubah data sekolah");
            }

            /*AbsensiDataContext dc = new AbsensiDataContext(Koneksi());
            dc.CommandTimeout = 0;

            var skl = from sk in dc.sekolahs
                      select sk;

            foreach(var item in skl)
            {
                dc.sekolahs.DeleteOnSubmit(item);
            }

            sekolah itm = new SIP.sekolah();
            itm.sekolah_id = txtKode.Text;
            itm.nama_sekolah = txtNama.Text;

            dc.sekolahs.InsertOnSubmit(itm);
            dc.SubmitChanges();
            dc.Dispose();

            this.Close();*/
        }
        private void FormSekolah_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.frm.Load_USB();
        }

        private void txtKode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
