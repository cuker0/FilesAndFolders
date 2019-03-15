using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace BNI005H_JSON
{
    public partial class Form1 : Form
    {
        const string jsonFilePath = @"D:\Test\dprop.json";

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            JsonFromDevice();
            //JsonFromString();  // ctrl+r, ctr+m

            //JsonFromFile();
            //JsonFromDevice();
        }

        private static void JsonFromString()
        {
            string json = @"{
                'ProductText': 'BOD - Optical Distance Sensor',
                'VendorName': 'BALLUFF',
                'VendorText' : 'www.balluff.com',
                'ProductName' : 'BOD 23K-LI01-S4',
                'ProductId' : 'BOD0020',
                'SerialNumber' : '1718-000095',
                'HwRev' : '01',
                'FwRev' : '1.00.000',
                'ApplTag' : '********************************',
                'Event' : '0x0',
                'EventFlag' : '0x0',
                'ProcessInputs': '3C E6 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ',
                'ProcessOutputs': '00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ',
                'DirectParameters': 'F9 1B 17 01 11 50 00 03 78 03 10 01 00 00 00 00 ',
                'Status': '87FF',
                'DsContentVendorId': '00 00 ',
                'DsContentDeviceId': '00 00 00 ',
                'DsContentChecksum': '00 00 00 00 ',
                'DsContentBuffer': '(none)'
               }";

            DeviceState deviceState = JsonConvert.DeserializeObject<DeviceState>(json);
        }

        private static void JsonFromFile()
        {
            DeviceState[] jsonDB = JsonConvert.DeserializeObject<DeviceState[]>(File.ReadAllText(jsonFilePath));

          
        }
        private async  void JsonFromDevice()
        {

            WebClient wc = new WebClient();

           string json = await wc.DownloadStringTaskAsync(new Uri("http://192.168.10.100/dprop.jsn"));

            DeviceState[] jsonDB = JsonConvert.DeserializeObject<DeviceState[]>(json);

            string[] numbers = jsonDB[0].ProcessInputs.Split(' ');
            int byte0 = int.Parse(numbers[0], System.Globalization.NumberStyles.HexNumber);
            int byte1 = int.Parse(numbers[1], System.Globalization.NumberStyles.HexNumber);
            int value = byte0 * 256 + byte1;


            textBox1.Text = value.ToString();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            JsonFromDevice();

            
        }
    }
}
