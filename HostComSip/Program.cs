using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Collections.Specialized;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace HostComSip
{
    class Program
    {
        static bool ubsenMasukBool = false;
        static bool ubsenKeluarBool = false;

        static string host = "localhost";
        static string user = "root";
        static string password = "";
        static string database = "sip_absen";
        static string ssl = "none";

        static FirewallSip _security = new FirewallSip();
        static string pathHost = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(Application.ExecutablePath)) + @"\WebService\absen.sip";
       // static string pathDB = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(Application.ExecutablePath)) + @"\myconfig.ini";
        //static string _koneksi = "Server={0};Database={1};User Id={2};Password={3};";
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " start HostCommSip ..");
            Console.WriteLine("");

            while (true)
            {
                try
                {
                    if (ubsenMasukBool == false)
                    {
                        UploadAbsensiMasuk();
                    }
                    if (ubsenKeluarBool == false)
                    {
                        UploadAbsensiKeluar();
                    }

                    System.Threading.Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Void Main " + ex.Message);
                }
            }
        }
        static string ReadURL()
        {
            using (StreamReader sr = new StreamReader(pathHost))
            {
                //Console.WriteLine(_security.Decrypt(sr.ReadToEnd(), true));
                //Console.ReadKey();
                return _security.Decrypt(sr.ReadToEnd(), true);
            }
        }
        static async void UploadAbsensiMasuk()
        {
            ubsenMasukBool = true;

            string usernameUrl = "pro6";
            string passwordUrl = "pro6Ci-adminLte";

            string connStr = "server=" + host + ";user=" + user + ";database=" + database + ";password=" + password + ";SslMode=" + ssl + ";";
            MySqlConnection conn = new MySqlConnection(connStr);
            
            MySqlCommand dbcmd = conn.CreateCommand();
            try

            {
                int i = 1;
                string sqlselect = "SELECT siswa.siswa_nama, siswa.siswa_nomor_kartu, absen.absen_id, absen.absen_tanggal, absen.absen_masuk, absen.absen_keluar, absen.absen_tanggal";
                string sqldata = "FROM absen LEFT JOIN siswa ON siswa.siswa_nomor_kartu = absen.absen_nomor_kartu where absen.upload_masuk='0';";
                dbcmd.CommandText = sqlselect + " " + sqldata;

                var dt = new DataTable("absen");
                conn.Open();
                var r = dbcmd.ExecuteReader();

                dt.Load(r);

                foreach (DataRow baris in dt.Rows)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://35.190.172.58:11960/api/absen/insert");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", usernameUrl, passwordUrl)));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                        DateTime dateValuess = Convert.ToDateTime(baris["absen_tanggal"]);
                        string tanggalabsen = dateValuess.ToString("yyyy-MM-dd");

                        var yourPostedObject = new object();
                        var values = new Dictionary<string, string>
                        {
                             { "nomorMesin", id_sekolah() },
                             { "nomorKartu", baris["siswa_nomor_kartu"].ToString() },
                             { "waktuPresensi", tanggalabsen+" "+baris["absen_masuk"].ToString() }

                        };

                        string json = JsonConvert.SerializeObject(values, Formatting.Indented);

                        //Console.WriteLine(json);

                        string postData = JsonConvert.SerializeObject(values.ToString());

                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var response = client.PostAsync("http://35.190.172.58:11960/api/absen/insert", content).Result;

                        var responseString = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " Upload data siswa to server : " + baris["absen_id"].ToString());
                        Console.WriteLine("");

                        //Console.WriteLine(id_sekolah()+"/"+ baris["siswa_nomor_kartu"].ToString()+"/"+ tanggalabsen + " " + baris["absen_masuk"].ToString());

                        //Console.WriteLine(postData);

                        Dictionary<string, Object> Items = JsonConvert.DeserializeObject<Dictionary<string, Object>>(responseString);
                        foreach (KeyValuePair<string, Object> itm in Items)
                        {
                            //Console.WriteLine(tanggalabsen + " " + baris["absen_masuk"].ToString());
                            if (itm.Key == "sukses")
                            {
                                
                                if (itm.Value.ToString() == "1")
                                {
                                    Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " Upload data siswa to server : " + baris["absen_id"].ToString() + " sukses");
                                    Console.WriteLine("Masuk");

                                    Update_status_absen_masuk(baris["absen_id"].ToString());
                                }
                                else
                                {
                                    Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " Upload data siswa to server : " + baris["absen_id"].ToString() + " gagal");
                                    Console.WriteLine("");
                                }
                            }
                        }
                        
                    }
                }

                r.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Absen Masuk " + ex.Message);
            }


            ubsenMasukBool = false;


        }

        static async void UploadAbsensiMasukOri()
        {
            ubsenMasukBool = true;

            string usernameUrl = "pro6";
            string passwordUrl = "pro6Ci-adminLte";

            string connStr = "server=" + host + ";user=" + user + ";database=" + database + ";password=" + password + ";SslMode=" + ssl + ";";
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlCommand dbcmd = conn.CreateCommand();
            try

            {

                int i = 1;
                string sqlselect = "SELECT siswa.siswa_nama, siswa.siswa_nomor_kartu, absen.absen_id, absen.absen_tanggal, absen.absen_masuk, absen.absen_keluar, absen.absen_tanggal";
                string sqldata = "FROM absen LEFT JOIN siswa ON siswa.siswa_nomor_kartu = absen.absen_nomor_kartu where absen.upload_masuk='0';";
                dbcmd.CommandText = sqlselect + " " + sqldata;

                var dt = new DataTable("absen");
                conn.Open();
                var r = dbcmd.ExecuteReader();

                dt.Load(r);

                foreach (DataRow baris in dt.Rows)
                {

                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://35.190.172.58:11960/api/absen/insert");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", usernameUrl, passwordUrl)));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                        DateTime dateValuess = Convert.ToDateTime(baris["absen_tanggal"]);
                        string tanggalabsen = dateValuess.ToString("yyyy-MM-dd");

                        var yourPostedObject = new object();
                        var values = new Dictionary<string, string>
                        {
                             { "nomorMesin", id_sekolah() },
                             { "nomorKartu", baris["siswa_nomor_kartu"].ToString() },
                             { "waktuPresensi", tanggalabsen+" "+baris["absen_masuk"].ToString() }

                        };

                        string postData = JsonConvert.SerializeObject(values.ToString());

                        var content = new FormUrlEncodedContent(values);
                        var response = await client.PostAsync("http://35.190.172.58:11960/api/absen/insert", content);

                        var responseString = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " Upload data siswa to server : " + baris["absen_id"].ToString());
                        Console.WriteLine("");

                        //Console.WriteLine(id_sekolah()+"/"+ baris["siswa_nomor_kartu"].ToString()+"/"+ tanggalabsen + " " + baris["absen_masuk"].ToString());

                        Console.WriteLine(postData);

                        Dictionary<string, Object> Items = JsonConvert.DeserializeObject<Dictionary<string, Object>>(responseString);
                        foreach (KeyValuePair<string, Object> itm in Items)
                        {
                            //Console.WriteLine(tanggalabsen + " " + baris["absen_masuk"].ToString());
                            if (itm.Key == "sukses")
                            {

                                if (itm.Value.ToString() == "1")
                                {
                                    Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " Upload data siswa to server : " + baris["absen_id"].ToString() + " sukses");
                                    Console.WriteLine("");

                                    Update_status_absen_masuk(baris["absen_id"].ToString());
                                }
                                else
                                {
                                    Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " Upload data siswa to server : " + baris["absen_id"].ToString() + " gagal");
                                    Console.WriteLine("");
                                }
                            }
                        }



                    }
                }

                r.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Absen Masuk " + ex.Message);
            }


            ubsenMasukBool = false;


        }

        static async void UploadAbsensiKeluar()
        {
            ubsenKeluarBool = true;
            try

            {
                string usernameUrl = "pro6";
                string passwordUrl = "pro6Ci-adminLte";

                string connStr = "server=" + host + ";user=" + user + ";database=" + database + ";password=" + password + ";SslMode=" + ssl + ";";
                MySqlConnection conn = new MySqlConnection(connStr);

                int i = 1;
                MySqlCommand dbcmd = conn.CreateCommand();
                string sqlselect = "SELECT siswa.siswa_nama, siswa.siswa_nomor_kartu, absen.absen_id, absen.absen_tanggal, absen.absen_masuk, absen.absen_keluar, absen.absen_tanggal";
                string sqldata = "FROM absen LEFT JOIN siswa ON siswa.siswa_nomor_kartu = absen.absen_nomor_kartu where upload_masuk='1' and upload_keluar='0' and absen_keluar IS NOT NULL ;";
                dbcmd.CommandText = sqlselect + " " + sqldata;

                var dt = new DataTable("absen");
                conn.Open();
                var r = dbcmd.ExecuteReader();

                dt.Load(r);


                foreach (DataRow baris in dt.Rows)
                {

                    using (HttpClient client = new HttpClient())
                    {
                   
                        client.BaseAddress = new Uri("http://35.190.172.58:11960/api/absen/insert");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", usernameUrl, passwordUrl)));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                        DateTime dateValuess = Convert.ToDateTime(baris["absen_tanggal"]);
                        string tanggalabsen = dateValuess.ToString("yyyy-MM-dd");

                        var yourPostedObject = new object();
                        var values = new Dictionary<string, string>
                        {
                             { "nomorMesin", id_sekolah() },
                             { "nomorKartu", baris["siswa_nomor_kartu"].ToString() },
                             { "waktuPresensi", tanggalabsen+" "+baris["absen_keluar"].ToString() }
                        };

                        string json = JsonConvert.SerializeObject(values, Formatting.Indented);

                        //Console.WriteLine(json);

                        string postData = JsonConvert.SerializeObject(values.ToString());

                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var response = client.PostAsync("http://35.190.172.58:11960/api/absen/insert", content).Result;                  

                        var responseString = await response.Content.ReadAsStringAsync();

                        Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " Upload data siswa to server : " + baris["absen_id"].ToString());
                        Console.WriteLine("");

                        Dictionary<string, Object> Items = JsonConvert.DeserializeObject<Dictionary<string, Object>>(responseString);
                        foreach (KeyValuePair<string, Object> itm in Items)
                        {
                            if (itm.Key == "sukses")
                            {
                                if (itm.Value.ToString() == "1")
                                {
                                    Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " Upload data siswa to server : " + baris["absen_id"].ToString() + " sukses");
                                    Console.WriteLine("Keluar");

                                    Update_status_absen_keluar(baris["absen_id"].ToString());
                                }
                                else
                                {
                                    Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " Upload data siswa to server : " + baris["absen_id"].ToString() + " gagal");
                                    Console.WriteLine("");
                                }
                            }
                        }
                    }
                
                }
                r.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Absen Keluar " + ex.Message);
            }
            ubsenKeluarBool = false;

        }
        static string id_sekolah()
        {

            string id = string.Empty;

            MySqlDataReader reader = null;

            string connStr = "server=" + host + ";user=" + user + ";database=" + database + ";password=" + password + ";SslMode=" + ssl + ";";
            MySqlConnection conn = new MySqlConnection(connStr);

            int i = 1;
            MySqlCommand dbcmd_count = conn.CreateCommand();
            MySqlCommand dbcmd_select = conn.CreateCommand();

            string sqlcount = "SELECT COUNT(*) FROM sekolah;";
            dbcmd_count.CommandText = sqlcount;

            string sqlselect = "SELECT sekolah_id, nama_sekolah, alamat FROM sekolah";
            dbcmd_select.CommandText = sqlselect;

            conn.Open();

            dbcmd_count.CommandText = sqlcount;
            Int32 count = Convert.ToInt32(dbcmd_count.ExecuteScalar()); //proses menghitung jumlah data(count)

            reader = dbcmd_select.ExecuteReader();

            if (count > 0)
            {
                while (reader.Read())
                {

                    id = reader.GetString("sekolah_id");

                }
            }
            else
            {
                id = "0";
            }
            reader.Close();
            conn.Close();


            return id;
        }
        static void Update_status_absen_masuk(string absenId)
        { 

            string id = string.Empty;

            string connStr = "server=" + host + ";user=" + user + ";database=" + database + ";password=" + password + ";SslMode=" + ssl + ";";
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlCommand dbcmd_update = conn.CreateCommand();
            //MessageBox.Show("man");
            string sqlup = "update absen SET absen_status = 'SUKSES', upload_masuk ='1' where absen_id ='" + absenId + "';";
            dbcmd_update.CommandText = sqlup;
            try
            {
                //conn.Close();
                conn.Open();
                dbcmd_update.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        static void Update_status_absen_keluar(string absenId)
        {
     
            string id = string.Empty;

            string connStr = "server=" + host + ";user=" + user + ";database=" + database + ";password=" + password + ";SslMode=" + ssl + ";";
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlCommand dbcmd_update = conn.CreateCommand();
            //MessageBox.Show("man");
            string sqlup = "update absen SET absen_status = 'SUKSES', upload_keluar ='1' where absen_id ='" + absenId + "';";
            dbcmd_update.CommandText = sqlup;
            try
            {
                conn.Open();
                dbcmd_update.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
