using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace SIP
{
    static class Program
    {
        static string pathRespon = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(Application.ExecutablePath)) + @"\response.txt";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ReadFile();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLoading());
        }


        static void ReadFile()
        {
            string responseString = File.ReadAllText(pathRespon, Encoding.UTF8);

            MessageBox.Show(responseString.IndexOf("HTTP").ToString());

            dynamic billList = JsonConvert.DeserializeObject<string>(responseString);

            Dictionary<string, Object> values = JsonConvert.DeserializeObject<Dictionary<string, Object>>(responseString);


        }
    }
}
