namespace IBoxUpdater
{
    partial class IBoxUpdateUtility
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IBoxUpdateUtility));
            this.txtSaveFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ntfPopup = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnGoToFolder = new System.Windows.Forms.Button();
            this.btChangeSaveFolder = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSearchUpdates = new System.Windows.Forms.Button();
            this.cbAutoCheckUpdates = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUpdateInterval = new System.Windows.Forms.TextBox();
            this.cbAutoDownload = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSaveFilePath
            // 
            this.txtSaveFilePath.Location = new System.Drawing.Point(45, 84);
            this.txtSaveFilePath.Name = "txtSaveFilePath";
            this.txtSaveFilePath.Size = new System.Drawing.Size(508, 20);
            this.txtSaveFilePath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Путь для сохранения файла";
            // 
            // ntfPopup
            // 
            this.ntfPopup.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfPopup.Icon")));
            this.ntfPopup.Text = "IBoxUpdateUtility";
            this.ntfPopup.Visible = true;
            this.ntfPopup.BalloonTipClicked += new System.EventHandler(this.ntfPopup_BalloonTipClicked);
            this.ntfPopup.DoubleClick += new System.EventHandler(this.ntfPopup_DoubleClick);
            // 
            // btnGoToFolder
            // 
            this.btnGoToFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGoToFolder.Image = global::IBoxUpdater.Properties.Resources.old_edit_redo_4967;
            this.btnGoToFolder.Location = new System.Drawing.Point(597, 77);
            this.btnGoToFolder.Name = "btnGoToFolder";
            this.btnGoToFolder.Size = new System.Drawing.Size(32, 32);
            this.btnGoToFolder.TabIndex = 6;
            this.btnGoToFolder.UseVisualStyleBackColor = true;
            this.btnGoToFolder.Click += new System.EventHandler(this.btnGoToFolder_Click);
            // 
            // btChangeSaveFolder
            // 
            this.btChangeSaveFolder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btChangeSaveFolder.BackgroundImage")));
            this.btChangeSaveFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btChangeSaveFolder.Location = new System.Drawing.Point(559, 77);
            this.btChangeSaveFolder.Name = "btChangeSaveFolder";
            this.btChangeSaveFolder.Size = new System.Drawing.Size(32, 32);
            this.btChangeSaveFolder.TabIndex = 5;
            this.btChangeSaveFolder.UseVisualStyleBackColor = true;
            this.btChangeSaveFolder.Click += new System.EventHandler(this.btChangeSaveFolder_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(617, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 64);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnSearchUpdates
            // 
            this.btnSearchUpdates.Location = new System.Drawing.Point(585, 111);
            this.btnSearchUpdates.Name = "btnSearchUpdates";
            this.btnSearchUpdates.Size = new System.Drawing.Size(179, 23);
            this.btnSearchUpdates.TabIndex = 7;
            this.btnSearchUpdates.Text = "Проверить наличие обновлений";
            this.btnSearchUpdates.UseVisualStyleBackColor = true;
            this.btnSearchUpdates.Click += new System.EventHandler(this.btnSearchUpdates_Click);
            // 
            // cbAutoCheckUpdates
            // 
            this.cbAutoCheckUpdates.AutoSize = true;
            this.cbAutoCheckUpdates.Location = new System.Drawing.Point(543, 141);
            this.cbAutoCheckUpdates.Name = "cbAutoCheckUpdates";
            this.cbAutoCheckUpdates.Size = new System.Drawing.Size(267, 17);
            this.cbAutoCheckUpdates.TabIndex = 8;
            this.cbAutoCheckUpdates.Text = "Автоматически проверять наличие обновлений";
            this.cbAutoCheckUpdates.UseVisualStyleBackColor = true;
            this.cbAutoCheckUpdates.CheckStateChanged += new System.EventHandler(this.cbAutoCheckUpdates_CheckStateChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(540, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Интервал проверки обновлений (в часах)";
            this.label2.Visible = false;
            // 
            // txtUpdateInterval
            // 
            this.txtUpdateInterval.Location = new System.Drawing.Point(763, 170);
            this.txtUpdateInterval.Name = "txtUpdateInterval";
            this.txtUpdateInterval.Size = new System.Drawing.Size(39, 20);
            this.txtUpdateInterval.TabIndex = 10;
            this.txtUpdateInterval.Visible = false;
            this.txtUpdateInterval.TextChanged += new System.EventHandler(this.txtUpdateInterval_TextChanged);
            // 
            // cbAutoDownload
            // 
            this.cbAutoDownload.AutoSize = true;
            this.cbAutoDownload.Location = new System.Drawing.Point(543, 196);
            this.cbAutoDownload.Name = "cbAutoDownload";
            this.cbAutoDownload.Size = new System.Drawing.Size(223, 17);
            this.cbAutoDownload.TabIndex = 11;
            this.cbAutoDownload.Text = "Автоматически загружать обновления";
            this.cbAutoDownload.UseVisualStyleBackColor = true;
            this.cbAutoDownload.Visible = false;
            this.cbAutoDownload.CheckedChanged += new System.EventHandler(this.cbAutoDownload_CheckedChanged);
            // 
            // IBoxUpdateUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 241);
            this.Controls.Add(this.cbAutoDownload);
            this.Controls.Add(this.txtUpdateInterval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbAutoCheckUpdates);
            this.Controls.Add(this.btnSearchUpdates);
            this.Controls.Add(this.btnGoToFolder);
            this.Controls.Add(this.btChangeSaveFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSaveFilePath);
            this.Controls.Add(this.pictureBox1);
            this.Name = "IBoxUpdateUtility";
            this.Text = "IBoxUpdateUtility";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtSaveFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btChangeSaveFolder;
        private System.Windows.Forms.NotifyIcon ntfPopup;
        private System.Windows.Forms.Button btnGoToFolder;
        private System.Windows.Forms.Button btnSearchUpdates;
        private System.Windows.Forms.CheckBox cbAutoCheckUpdates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUpdateInterval;
        private System.Windows.Forms.CheckBox cbAutoDownload;
    }
}

