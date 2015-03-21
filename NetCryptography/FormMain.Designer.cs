namespace NetCryptography
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkLabelInFileEntropy = new System.Windows.Forms.LinkLabel();
            this.labelFileSize = new System.Windows.Forms.Label();
            this.textBoxInputFile = new System.Windows.Forms.TextBox();
            this.buttonInputFile = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.linkLabelOutFileEntropy = new System.Windows.Forms.LinkLabel();
            this.textBoxOutputFile = new System.Windows.Forms.TextBox();
            this.buttonOutputFile = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAboutProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxSetings = new System.Windows.Forms.GroupBox();
            this.checkBoxIVTo0 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonGenerateVI = new System.Windows.Forms.Button();
            this.labelVI = new System.Windows.Forms.Label();
            this.buttonGenerateKey = new System.Windows.Forms.Button();
            this.labelKey = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxKeyLength = new System.Windows.Forms.ComboBox();
            this.groupBoxAlg = new System.Windows.Forms.GroupBox();
            this.radioButtonRijndael = new System.Windows.Forms.RadioButton();
            this.radioButtonRC2 = new System.Windows.Forms.RadioButton();
            this.radioButtonTripleDES = new System.Windows.Forms.RadioButton();
            this.radioButtonDES = new System.Windows.Forms.RadioButton();
            this.radioButtonAES = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonStop = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBoxSetings.SuspendLayout();
            this.groupBoxAlg.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Файл";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.linkLabelInFileEntropy);
            this.groupBox3.Controls.Add(this.labelFileSize);
            this.groupBox3.Controls.Add(this.textBoxInputFile);
            this.groupBox3.Controls.Add(this.buttonInputFile);
            this.groupBox3.Location = new System.Drawing.Point(6, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(519, 57);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Вхідний";
            // 
            // linkLabelInFileEntropy
            // 
            this.linkLabelInFileEntropy.AutoSize = true;
            this.linkLabelInFileEntropy.LinkArea = new System.Windows.Forms.LinkArea(11, 20);
            this.linkLabelInFileEntropy.Location = new System.Drawing.Point(6, 39);
            this.linkLabelInFileEntropy.Name = "linkLabelInFileEntropy";
            this.linkLabelInFileEntropy.Size = new System.Drawing.Size(61, 17);
            this.linkLabelInFileEntropy.TabIndex = 8;
            this.linkLabelInFileEntropy.Text = "Ентропія: -";
            this.toolTip1.SetToolTip(this.linkLabelInFileEntropy, "копіювати значення ентропії до буферу обміну");
            this.linkLabelInFileEntropy.UseCompatibleTextRendering = true;
            this.linkLabelInFileEntropy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelInFileEntropy_LinkClicked);
            // 
            // labelFileSize
            // 
            this.labelFileSize.AutoSize = true;
            this.labelFileSize.Location = new System.Drawing.Point(202, 39);
            this.labelFileSize.Name = "labelFileSize";
            this.labelFileSize.Size = new System.Drawing.Size(51, 13);
            this.labelFileSize.TabIndex = 7;
            this.labelFileSize.Text = "Розмір: -";
            this.toolTip1.SetToolTip(this.labelFileSize, "Розмір вхідного файлу");
            // 
            // textBoxInputFile
            // 
            this.textBoxInputFile.Location = new System.Drawing.Point(6, 16);
            this.textBoxInputFile.Name = "textBoxInputFile";
            this.textBoxInputFile.ReadOnly = true;
            this.textBoxInputFile.Size = new System.Drawing.Size(457, 20);
            this.textBoxInputFile.TabIndex = 2;
            // 
            // buttonInputFile
            // 
            this.buttonInputFile.Location = new System.Drawing.Point(468, 14);
            this.buttonInputFile.Name = "buttonInputFile";
            this.buttonInputFile.Size = new System.Drawing.Size(45, 24);
            this.buttonInputFile.TabIndex = 1;
            this.buttonInputFile.Text = "...";
            this.toolTip1.SetToolTip(this.buttonInputFile, "Обрати вхідний файл");
            this.buttonInputFile.UseVisualStyleBackColor = true;
            this.buttonInputFile.Click += new System.EventHandler(this.buttonInputFile_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.linkLabelOutFileEntropy);
            this.groupBox5.Controls.Add(this.textBoxOutputFile);
            this.groupBox5.Controls.Add(this.buttonOutputFile);
            this.groupBox5.Location = new System.Drawing.Point(6, 74);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(519, 57);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Вихідний";
            // 
            // linkLabelOutFileEntropy
            // 
            this.linkLabelOutFileEntropy.AutoSize = true;
            this.linkLabelOutFileEntropy.LinkArea = new System.Windows.Forms.LinkArea(11, 20);
            this.linkLabelOutFileEntropy.Location = new System.Drawing.Point(6, 39);
            this.linkLabelOutFileEntropy.Name = "linkLabelOutFileEntropy";
            this.linkLabelOutFileEntropy.Size = new System.Drawing.Size(61, 17);
            this.linkLabelOutFileEntropy.TabIndex = 9;
            this.linkLabelOutFileEntropy.Text = "Ентропія: -";
            this.toolTip1.SetToolTip(this.linkLabelOutFileEntropy, "копіювати значення ентропії до буферу обміну");
            this.linkLabelOutFileEntropy.UseCompatibleTextRendering = true;
            this.linkLabelOutFileEntropy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOutFileEntropy_LinkClicked);
            // 
            // textBoxOutputFile
            // 
            this.textBoxOutputFile.Location = new System.Drawing.Point(6, 16);
            this.textBoxOutputFile.Name = "textBoxOutputFile";
            this.textBoxOutputFile.ReadOnly = true;
            this.textBoxOutputFile.Size = new System.Drawing.Size(457, 20);
            this.textBoxOutputFile.TabIndex = 3;
            // 
            // buttonOutputFile
            // 
            this.buttonOutputFile.Location = new System.Drawing.Point(468, 14);
            this.buttonOutputFile.Name = "buttonOutputFile";
            this.buttonOutputFile.Size = new System.Drawing.Size(45, 24);
            this.buttonOutputFile.TabIndex = 5;
            this.buttonOutputFile.Text = "...";
            this.toolTip1.SetToolTip(this.buttonOutputFile, "Обрати вихідний файл");
            this.buttonOutputFile.UseVisualStyleBackColor = true;
            this.buttonOutputFile.Click += new System.EventHandler(this.buttonOutputFile_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(556, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAboutProgram});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuItem1.Text = "Довідка";
            // 
            // toolStripMenuItemAboutProgram
            // 
            this.toolStripMenuItemAboutProgram.Name = "toolStripMenuItemAboutProgram";
            this.toolStripMenuItemAboutProgram.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItemAboutProgram.Text = "Про програму";
            this.toolStripMenuItemAboutProgram.Click += new System.EventHandler(this.toolStripMenuItemAboutProgram_Click);
            // 
            // groupBoxSetings
            // 
            this.groupBoxSetings.Controls.Add(this.checkBoxIVTo0);
            this.groupBoxSetings.Controls.Add(this.button2);
            this.groupBoxSetings.Controls.Add(this.buttonSave);
            this.groupBoxSetings.Controls.Add(this.buttonGenerateVI);
            this.groupBoxSetings.Controls.Add(this.labelVI);
            this.groupBoxSetings.Controls.Add(this.buttonGenerateKey);
            this.groupBoxSetings.Controls.Add(this.labelKey);
            this.groupBoxSetings.Controls.Add(this.label3);
            this.groupBoxSetings.Controls.Add(this.comboBoxKeyLength);
            this.groupBoxSetings.Controls.Add(this.groupBoxAlg);
            this.groupBoxSetings.Location = new System.Drawing.Point(12, 171);
            this.groupBoxSetings.Name = "groupBoxSetings";
            this.groupBoxSetings.Size = new System.Drawing.Size(531, 208);
            this.groupBoxSetings.TabIndex = 3;
            this.groupBoxSetings.TabStop = false;
            this.groupBoxSetings.Text = "Параметри";
            // 
            // checkBoxIVTo0
            // 
            this.checkBoxIVTo0.AutoSize = true;
            this.checkBoxIVTo0.Location = new System.Drawing.Point(353, 98);
            this.checkBoxIVTo0.Name = "checkBoxIVTo0";
            this.checkBoxIVTo0.Size = new System.Drawing.Size(54, 17);
            this.checkBoxIVTo0.TabIndex = 9;
            this.checkBoxIVTo0.Text = "ВІ = 0";
            this.toolTip1.SetToolTip(this.checkBoxIVTo0, "Заповнення Вектора Ініціалізації нулями");
            this.checkBoxIVTo0.UseVisualStyleBackColor = true;
            this.checkBoxIVTo0.CheckedChanged += new System.EventHandler(this.checkBoxIVTo0_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Image = global::NetCryptography.Properties.Resources.folder;
            this.button2.Location = new System.Drawing.Point(470, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(55, 32);
            this.button2.TabIndex = 8;
            this.toolTip1.SetToolTip(this.button2, "Відновити збережені параметри");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Image = global::NetCryptography.Properties.Resources.disk;
            this.buttonSave.Location = new System.Drawing.Point(409, 13);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(55, 32);
            this.buttonSave.TabIndex = 7;
            this.toolTip1.SetToolTip(this.buttonSave, "Зберегти поточні параметри");
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonGenerateVI
            // 
            this.buttonGenerateVI.Image = global::NetCryptography.Properties.Resources.hand_30x30;
            this.buttonGenerateVI.Location = new System.Drawing.Point(291, 89);
            this.buttonGenerateVI.Name = "buttonGenerateVI";
            this.buttonGenerateVI.Size = new System.Drawing.Size(55, 32);
            this.buttonGenerateVI.TabIndex = 6;
            this.toolTip1.SetToolTip(this.buttonGenerateVI, "Генерувати новий Вектор Ініціалізації");
            this.buttonGenerateVI.UseVisualStyleBackColor = true;
            this.buttonGenerateVI.Click += new System.EventHandler(this.buttonGenerateVI_Click);
            // 
            // labelVI
            // 
            this.labelVI.AutoSize = true;
            this.labelVI.Location = new System.Drawing.Point(9, 97);
            this.labelVI.Name = "labelVI";
            this.labelVI.Size = new System.Drawing.Size(102, 13);
            this.labelVI.TabIndex = 5;
            this.labelVI.Text = "Вектор Ініціалізації";
            // 
            // buttonGenerateKey
            // 
            this.buttonGenerateKey.Image = global::NetCryptography.Properties.Resources.new_key;
            this.buttonGenerateKey.Location = new System.Drawing.Point(291, 51);
            this.buttonGenerateKey.Name = "buttonGenerateKey";
            this.buttonGenerateKey.Size = new System.Drawing.Size(55, 32);
            this.buttonGenerateKey.TabIndex = 4;
            this.toolTip1.SetToolTip(this.buttonGenerateKey, "Генерувати новий ключ шифрування");
            this.buttonGenerateKey.UseVisualStyleBackColor = true;
            this.buttonGenerateKey.Click += new System.EventHandler(this.buttonGenerateKey_Click);
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(9, 41);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(33, 13);
            this.labelKey.TabIndex = 3;
            this.labelKey.Text = "Ключ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Довжина ключа (біт):";
            // 
            // comboBoxKeyLength
            // 
            this.comboBoxKeyLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKeyLength.FormattingEnabled = true;
            this.comboBoxKeyLength.Location = new System.Drawing.Point(128, 19);
            this.comboBoxKeyLength.Name = "comboBoxKeyLength";
            this.comboBoxKeyLength.Size = new System.Drawing.Size(47, 21);
            this.comboBoxKeyLength.TabIndex = 1;
            this.toolTip1.SetToolTip(this.comboBoxKeyLength, "Змінити розмір ключа шифрування");
            this.comboBoxKeyLength.SelectedIndexChanged += new System.EventHandler(this.comboBoxKeyLength_SelectedIndexChanged);
            // 
            // groupBoxAlg
            // 
            this.groupBoxAlg.Controls.Add(this.radioButtonRijndael);
            this.groupBoxAlg.Controls.Add(this.radioButtonRC2);
            this.groupBoxAlg.Controls.Add(this.radioButtonTripleDES);
            this.groupBoxAlg.Controls.Add(this.radioButtonDES);
            this.groupBoxAlg.Controls.Add(this.radioButtonAES);
            this.groupBoxAlg.Location = new System.Drawing.Point(6, 154);
            this.groupBoxAlg.Name = "groupBoxAlg";
            this.groupBoxAlg.Size = new System.Drawing.Size(519, 48);
            this.groupBoxAlg.TabIndex = 0;
            this.groupBoxAlg.TabStop = false;
            this.groupBoxAlg.Text = "Алгоритм шифрування";
            // 
            // radioButtonRijndael
            // 
            this.radioButtonRijndael.AutoSize = true;
            this.radioButtonRijndael.Location = new System.Drawing.Point(58, 19);
            this.radioButtonRijndael.Name = "radioButtonRijndael";
            this.radioButtonRijndael.Size = new System.Drawing.Size(63, 17);
            this.radioButtonRijndael.TabIndex = 4;
            this.radioButtonRijndael.Text = "Rijndael";
            this.radioButtonRijndael.UseVisualStyleBackColor = true;
            this.radioButtonRijndael.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonRC2
            // 
            this.radioButtonRC2.AutoSize = true;
            this.radioButtonRC2.Location = new System.Drawing.Point(259, 19);
            this.radioButtonRC2.Name = "radioButtonRC2";
            this.radioButtonRC2.Size = new System.Drawing.Size(46, 17);
            this.radioButtonRC2.TabIndex = 3;
            this.radioButtonRC2.Text = "RC2";
            this.radioButtonRC2.UseVisualStyleBackColor = true;
            this.radioButtonRC2.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonTripleDES
            // 
            this.radioButtonTripleDES.AutoSize = true;
            this.radioButtonTripleDES.Location = new System.Drawing.Point(180, 19);
            this.radioButtonTripleDES.Name = "radioButtonTripleDES";
            this.radioButtonTripleDES.Size = new System.Drawing.Size(73, 17);
            this.radioButtonTripleDES.TabIndex = 2;
            this.radioButtonTripleDES.Text = "TripleDES";
            this.radioButtonTripleDES.UseVisualStyleBackColor = true;
            this.radioButtonTripleDES.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonDES
            // 
            this.radioButtonDES.AutoSize = true;
            this.radioButtonDES.Location = new System.Drawing.Point(127, 19);
            this.radioButtonDES.Name = "radioButtonDES";
            this.radioButtonDES.Size = new System.Drawing.Size(47, 17);
            this.radioButtonDES.TabIndex = 1;
            this.radioButtonDES.Text = "DES";
            this.radioButtonDES.UseVisualStyleBackColor = true;
            this.radioButtonDES.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonAES
            // 
            this.radioButtonAES.AutoSize = true;
            this.radioButtonAES.Location = new System.Drawing.Point(6, 19);
            this.radioButtonAES.Name = "radioButtonAES";
            this.radioButtonAES.Size = new System.Drawing.Size(46, 17);
            this.radioButtonAES.TabIndex = 0;
            this.radioButtonAES.Text = "AES";
            this.radioButtonAES.UseVisualStyleBackColor = true;
            this.radioButtonAES.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(12, 385);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(102, 24);
            this.buttonEncrypt.TabIndex = 4;
            this.buttonEncrypt.Text = "Шифрувати";
            this.toolTip1.SetToolTip(this.buttonEncrypt, "Почати процес Шифрування");
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(120, 385);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(102, 24);
            this.buttonDecrypt.TabIndex = 5;
            this.buttonDecrypt.Text = "Розшифрувати";
            this.toolTip1.SetToolTip(this.buttonDecrypt, "Почати процес Розшифрування");
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 415);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(531, 23);
            this.progressBar1.TabIndex = 6;
            this.toolTip1.SetToolTip(this.progressBar1, "прогрес шифрування/розшифрування");
            this.progressBar1.Visible = false;
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(228, 385);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(102, 24);
            this.buttonStop.TabIndex = 8;
            this.buttonStop.Text = "Зупинити";
            this.toolTip1.SetToolTip(this.buttonStop, "зупинити процес шифрування/дешифрування");
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(346, 391);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(96, 13);
            this.labelTime.TabIndex = 7;
            this.labelTime.Text = "Час розрахунку: -";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 444);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.buttonEncrypt);
            this.Controls.Add(this.groupBoxSetings);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".Net Cryptography";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxSetings.ResumeLayout(false);
            this.groupBoxSetings.PerformLayout();
            this.groupBoxAlg.ResumeLayout(false);
            this.groupBoxAlg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button buttonOutputFile;
        private System.Windows.Forms.Button buttonInputFile;
        private System.Windows.Forms.TextBox textBoxOutputFile;
        private System.Windows.Forms.TextBox textBoxInputFile;
        private System.Windows.Forms.GroupBox groupBoxSetings;
        private System.Windows.Forms.GroupBox groupBoxAlg;
        private System.Windows.Forms.RadioButton radioButtonRijndael;
        private System.Windows.Forms.RadioButton radioButtonRC2;
        private System.Windows.Forms.RadioButton radioButtonTripleDES;
        private System.Windows.Forms.RadioButton radioButtonDES;
        private System.Windows.Forms.RadioButton radioButtonAES;
        private System.Windows.Forms.Button buttonGenerateKey;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxKeyLength;
        private System.Windows.Forms.Label labelVI;
        private System.Windows.Forms.Button buttonGenerateVI;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAboutProgram;
        private System.Windows.Forms.Label labelFileSize;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.LinkLabel linkLabelInFileEntropy;
        private System.Windows.Forms.LinkLabel linkLabelOutFileEntropy;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxIVTo0;
    }
}

