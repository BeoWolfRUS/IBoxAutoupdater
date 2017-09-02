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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IBoxUpdateUtility));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSaveFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btChangeSaveFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(449, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 64);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
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
            // IBoxUpdateUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 181);
            this.Controls.Add(this.btChangeSaveFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSaveFilePath);
            this.Controls.Add(this.pictureBox1);
            this.Name = "IBoxUpdateUtility";
            this.Text = "IBoxUpdateUtility 1.0";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtSaveFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btChangeSaveFolder;
    }
}

