using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIP
{
    public partial class FormCreate : Form
    {
        protected string path = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(Application.ExecutablePath)) + @"\myconfig.ini";
        protected string _koneksi = "Server={0};Database={1};User Id={2};Password={3};";
        protected string _database = "sip";
        protected FirewallSip _security = new FirewallSip();
        protected string _serverName = string.Empty;
        protected string _password = string.Empty;
        protected string _user = string.Empty;
        protected string pathDB = "C:\\";
        public FormCreate()
        {
            InitializeComponent();
        }



        private void btnCreate_Click(object sender, EventArgs e)
        {
            string subPath = pathDB + "Database SIP"; // your code goes here

            bool exists = System.IO.Directory.Exists(subPath);

            if (!exists)
                System.IO.Directory.CreateDirectory(subPath);

            if (DatabaseisExist() == true)
            {
                MessageBox.Show(" DATABASE TELAH TERDAFTAR", "INFO SIP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Koneksi();
                CreateDatabase(subPath);
            }
        }

        private void CreateDatabase(string subPath)
        {
            System.Data.SqlClient.SqlConnection tmpConn;
            string sqlCreateDBQuery;
            tmpConn = new SqlConnection();
            tmpConn.ConnectionString = "SERVER = " + _serverName +
                                 "; DATABASE = master; User ID =" + _user + "; Pwd =" + _password + ";";
            sqlCreateDBQuery = " CREATE DATABASE "
                               + _database
                               + " ON PRIMARY "
                               + " (NAME = " + _database + ", "
                               + " FILENAME = '" + subPath + "\\" + "sip.mdf" + "', "
                               + " SIZE = 10MB,"
                               + " FILEGROWTH =" + "10%" + ") "
                               + " LOG ON (NAME =" + _database + "_Log" + ", "
                               + " FILENAME = '" + subPath + "\\" + "siplog.ldf" + "', "
                               + " SIZE = 10MB, "
                               + " FILEGROWTH =" + "10%" + ") ";
            SqlCommand myCommand = new SqlCommand(sqlCreateDBQuery, tmpConn);
            try
            {
                tmpConn.Open();
                myCommand.ExecuteNonQuery();
                tmpConn.Close();


                // CREATE TABLE
                SqlConnection tmpConnTable = new SqlConnection();
                tmpConnTable.ConnectionString = Koneksi();
                tmpConnTable.Open();

                string table_absen = "CREATE TABLE [dbo].[absen]([absen_id][varchar](50) NOT NULL,[absen_sekolah_id] [varchar](50) NULL,[absen_nomor_kartu][varchar](50) NULL," +
                                     "[absen_kal_akademik_id][varchar](50) NULL,[absen_status][varchar](50) NULL,[absen_group][varchar](50) NULL,[absen_tanggal][date]NULL," +
                                     "[absen_masuk][time](7) NULL,[absen_keluar][time](7) NULL,[absen_device][varchar](50) NULL,[InsertAt][datetime] NULL, CONSTRAINT[PK_absen] PRIMARY KEY CLUSTERED" +
                                     "([absen_id] ASC )WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]" +
                                     ") ON[PRIMARY]";
                SqlCommand command_absen = new SqlCommand(table_absen, tmpConnTable);
                command_absen.ExecuteNonQuery();

                string table_guru = "CREATE TABLE [dbo].[guru]([guru_id][int] NOT NULL, [guru_sekolah_id] [varchar](50) NULL,[guru_nama][varchar](50) NULL, [guru_nip][varchar](50) NULL," +
                                    "[guru_email][varchar](50) NULL,[guru_nomor_kartu][varchar](50) NULL,[guru_phone][varchar](50) NULL,[guru_jk][varchar](50) NULL,[guru_status][varchar](50) NULL," +
                                    "CONSTRAINT[PK_guru] PRIMARY KEY CLUSTERED ([guru_id] ASC)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]" +
                                    ") ON[PRIMARY]";

                SqlCommand command_guru = new SqlCommand(table_guru, tmpConnTable);
                command_guru.ExecuteNonQuery();


                string table_mesin_log = "CREATE TABLE [dbo].[mesin_absen_log]([log_mesin_absen_id][varchar](50) NOT NULL,[log_mesin_status] [int] NULL,[log_mesin_tgl][date]NULL," +
                                         " CONSTRAINT[PK_mesin_absen_log] PRIMARY KEY CLUSTERED ([log_mesin_absen_id] ASC" +
                                         ")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY]";

                SqlCommand command_mesin_log = new SqlCommand(table_mesin_log, tmpConnTable);
                command_mesin_log.ExecuteNonQuery();

                string table_mesin_absensi = "CREATE TABLE [dbo].[mesin_absensi]([mesinabsen_id][varchar](50) NOT NULL,[mesinabsen_nomor] [varchar](50) NULL,[mesinabsen_ip][varchar](50) NULL," +
                                        "[mesinabsen_token][varchar](50) NULL,[mesinabsen_keterangan][varchar](50) NULL, [mesinabsen_sekolah_id][varchar](50) NULL,CONSTRAINT[PK_mesin_absensi] PRIMARY KEY CLUSTERED([mesinabsen_id] ASC" +
                                        ")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY]";

                SqlCommand command_mesin_absensi = new SqlCommand(table_mesin_absensi, tmpConnTable);
                command_mesin_absensi.ExecuteNonQuery();

                string table_sekolah = "CREATE TABLE [dbo].[sekolah]([sekolah_id][nchar](10) NOT NULL,[nama_sekolah] [varchar](150) NULL,[alamat][varchar](150) NULL," +
                                       "CONSTRAINT[PK_sekolah] PRIMARY KEY CLUSTERED ([sekolah_id] ASC" +
                                       ")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY]";

                SqlCommand command_sekolah = new SqlCommand(table_sekolah, tmpConnTable);
                command_sekolah.ExecuteNonQuery();

                string table_siswa = "CREATE TABLE [dbo].[siswa]([siswa_id][varchar](50) NOT NULL,[siswa_sekolah_id] [varchar](50) NULL,[siswa_nama][varchar](50) NULL," +
                    "[siswa_kelas_id][varchar](50) NULL,[siswa_status][varchar](50) NULL,[siswa_nisn][varchar](50) NULL,[siswa_jk][varchar](50) NULL,[siswa_tempat_lahir][varchar](50) NULL," +
                    "[siswa_tanggal_lahir][varchar](50) NULL,[siswa_alamat][varchar](50) NULL,[siswa_hp][varchar](50) NULL,[nama_panggilan][varchar](50) NULL,[siswa_waktu] [varchar](50) NULL," +
                    "[siswa_jarak][varchar](50) NULL,[siswa_email][varchar](50) NULL,[siswa_anak_ke][varchar](50) NULL,[siswa_jumlah_sudara][varchar](50) NULL,[siswa_kode_pos][varchar](50) NULL," +
                    "[siswa_no_telp][varchar](50) NULL,[siswa_no_ijazah][varchar](50) NULL,[siswa_nik][varchar](50) NULL,[siswa_no_kk][varchar](50) NULL,[siswa_nomor_kartu][varchar](50) NULL," +
                    "[siswa_tanggal_langganan][varchar](50) NULL,[siswa_kelurahan][varchar](50) NULL,[siswa_kecamatan][varchar](50) NULL,[siswa_kabupaten][varchar](50) NULL,[siswa_provinsi][varchar](50) NULL,[siswa_agama][varchar](50) NULL, CONSTRAINT[PK_siswa] PRIMARY KEY CLUSTERED ([siswa_id] ASC" +
                    ")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY] ) ON[PRIMARY]";

                SqlCommand command_siswa = new SqlCommand(table_siswa, tmpConnTable);
                command_siswa.ExecuteNonQuery();

                tmpConnTable.Close();

                MessageBox.Show("Database has been created successfully!",
                                  "Create Database", MessageBoxButtons.OK,
                                              MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Create Database",
                                            MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
            }

        }

        public Boolean DatabaseisExist()
        {
            String connString = ("Data Source =" + (_serverName + "; Initial Catalog = master; Integrated Security = True;"));
            String cmdText = ("select* from master.dbo.sysdatabases where name =\'" + (_database + "\'"));
            Boolean bRet;

            System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(connString);
            System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand(cmdText, sqlConnection);

            try
            {
                sqlConnection.Open();
                System.Data.SqlClient.SqlDataReader reader = sqlCmd.ExecuteReader();
                bRet = reader.HasRows;
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                bRet = false;
                sqlConnection.Close();
                MessageBox.Show(e.Message);
                return false;
            } //End Try Catch Block


            if (bRet == true)
            {
                //MessageBox.Show("DATABASE EXISTS");
                return true;
            }
            else
            {
                //MessageBox.Show("DATABASE DOES NOT EXIST");
                return false;
            } //END OF IF


        } //END FUNCTION
        protected string Koneksi()
        {
            string server = string.Empty;
            string user = string.Empty;
            string password = string.Empty;
            string database = string.Empty;
            string windows = string.Empty;

            try
            {
                List<string> element = new List<string>();
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (TextReader r = new StreamReader(fs))
                    {
                        int Count = 1;
                        string line = r.ReadLine();
                        while (line != null)
                        {
                            element.Add(line);
                            line = r.ReadLine();
                            Count++;
                        }
                    }
                }

                server = _security.Decrypt(element[0], true);
                database = _security.Decrypt(element[1], true);
                user = _security.Decrypt(element[2], true);
                password = _security.Decrypt(element[3], true);

                _serverName = server;
                _password = password;
                _user = user;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return string.Format(_koneksi, server, database, user, password);
        }
    }
}
