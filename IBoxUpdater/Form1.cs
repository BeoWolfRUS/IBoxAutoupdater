using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBoxUpdater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adress = "http://ibox.su/obnovlenie-po/radar-detectors/ibox-x6/index.html";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(adress);
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiver = response.GetResponseStream();
                StreamReader reader = null;
                if (response.CharacterSet == null)
                {
                    reader = new StreamReader(receiver);
                }
                else
                {
                    reader = new StreamReader(receiver, Encoding.GetEncoding(response.CharacterSet));
                }

                string data = reader.ReadToEnd();

                response.Close();
                reader.Close();
            }
        }
    }
}
