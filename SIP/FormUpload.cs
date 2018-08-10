using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SIP
{
    public partial class FormUpload : Form
    {
        FirewallSip _security = new FirewallSip();
        protected string pathDB = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(Application.ExecutablePath)) + @"\myconfig.ini";
        protected string _koneksi = "Server={0};Database={1};User Id={2};Password={3};";
        public FormUpload()
        {
            InitializeComponent();
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
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Cari file master SIP";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "CSV files (*.csv*)|*.csv*";
            //fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = fdlg.FileName;
            }

        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(txtFileName.Text);
            string extn = fi.Extension;
            try
            {

                if (extn == ".csv")
                {
                    UploadCsv();
                }

                MessageBox.Show(" DATA BERHASIL DISIMPAN");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void UploadCsv()
        {
            string host = "localhost";
            string user = "root";
            string password = "";
            string database = "sip_absen";
            string ssl = "none";
            string connStr = "server=" + host + ";user=" + user + ";database=" + database + ";password=" + password + ";SslMode=" + ssl + ";";

            string sqlinsert = "";
            string sql_cek_kartu = string.Empty;
            MySqlConnection conn = new MySqlConnection(connStr);

            // Get the data.
            string[,] values = LoadCsv(txtFileName.Text);

            int num_rows = values.GetUpperBound(0) + 1;
            int num_cols = values.GetUpperBound(1) + 1;
            if (num_cols == 29)
            {
                for (int r = 1; r < num_rows; r++)
                {

                    string siswa_id = string.Empty;
                    string siswa_sekolah_id = string.Empty;
                    string siswa_nama = string.Empty;
                    string siswa_kelas_id = string.Empty;
                    string siswa_status = string.Empty;
                    string siswa_nisn = string.Empty;
                    string siswa_jk = string.Empty;
                    string siswa_tempat_lahir = string.Empty;
                    string siswa_tanggal_lahir = string.Empty;
                    string siswa_alamat = string.Empty;
                    string siswa_hp = string.Empty;
                    string nama_panggilan = string.Empty;
                    string siswa_waktu = string.Empty;
                    string siswa_jarak = string.Empty;
                    string siswa_email = string.Empty;
                    string siswa_anak_ke = string.Empty;
                    string siswa_jumlah_sudara = string.Empty;
                    string siswa_kode_pos = string.Empty;
                    string siswa_no_telp = string.Empty;
                    string siswa_no_ijazah = string.Empty;
                    string siswa_nik = string.Empty;
                    string siswa_no_kk = string.Empty;
                    string siswa_nomor_kartu = string.Empty;
                    string siswa_tanggal_langganan = string.Empty;
                    string siswa_kelurahan = string.Empty;
                    string siswa_kecamatan = string.Empty;
                    string siswa_kabupaten = string.Empty;
                    string siswa_provinsi = string.Empty;
                    string siswa_agama = string.Empty;
                    for (int c = 0; c < num_cols; c++)
                    {
                        if (c == 0) { siswa_id = values[r, 0]; }
                        if (c == 1) { siswa_sekolah_id = values[r, 1]; }
                        if (c == 2) { siswa_nama = values[r, 2]; }
                        if (c == 3) { siswa_kelas_id = values[r, 3]; }
                        if (c == 4) { siswa_status = values[r, 4]; }
                        if (c == 5) { siswa_nisn = values[r, 5]; }
                        if (c == 6) { siswa_jk = values[r, 6]; }
                        if (c == 7) { siswa_tempat_lahir = values[r, 7]; }
                        if (c == 8) { siswa_tanggal_lahir = values[r, 8]; }
                        if (c == 9) { siswa_alamat = values[r, 9]; }
                        if (c == 10) { siswa_hp = values[r, 10]; }
                        if (c == 11) { nama_panggilan = values[r, 11]; }
                        if (c == 12) { siswa_waktu = values[r, 12]; }
                        if (c == 13) { siswa_jarak = values[r, 13]; }
                        if (c == 14) { siswa_email = values[r, 14]; }
                        if (c == 15) { siswa_anak_ke = values[r, 15]; }
                        if (c == 16) { siswa_jumlah_sudara = values[r, 16]; }
                        if (c == 17) { siswa_kode_pos = values[r, 17]; }
                        if (c == 18) { siswa_no_telp = values[r, 18]; }
                        if (c == 19) { siswa_no_ijazah = values[r, 19]; }
                        if (c == 20) { siswa_nik = values[r, 20]; }
                        if (c == 21) { siswa_no_kk = values[r, 21]; }
                        if (c == 22) { siswa_nomor_kartu = values[r, 22]; }
                        if (c == 23) { siswa_tanggal_langganan = values[r, 23]; }
                        if (c == 24) { siswa_kelurahan = values[r, 24]; }
                        if (c == 25) { siswa_kecamatan = values[r, 25]; }
                        if (c == 26) { siswa_kabupaten = values[r, 26]; }
                        if (c == 27) { siswa_provinsi = values[r, 27]; }
                        if (c == 28) { siswa_agama = values[r, 28]; }



                        sqlinsert = "INSERT INTO siswa(" +
                            //"siswa_id," +
                            "siswa_sekolah_id," +
                            "siswa_nama," +
                            "siswa_kelas_id," +
                            "siswa_status," +
                            "siswa_nisn," +
                            "siswa_jk," +
                            "siswa_tempat_lahir," +
                            "siswa_tanggal_lahir," +
                            "siswa_alamat," +
                            "siswa_hp," +
                            "nama_panggilan," +
                            "siswa_waktu," +
                            "siswa_jarak," +
                            "siswa_email," +
                            "siswa_anak_ke," +
                            "siswa_jumlah_sudara," +
                            "siswa_kode_pos," +
                            "siswa_no_telp," +
                            "siswa_no_ijazah," +
                            "siswa_nik," +
                            "siswa_no_kk," +
                            "siswa_nomor_kartu," +
                            "siswa_tanggal_langganan," +
                            "siswa_kelurahan," +
                            "siswa_kecamatan," +
                            "siswa_kabupaten," +
                            "siswa_provinsi," +
                            "siswa_agama" +
                            ")" +
                        "VALUES(" +
                            //"'" + siswa_id + "'," +
                            "'" + siswa_sekolah_id + "'," +
                            "'" + siswa_nama + "'," +
                            "'" + siswa_kelas_id + "'," +
                            "'" + siswa_status + "'," +
                            "'" + siswa_nisn + "'," +
                            "'" + siswa_jk + "'," +
                            "'" + siswa_tempat_lahir + "'," +
                            "'" + siswa_tanggal_lahir + "'," +
                            "'" + siswa_alamat + "'," +
                            "'" + siswa_hp + "'," +
                            "'" + nama_panggilan + "'," +
                            "'" + siswa_waktu + "'," +
                            "'" + siswa_jarak + "'," +
                            "'" + siswa_email + "'," +
                            "'" + siswa_anak_ke + "'," +
                            "'" + siswa_jumlah_sudara + "'," +
                            "'" + siswa_kode_pos + "'," +
                            "'" + siswa_no_telp + "'," +
                            "'" + siswa_no_ijazah + "'," +
                            "'" + siswa_nik + "'," +
                            "'" + siswa_no_kk + "'," +
                            "'" + siswa_nomor_kartu + "'," +
                            "'" + siswa_tanggal_langganan + "'," +
                            "'" + siswa_kelurahan + "'," +
                            "'" + siswa_kecamatan + "'," +
                            "'" + siswa_kabupaten + "'," +
                            "'" + siswa_provinsi + "'," +
                            "'" + siswa_agama + "'" +
                           ")";
                    }
                    sql_cek_kartu = "SELECT COUNT(siswa_nomor_kartu) as nomor_kartu FROM siswa where siswa_nomor_kartu=" + siswa_nomor_kartu;
                    if (sqlinsert != string.Empty)
                    {
                        MySqlCommand cek_kartu = conn.CreateCommand();
                        conn.Open();
                        cek_kartu.CommandText = sql_cek_kartu;
                        Int32 jml_kartu = Convert.ToInt32(cek_kartu.ExecuteScalar());
                        conn.Close();
                        if (jml_kartu < 1)
                        {

                            MySqlCommand icmmd = new MySqlCommand(sqlinsert, conn);

                            conn.Open();
                            MySqlDataReader MyReader2;
                            MyReader2 = icmmd.ExecuteReader();
                            while (MyReader2.Read())
                            {
                            }
                            conn.Close();
                        }
                    }
                }
            }
            else
            {
                for (int r = 1; r < num_rows; r++)
                {

                    string guru_id = string.Empty;
                    string guru_email = string.Empty;
                    string guru_jk = string.Empty;
                    string guru_nama = string.Empty;
                    string guru_nip = string.Empty;
                    string guru_nomor_kartu = string.Empty;
                    string guru_phone = string.Empty;
                    string guru_sekolah_id = string.Empty;
                    string guru_status = string.Empty;
                    for (int c = 0; c < num_cols; c++)
                    {
                        if (c == 0) { guru_id = values[r, 0]; }
                        if (c == 1) { guru_sekolah_id = values[r, 1]; }
                        if (c == 2) { guru_nama = values[r, 2]; }
                        if (c == 3) { guru_nip = values[r, 3]; }
                        if (c == 4) { guru_email = values[r, 4]; }
                        if (c == 5) { guru_nomor_kartu = values[r, 5]; }
                        if (c == 6) { guru_phone = values[r, 6]; }
                        if (c == 7) { guru_jk = values[r, 7]; }
                        if (c == 8) { guru_status = values[r, 8]; }
                        sqlinsert = "INSERT INTO guru(" +
                            //"guru_id," +
                            "guru_email," +
                            "guru_jk," +
                            "guru_nama," +
                            "guru_nip," +
                            "guru_nomor_kartu," +
                            "guru_phone," +
                            "guru_sekolah_id," +
                            "guru_status" +
                            ")" +
                        "VALUES(" +
                            //"'" + guru_id + "'," +
                            "'" + guru_email + "'," +
                            "'" + guru_jk + "'," +
                            "'" + guru_nama + "'," +
                            "'" + guru_nip + "'," +
                            "'" + guru_nomor_kartu + "'," +
                            "'" + guru_phone + "'," +
                            "'" + guru_sekolah_id + "'," +
                            "'" + guru_status + "'" +
                           ")";
                    }
                    sql_cek_kartu = "SELECT COUNT(guru_nomor_kartu) as nomor_kartu FROM guru where guru_nomor_kartu=" + guru_nomor_kartu;

                    if (sqlinsert != string.Empty)
                    {
                        MySqlCommand cek_kartu = conn.CreateCommand();
                        conn.Open();
                        cek_kartu.CommandText = sql_cek_kartu;
                        Int32 jml_kartu = Convert.ToInt32(cek_kartu.ExecuteScalar());
                        conn.Close();
                        if (jml_kartu < 1)
                        {

                            MySqlCommand icmmd = new MySqlCommand(sqlinsert, conn);

                            conn.Open();
                            MySqlDataReader MyReader2;
                            MyReader2 = icmmd.ExecuteReader();
                            while (MyReader2.Read())
                            {
                            }
                            conn.Close();
                        }
                    }
                }
            }
        }
        private string[,] LoadCsv(string filename)
        {
            // Get the file's text.
            string whole_file = File.ReadAllText(filename);

            // Split into lines.
            whole_file = whole_file.Replace('\n', '\r');
            whole_file = whole_file.Replace("\"", "");
            whole_file = whole_file.Replace("\'", "`");
            string[] lines = whole_file.Split(new char[] { '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            // See how many rows and columns there are.
            int num_rows = lines.Length;
            int num_cols = lines[0].Split(',').Length;

            // Allocate the data array.
            string[,] values = new string[num_rows, num_cols];

            // Load the array.
            for (int r = 0; r < num_rows; r++)
            {
                string[] line_r = lines[r].Split(',');
                for (int c = 0; c < num_cols; c++)
                {
                    values[r, c] = line_r[c];
                }
            }

            // Return the values.
            return values;
        }
    }
}
