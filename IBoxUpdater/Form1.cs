using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace IBoxUpdater
{
    public partial class IBoxUpdateUtility : Form
    {
        Dictionary<string, string> downloadLinks = new Dictionary<string, string>();
        Dictionary<string, string> latestDownloads = new Dictionary<string, string>();
        double interval = double.Parse(Properties.Settings.Default.UpdateInterval) * 1000 *60 *60;
        System.Timers.Timer timer = new System.Timers.Timer();

        private bool CheckInternet()
        {
            bool internet = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            return internet;
        }

        public IBoxUpdateUtility()
        {
            while (!CheckInternet())
            {
                CheckInternet();
            }

            InitializeComponent();

            timer.Interval = interval;

            

            cbAutoDownload.Checked = Properties.Settings.Default.AutoDownload;
            cbAutoCheckUpdates.Checked = Properties.Settings.Default.CheckUpdates;

            ToolTip tip = new ToolTip();
            tip.SetToolTip(btnGoToFolder, "Перейти в каталог");
            tip.SetToolTip(btChangeSaveFolder, "Указать каталог для сохранения обновлений");
            ntfPopup.ContextMenu = new ContextMenu();
            ntfPopup.ContextMenu.MenuItems.Add("IBoxUpdater", ntfPopup_DoubleClick);
            ntfPopup.ContextMenu.MenuItems.Add("Выйти", new EventHandler(ContextCloseApp_Click));

            FormBorderStyle = FormBorderStyle.FixedDialog;
            StringCollection lastDownloads = Properties.Settings.Default.LastDownloads;
            if (lastDownloads != null)
            {
                foreach (var item in lastDownloads)
                {
                    if (item != "-1")
                    {
                        string[] splited = item.Split('@');
                        latestDownloads.Add(splited[0], splited[1]);
                    }
                }
            }
            Point location = new Point(45, 27);
            txtSaveFilePath.Text = Properties.Settings.Default.SaveFilePath;
            List<string> devices = new List<string>();
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

            foreach (var element in devices)
            {
                Label name = new Label();
                name.Name = "nameLblfor" + element;
                name.Text = element;
                name.Height = 20;
                name.Width = 100;
                name.Location = location;

                Label download = new Label();
                download.Name = "linkLblfor" + element;
                download.Text = "Скачать";
                download.Click += linkLbl_Click;
                download.Location = new Point(location.X + 100, location.Y);
                download.Height = name.Height;
                download.Width = 60;
                download.Cursor = Cursors.Hand;

                Label updateDate = new Label();
                updateDate.Name = "siteDatefor" + element;
                updateDate.Text = GetLastModified(element);
                updateDate.Location = new Point(location.X + 160, location.Y);
                updateDate.Width = 75;
                updateDate.Height = name.Height;

                
                Label downloadDate = new Label();
                downloadDate.Name = "dwnlddateFor" + element;
                string tmp = "";
                if (latestDownloads != null && latestDownloads.Count > 0)
                {
                    latestDownloads.TryGetValue(element, out tmp);
                    downloadDate.Text = string.IsNullOrEmpty(tmp) ? "Загрузка обновления не производилась" : tmp;
                }
                else downloadDate.Text = "Загрузка обновления не производилась";
                if (downloadDate.Text != "Загрузка обновления не производилась")
                {
                    DateTime update = DateTime.Parse(updateDate.Text);
                    DateTime lastDownload = DateTime.Parse(downloadDate.Text);
                    if (update > lastDownload)
                    {
                        ntfPopup.BalloonTipText = "Доступно обновление баз!";
                        download.ForeColor = Color.Red;
                        download.Text = download.Text.ToUpper();
                        ntfPopup.ShowBalloonTip(5000);
                    }
                }
                downloadDate.Location = new Point(location.X + 235, location.Y);
                downloadDate.Width = 300;
                downloadDate.Height = name.Height;
               

                location.Y += 25;
                Height += 25;
                Controls.Add(name);
                Controls.Add(download);
                Controls.Add(updateDate);
                Controls.Add(downloadDate);

                label1.Location = new Point(label1.Location.X, label1.Location.Y + 25);
                txtSaveFilePath.Location = new Point(txtSaveFilePath.Location.X, txtSaveFilePath.Location.Y + 25);
                btChangeSaveFolder.Location = new Point(btChangeSaveFolder.Location.X, btChangeSaveFolder.Location.Y + 25);
                btnGoToFolder.Location = new Point(btnGoToFolder.Location.X, btnGoToFolder.Location.Y + 25);
                Visible = false;
                ShowInTaskbar = false;


            }

            ntfPopup.BalloonTipText = "Утилита обновления баз для продуктов iBox запущена!";
            ntfPopup.ShowBalloonTip(3000);
        }

        private void linkLbl_Click(object sender, EventArgs e)
        {
            var linkLable = (Label)sender;
            var downloadLink = "";
            downloadLinks.TryGetValue(linkLable.Name.Substring(10), out downloadLink);
            string fullPath = Properties.Settings.Default.SaveFilePath +"\\"+ downloadLink.Substring(downloadLink.LastIndexOf('/')+1);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(downloadLink,fullPath);
            }
            foreach (var item in Properties.Settings.Default.LastDownloads)
            {
                if (item != "-1")
                {
                    string[] splitted = item.Split('@');
                    if (linkLable.Name.Substring(10) == splitted[0])
                    {
                        Properties.Settings.Default.LastDownloads.Insert(Properties.Settings.Default.LastDownloads.IndexOf(item), linkLable.Name.Substring(10) + "@" + DateTime.Now.ToShortDateString());
                        Properties.Settings.Default.LastDownloads.Remove(item);
                        Properties.Settings.Default.Save();
                        break;
                    }
                }
            }
            foreach (var control in Controls)
            {
                try
                {
                    Label date = (Label)control;
                    if (date.Name == "dwnlddateFor"+ linkLable.Name.Substring(10))
                    {
                        date.Text = DateTime.Now.ToShortDateString();
                    }
                }
                catch
                {

                }
            }
            linkLable.ForeColor = Color.Black;
            linkLable.Text = Char.ToUpper(linkLable.Text[0]) + linkLable.Text.Substring(1);
        }

        private void ContextCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private string GetLastModified(string deviceName)
        {
            string rezult = "";
            string url = "http://ibox.su/obnovlenie-po/";
            if (deviceName == "iBOX Combo F5" || deviceName == "iBOX Combo F5+" || deviceName == "iBOX Combo F1" || deviceName == "iBOX Combo F1+")
            {
                url += "combo-3-in-1/";
                switch (deviceName)
                {
                    case "iBOX Combo F5": url += "ibox-f5/index.html"; break;
                    case "iBOX Combo F5+": url += "ibox-f5-plus/index.html"; break;
                    case "iBOX Combo F1": url += "ibox-f1/index.html"; break;
                    case "iBOX Combo F1+": url += "ibox-f1-plus/index.html"; break;
                }
            }
            else if (deviceName == "iBOX Combo GT" || deviceName == "iBOX Combo GTS")
            {
                url += "combo-2-in-1/";
                switch (deviceName)
                {
                    case "iBOX Combo GT": url += "ibox-gt/index.html"; break;
                    case "iBOX Combo GTS": url += "ibox-gts/index.html"; break;
                }
            }
            else if (deviceName == "iBOX PRO 900 GPS" || deviceName == "iBOX PRO 800 GPS" || deviceName == "iBOX PRO 700 GPS" || deviceName == "iBOX PRO 100 GPS" || deviceName == "iBOX GT 55 GPS" || deviceName == "iBOX X10 GPS")
            {
                url += "radar-detectors_gps/";
                switch (deviceName)
                {
                    case "iBOX PRO 900 GPS": url += "ibox-pro-900-gps/index.html"; break;
                    case "iBOX PRO 800 GPS": url += "ibox-pro-800-gps/index.html"; break;
                    case "iBOX PRO 700 GPS": url += "ibox-pro-700-gps/index.html"; break;
                    case "iBOX PRO 100 GPS": url += "ibox-pro-100-gps/index.html"; break;
                    case "iBOX GT 55 GPS": url += "ibox-gt-55/index.html"; break;
                    case "iBOX X10 GPS": url += "ibox-x10/index.html"; break;
                }
            }
            else if (deviceName == "iBOX X9 GPS" || deviceName == "iBOX X8 GPS" || deviceName == "iBOX X6+ GPS" || deviceName == "iBOX X6 GPS")
            {
                url += "radar-detectors/";
                switch (deviceName)
                {
                    case "iBOX X9 GPS": url += "ibox-x9/index.html"; break;
                    case "iBOX X8 GPS": url += "ibox-x8/index.html"; break;
                    case "iBOX X6+ GPS": url += "ibox-x6-plus/index.html"; break;
                    case "iBOX X6 GPS": url += "ibox-x6/index.html"; break;
                }
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            rezult = response.LastModified.ToShortDateString();
            response.Close();
                return rezult;
        }

        private void ntfPopup_BalloonTipClicked(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            ntfPopup.Visible = false;
        }

        private void ntfPopup_DoubleClick(object sender, EventArgs e)
        {
            ntfPopup.Visible = false;
            WindowState = FormWindowState.Normal;
            Visible = true;
            ShowInTaskbar = true;
        }

        private void btnGoToFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Settings.Default.SaveFilePath);
        }

        private void btnSearchUpdates_Click(object sender, EventArgs e)
        {
            bool hasUpdates = false;
            foreach (var control in Controls)
            {
                try
                {
                    Label link = (Label)control;
                    if (link.Name.Contains("dwnlddateFor"))
                    {
                        string newDate = GetLastModified(link.Name.Substring(12));
                        if (DateTime.Parse(newDate) > DateTime.Parse(link.Text))
                        {
                            hasUpdates = true;
                        }
                    }
                }
                catch
                {

                }
            }
            if (hasUpdates)
            {
                MessageBox.Show("Доступны новые обновления!");
            }
            else MessageBox.Show("Новые обновления отсутствуют.");
        }

        private void CheckUpdates(object source, ElapsedEventArgs e)
        {
            bool hasUpdates = false;
            foreach (var control in Controls)
            {
                try
                {
                    Label link = (Label)control;
                    if (link.Name.Contains("dwnlddateFor"))
                    {
                        string newDate = GetLastModified(link.Name.Substring(12));
                        if (DateTime.Parse(newDate) > DateTime.Parse(link.Text))
                        {
                            hasUpdates = true;
                           
                            if (cbAutoDownload.Checked)
                            {
                                var downloadLink = "";
                                downloadLinks.TryGetValue(link.Name.Substring(12), out downloadLink);
                                string fullPath = Properties.Settings.Default.SaveFilePath + "\\" + downloadLink.Substring(downloadLink.LastIndexOf('/') + 1);
                                if (File.Exists(fullPath))
                                {
                                    File.Delete(fullPath);
                                }
                                using (WebClient wc = new WebClient())
                                {
                                    wc.DownloadFile(downloadLink, fullPath);
                                }
                                foreach (var item in Properties.Settings.Default.LastDownloads)
                                {
                                    if (item != "-1")
                                    {
                                        string[] splitted = item.Split('@');
                                        if (link.Name.Substring(12) == splitted[0])
                                        {
                                            Properties.Settings.Default.LastDownloads.Insert(Properties.Settings.Default.LastDownloads.IndexOf(item), link.Name.Substring(12) + "@" + DateTime.Now.ToShortDateString());
                                            Properties.Settings.Default.LastDownloads.Remove(item);
                                            Properties.Settings.Default.Save();
                                            break;
                                        }
                                    }
                                }

                                ntfPopup.BalloonTipText = "Обновления загружены!";
                                ntfPopup.ShowBalloonTip(2000);
                                link.Text = DateTime.Now.ToShortDateString();
                            }
                        }
                    }
                }
                catch
                {

                }
            }
            if (hasUpdates)
            {
                ntfPopup.BalloonTipText = "Доступны новые обновления!";
            }

        }

        private void cbAutoCheckUpdates_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox item = (CheckBox)sender;
            if (item.Checked)
            {
                label2.Visible = true;
                txtUpdateInterval.Visible = true;
                txtUpdateInterval.Text = Properties.Settings.Default.UpdateInterval;
                cbAutoDownload.Visible = true;
                Properties.Settings.Default.CheckUpdates = item.Checked;
                Properties.Settings.Default.Save();
                timer.Enabled = true;
                timer.Elapsed += CheckUpdates;
            }
            else
            {
                label2.Visible = false;
                txtUpdateInterval.Visible = false;
                cbAutoDownload.Visible = false;
                Properties.Settings.Default.CheckUpdates = item.Checked;
                Properties.Settings.Default.Save();
                timer.Enabled = false;
            }

        }

        private void cbAutoDownload_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox item = (CheckBox)sender;
            if (item.Checked)
            {
                Properties.Settings.Default.AutoDownload = item.Checked;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.AutoDownload = item.Checked;
                Properties.Settings.Default.Save();
            }

        }

        private void txtUpdateInterval_TextChanged(object sender, EventArgs e)
        {
            var item =  sender as TextBox;
            Properties.Settings.Default.UpdateInterval = item.Text;
            Properties.Settings.Default.Save();
        }
    }
}
