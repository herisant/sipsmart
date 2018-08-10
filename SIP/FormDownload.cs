using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Windows.Forms;
using System.Xml;


namespace SIP
{
    public partial class FormDownload : Form
    {
        siponline.downloadSiswaGuru online = new siponline.downloadSiswaGuru();

        protected string pathRespon = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(Application.ExecutablePath)) + @"\response.txt";
        protected string pathHost = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(Application.ExecutablePath)) + @"\WebService\host.sip";
        protected string pathDB = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(Application.ExecutablePath)) + @"\myconfig.ini";
        protected string _koneksi = "Server={0};Database={1};User Id={2};Password={3};";
        FirewallSip _security = new FirewallSip();
        public FormDownload()
        {
            InitializeComponent();
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            bgWorker.RunWorkerAsync();
        }
        public string ReadURL()
        {
            using (StreamReader sr = new StreamReader(pathHost))
            {
                return _security.Decrypt(sr.ReadToEnd(), true);
            }
        }
        protected void DownloadDataSiswa()
        {
            try
            {
                


                MessageBox.Show("MASUK");
                string downloaddata = online.getData(id_sekolah());
                MessageBox.Show(downloaddata);

                #region OLD
                //using (var client = new HttpClient())
                //{
                //    client.DefaultRequestHeaders.Accept.Clear();
                //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //    var Items = new Dictionary<string, string>
                //        {
                //             { "sekolah_id", id_sekolah() }
                //        };


                //    var content = new FormUrlEncodedContent(Items);
                //    var response = await client.PostAsync(ReadURL(), content);
                //    var responseString = await response.Content.ReadAsStringAsync();
                #endregion

                //    MessageBox.Show(responseString);
                Dictionary<string, Object> values = JsonConvert.DeserializeObject<Dictionary<string, Object>>(downloaddata);

                foreach (KeyValuePair<string, Object> item in values)
                {
                    if (item.Key == "data_siswa")
                    {
                        Siswa[] detail_siswa = JsonConvert.DeserializeObject<Siswa[]>(item.Value.ToString());

                        if (detail_siswa.Count() > 0)
                        {
                            AbsensiDataContext dc = new AbsensiDataContext(Koneksi());
                            this.Invoke(new Action(() => pgBar.Value = 0));
                            this.Invoke(new Action(() => pgBar.MaximumValue = detail_siswa.Count()));

                            for (int i = 0; i < detail_siswa.Count(); i++)
                            {
                                // SINKRONISASI DENGAN DATABASE
                                if (dc.siswas.Where(x => x.siswa_nik == detail_siswa[i].siswa_nik).Count() == 0)
                                {
                                    siswa itm = new siswa();
                                    itm.nama_panggilan = detail_siswa[i].nama_panggilan;
                                    itm.siswa_alamat = detail_siswa[i].siswa_alamat;
                                    itm.siswa_anak_ke = detail_siswa[i].siswa_anak_ke;
                                    itm.siswa_email = detail_siswa[i].siswa_email;
                                    itm.siswa_hp = detail_siswa[i].siswa_hp;
                                    itm.siswa_id = detail_siswa[i].siswa_id;
                                    itm.siswa_jarak = detail_siswa[i].siswa_jarak;
                                    itm.siswa_jk = detail_siswa[i].siswa_jk;
                                    itm.siswa_jumlah_sudara = detail_siswa[i].siswa_jumlah_sudara;
                                    itm.siswa_kelas_id = detail_siswa[i].siswa_kelas_id;
                                    itm.siswa_kode_pos = detail_siswa[i].siswa_kode_pos;
                                    itm.siswa_nama = detail_siswa[i].siswa_nama;
                                    itm.siswa_nik = detail_siswa[i].siswa_nik;
                                    itm.siswa_nisn = detail_siswa[i].siswa_nisn;
                                    itm.siswa_nomor_kartu = detail_siswa[i].siswa_nomor_kartu;
                                    itm.siswa_no_ijazah = detail_siswa[i].siswa_no_ijazah;
                                    itm.siswa_no_kk = detail_siswa[i].siswa_no_kk;
                                    itm.siswa_no_telp = detail_siswa[i].siswa_no_telp;
                                    itm.siswa_sekolah_id = detail_siswa[i].siswa_sekolah_id;
                                    itm.siswa_status = detail_siswa[i].siswa_status;
                                    itm.siswa_tanggal_lahir = detail_siswa[i].siswa_tanggal_lahir;
                                    itm.siswa_tanggal_langganan = detail_siswa[i].siswa_tanggal_langganan;
                                    itm.siswa_tempat_lahir = detail_siswa[i].siswa_tempat_lahir;
                                    itm.siswa_waktu = detail_siswa[i].siswa_waktu;

                                    dc.siswas.InsertOnSubmit(itm);
                                    dc.SubmitChanges();

                                    this.Invoke(new Action(() => pgBar.Value++));
                                }
                            }
                        }
                    }

                    if (item.Key == "data_guru")
                    {
                        AbsensiDataContext dc = new AbsensiDataContext(Koneksi());

                        Guru[] detail_guru = JsonConvert.DeserializeObject<Guru[]>(item.Value.ToString());

                        this.Invoke(new Action(() => pgBar.Value = 0));
                        this.Invoke(new Action(() => pgBar.MaximumValue = detail_guru.Count()));

                        for (int i = 0; i < detail_guru.Count(); i++)
                        {
                            // SINKRONISASI DENGAN DATABASE
                            if (dc.gurus.Where(x => x.guru_nip == detail_guru[i].guru_nip).Count() == 0)
                            {
                                guru itm = new guru();
                                itm.guru_id = Convert.ToInt32(detail_guru[i].guru_id);
                                itm.guru_email = detail_guru[i].guru_email;
                                itm.guru_jk = detail_guru[i].guru_jk;
                                itm.guru_nama = detail_guru[i].guru_nama;
                                itm.guru_nip = detail_guru[i].guru_nip;
                                itm.guru_nomor_kartu = detail_guru[i].guru_nomor_kartu;
                                itm.guru_phone = detail_guru[i].guru_phone;
                                itm.guru_sekolah_id = detail_guru[i].guru_sekolah_id;
                                itm.guru_status = detail_guru[i].guru_status;

                                dc.gurus.InsertOnSubmit(itm);
                                dc.SubmitChanges();

                                this.Invoke(new Action(() => pgBar.Value++));
                            }
                        }
                    }

                    this.Invoke(new Action(() => pgBar.Value = 0));
                    this.Invoke(new Action(() => labelInformasi.Text = "DOWNLOAD SELESAI"));
                }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR : " + ex.Message);
            }
        }
        public string id_sekolah()
        {
            string id = string.Empty;
            AbsensiDataContext dc = new SIP.AbsensiDataContext(Koneksi());
            dc.CommandTimeout = 0;

            var skl = from sk in dc.sekolahs
                      select sk;
            if (skl.Count() > 0)
            {
                id = skl.FirstOrDefault().sekolah_id.Trim();
            }

            dc.Dispose();
            return id;
        }
        public class Siswa
        {
            public string siswa_id;
            public string siswa_sekolah_id;
            public string siswa_nama;
            public string siswa_kelas_id;
            public string siswa_status;
            public string siswa_nisn;
            public string siswa_jk;
            public string siswa_tempat_lahir;
            public string siswa_tanggal_lahir;
            public string siswa_alamat;
            public string siswa_hp;
            public string nama_panggilan;
            public string siswa_waktu;
            public string siswa_jarak;
            public string siswa_email;
            public string siswa_anak_ke;
            public string siswa_jumlah_sudara;
            public string siswa_kode_pos;
            public string siswa_no_telp;
            public string siswa_no_ijazah;
            public string siswa_nik;
            public string siswa_no_kk;
            public string siswa_nomor_kartu;
            public string siswa_tanggal_langganan;

        }
        public class Guru
        {
            public string guru_id;
            public string guru_sekolah_id;
            public string guru_nama;
            public string guru_nip;
            public string guru_email;
            public string guru_nomor_kartu;
            public string guru_phone;
            public string guru_jk;
            public string guru_status;
        }
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DownloadDataSiswa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
    }
}
