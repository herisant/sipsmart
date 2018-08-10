using System;
using RawInput_dll;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using USBHIDDRIVER;
using System.IO;

namespace READER
{
    public partial class Form1 : Form
    {
        private RawInput _rawinput;
        const bool CaptureOnlyInForeground = true;
        string ibuttonData, keyData = "";
        protected USBInterface _interface;

        public string device_reader_1 { get; set; }
        public string device_reader_2 { get; set; }
        public string device_reader_3 { get; set; }
        public string device_reader_4 { get; set; }
        public string device_reader_5 { get; set; }
        public Form1()
        {
            InitializeComponent();

            downloadFile();
            LoggerUSB();
        }
        protected void downloadFile()
        {
            var pathDevice = Application.StartupPath + "\\Settings\\";
            string[] filePaths = Directory.GetFiles(pathDevice);

            foreach (string line in filePaths)
            {
                using (StreamReader sr = new StreamReader(line))
                {
                    if (line.EndsWith("Reader1.txt"))
                    {
                        device_reader_1 = sr.ReadToEnd().Replace("\r\n", "");
                    }
                    if (line.EndsWith("Reader2.txt"))
                    {
                        device_reader_2 = sr.ReadToEnd().Replace("\r\n", "");
                    }
                    if (line.EndsWith("Reader3.txt"))
                    {
                        device_reader_3 = sr.ReadToEnd().Replace("\r\n", "");
                    }
                    if (line.EndsWith("Reader4.txt"))
                    {
                        device_reader_4 = sr.ReadToEnd().Replace("\r\n", "");
                    }
                    if (line.EndsWith("Reader5.txt"))
                    {
                        device_reader_5 = sr.ReadToEnd().Replace("\r\n", "");
                    }
                }
            }
        }
        private void LoggerUSB()
        {
            _rawinput = new RawInput(Handle, CaptureOnlyInForeground);
            // _rawinput.AddMessageFilter();   // Adding a message filter will cause keypresses to be handled
            _rawinput.KeyPressed += OnKeyPressed;
            Win32.DeviceAudit();
        }
        private void txtReader1_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }
        private void OnKeyPressed(object sender, RawInputEventArg e)
        {
            if (e.KeyPressEvent.DeviceName == "Global Keyboard")
            {
                return;
            }

            string deviceName = e.KeyPressEvent.DeviceName;
            string[] div = deviceName.Split('#');
            if (div.Length >= 2)
            {
                string[] hid = div[1].Split('&');
                if (hid.Length >= 2)
                {

                    if (e.KeyPressEvent.KeyPressState == "BREAK")
                    {
                        if (e.KeyPressEvent.VKeyName == "160")
                        {
                            return;
                        }

                        if (e.KeyPressEvent.VKeyName != "13")
                        {
                            if (e.KeyPressEvent.VKeyName == "ENTER")
                            {
                                string deviceHandle = e.KeyPressEvent.DeviceHandle.ToString();

                                if (device_reader_1 == deviceHandle)
                                {
                                    long intVal = Int64.Parse(keyData, System.Globalization.NumberStyles.HexNumber);
                                    MessageBox.Show(intVal.ToString());
                                    txtReader1.Text = intVal.ToString();
                                }
                                if (device_reader_2 == deviceHandle)
                                {
                                    txtReader2.Text = keyData;
                                }
                                if (device_reader_3 == deviceHandle)
                                {
                                    txtReader3.Text = keyData;
                                }
                                if (device_reader_4 == deviceHandle)
                                {
                                    txtReader4.Text = keyData;
                                }
                                if (device_reader_5 == deviceHandle)
                                {
                                    txtReader5.Text = keyData;
                                }
                            }
                            keyData += e.KeyPressEvent.VKeyName;
                        }
                        else
                        {
                            if (keyData.Length > 5)
                            {
                                MessageBox.Show(keyData);
                            }
                        }
                    }
                }
            }
        }
    }
}
