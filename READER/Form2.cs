using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RawInput_dll;
using System.IO;

namespace READER
{
    public partial class Form2 : Form
    {
        private readonly RawInput _rawinput;

        const bool CaptureOnlyInForeground = true;

        private string fileReader1 = "Reader1.txt";
        private string fileReader2 = "Reader2.txt";
        private string fileReader3 = "Reader3.txt";
        private string fileReader4 = "Reader4.txt";
        private string fileReader5 = "Reader5.txt";


        public Form2()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;

            //AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            _rawinput = new RawInput(Handle, CaptureOnlyInForeground);

            _rawinput.AddMessageFilter();   // Adding a message filter will cause keypresses to be handled
            Win32.DeviceAudit();            // Writes a file DeviceAudit.txt to the current directory

            _rawinput.KeyPressed += OnKeyPressed;
        }

        private void OnKeyPressed(object sender, RawInputEventArg e)
        {
            textBox1.Text = e.KeyPressEvent.DeviceHandle.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = Application.StartupPath + "\\Settings\\";

            int index = comboBox1.SelectedIndex;

            switch (index)
            {
                case 0:
                    createFile(path, fileReader1, textBox1.Text);
                    break;
                case 1:
                    createFile(path, fileReader2, textBox1.Text);
                    break;
                case 2:
                    createFile(path, fileReader3, textBox1.Text);
                    break;
                case 3:
                    createFile(path, fileReader4, textBox1.Text);
                    break;
                case 4:
                    createFile(path, fileReader5, textBox1.Text);
                    break;
            }

            textBox1.Text = "";

            MessageBox.Show("SUKSES");

        }

        protected void createFile(string path, string fileName, string value)
        {
            string pathdevice = path + fileName;
            if (File.Exists(pathdevice))
            {
                File.Delete(pathdevice);

                using (StreamWriter sw = File.CreateText(pathdevice))
                {
                    sw.WriteLine(value);
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(pathdevice))
                {
                    sw.WriteLine(value);
                }
            }
        }
    }
}
