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
    public partial class FormSetAbsen : Form
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

        public FormSetAbsen(FormSIP frm)
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
            string connStr = "server=" + host + ";user=" + user + ";database=" + database + ";password=" + password + ";SslMode=" + ssl + ";";
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlCommand dbcmd = conn.CreateCommand();
            string sqlcount = "SELECT COUNT(*) FROM waktu_absen";

            conn.Open();

            dbcmd.CommandText = sqlcount;

            Int32 count = Convert.ToInt32(dbcmd.ExecuteScalar()); //proses menghitung jumlah data(count)

            conn.Close();

            if (count==0)
            {
                string sqlinsert = "insert into waktu_absen(mulai_masuk, mulai_selesai, pulang_masuk, pulang_selesai) " + 
                    "values('" + mulai_masuk.Text + "','" + selesai_masuk.Text + "','" + mulai_pulang.Text + "','" + selesai_pulang.Text + "');";
                dbcmd.CommandText = sqlinsert;

                try
                {
                    
                    MySqlDataReader MyReader2;
                    conn.Open();
                    MyReader2 = dbcmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                    MessageBox.Show("Settingan Absen Berhasil Disimpan");

                    conn.Close();
                   
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if(count == 1)
            {
                MessageBox.Show("Data Setingan Absen telah disetting. Silahkan kontak admin jika ingin merubah data setingan");
            }
        }
        private void FormSekolah_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.frm.Load_USB();
        }

        private void txtKode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
