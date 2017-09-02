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
    public partial class IBoxUpdateUtility : Form
    {

        Dictionary<string, string> lastDonwloads = new Dictionary<string, string>();

        public IBoxUpdateUtility()
        {
            InitializeComponent();

            Point location = new Point(45, 27);
            txtSaveFilePath.Text = Properties.Settings.Default.SaveFilePath;
            List<string> devices = new List<string>();
            Dictionary<string, string> downloadLinks = new Dictionary<string, string>();
            devices.Add("iBOX Combo F5");
            downloadLinks.Add(devices.Last(), "http://ibox.su/PO/Combo_F5.exe");
            devices.Add("iBOX Combo F5+");
            downloadLinks.Add(devices.Last(), "http://ibox.su/PO/Combo_F5_%20(PLUS).exe");
            devices.Add("iBOX Combo F1");
            downloadLinks.Add(devices.Last(), "http://ibox.su/PO/Combo_F1.exe");
            devices.Add("iBOX Combo F1+");
            downloadLinks.Add(devices.Last(), "http://ibox.su/PO/Combo_F1_(PLUS).exe");
            devices.Add("iBOX Combo GT");
            downloadLinks.Add(devices.Last(), "http://ibox.su/PO/Combo%20GT.bin");
            devices.Add("iBOX Combo GTS");
            downloadLinks.Add(devices.Last(), "http://ibox.su/PO/Combo%20GTS.bin");
            devices.Add("iBOX PRO 900 GPS");
            downloadLinks.Add(devices.Last(), "http://ibox.su/PO/PRO-900_GPS.exe");
            devices.Add("iBOX PRO 800 GPS");
            downloadLinks.Add(devices.Last(), "http://ibox.su/PO/PRO-800_GPS.exe");
            devices.Add("iBOX PRO 700 GPS");
            downloadLinks.Add(devices.Last(), "http://ibox.su/PO/PRO_700_GPS.exe");
            devices.Add("iBOX PRO 100 GPS");
            downloadLinks.Add(devices.Last(), "http://ibox.su/PO/PRO_100_GPS.exe");
            devices.Add("iBOX GT 55 GPS");
            downloadLinks.Add(devices.Last(), "http://ibox.su/PO/GT_55_GPS.exe");
            devices.Add("iBOX X10 GPS");
            downloadLinks.Add(devices.Last(), "http://ibox.su/PO/X10_GPS.exe");
            devices.Add("iBOX X9 GPS");
            downloadLinks.Add(devices.Last(), "http://ibox.su/PO/X9_GPS.exe");
            devices.Add("iBOX X8 GPS");
            downloadLinks.Add(devices.Last(), "http://ibox.su/PO/X8_GPS.exe");
            devices.Add("iBOX X6+ GPS");
            downloadLinks.Add(devices.Last(), "http://ibox.su/PO/X6_(PLUS)_GPS.exe");
            devices.Add("iBOX X6 GPS");
            downloadLinks.Add(devices.Last(), "http://ibox.su/PO/X6_GPS.exe");

            if (Properties.Settings.Default.FirstLaunch)
            {
                foreach (var item in devices)
                {
                    lastDonwloads.Add(item, "Загрузка не производилась");
                    Properties.Settings.Default.FirstLaunch = false;
                }
            }
            foreach (var element in devices)
            {
                Label name = new Label();
                name.Name = "nameLblfor" + element;
                name.Text = element;
                name.Height = 20;
                name.Location = location;
                location.Y += 25;
                this.Height += 25;
                this.Controls.Add(name);
                label1.Location = new Point(label1.Location.X, label1.Location.Y + 25);
                txtSaveFilePath.Location = new Point(txtSaveFilePath.Location.X, txtSaveFilePath.Location.Y + 25);
                btChangeSaveFolder.Location = new Point(btChangeSaveFolder.Location.X, btChangeSaveFolder.Location.Y + 25);
            }

        }

        private void btChangeSaveFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtSaveFilePath.Text = fbd.SelectedPath;
                    Properties.Settings.Default.SaveFilePath = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            }
        }
    }
}
