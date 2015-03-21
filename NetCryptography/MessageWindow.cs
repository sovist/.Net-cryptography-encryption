using System;
using System.Threading;
using System.Windows.Forms;

namespace NetCryptography
{
    public class MessageWindow : Form
    {
        private readonly System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this._labelShowInfo = new System.Windows.Forms.Label();
            this._groupBoxRec = new System.Windows.Forms.GroupBox();
            this._pictureBox1 = new System.Windows.Forms.PictureBox();
            this._groupBoxRec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _labelShowInfo
            // 
            this._labelShowInfo.AutoSize = true;
            this._labelShowInfo.Location = new System.Drawing.Point(4, 10);
            this._labelShowInfo.Name = "_labelShowInfo";
            this._labelShowInfo.Size = new System.Drawing.Size(35, 13);
            this._labelShowInfo.TabIndex = 0;
            this._labelShowInfo.Text = "label1";
            // 
            // _groupBoxRec
            // 
            this._groupBoxRec.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._groupBoxRec.Controls.Add(this._labelShowInfo);
            this._groupBoxRec.Cursor = System.Windows.Forms.Cursors.No;
            this._groupBoxRec.Location = new System.Drawing.Point(52, -3);
            this._groupBoxRec.Name = "_groupBoxRec";
            this._groupBoxRec.Size = new System.Drawing.Size(455, 124);
            this._groupBoxRec.TabIndex = 1;
            this._groupBoxRec.TabStop = false;
            // 
            // _pictureBox1
            // 
            this._pictureBox1.Image = global::NetCryptography.Properties.Resources.Information_icon__1_2;
            this._pictureBox1.Location = new System.Drawing.Point(3, 2);
            this._pictureBox1.Name = "_pictureBox1";
            this._pictureBox1.Size = new System.Drawing.Size(48, 48);
            this._pictureBox1.TabIndex = 3;
            this._pictureBox1.TabStop = false;
            // 
            // MessageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(728, 199);
            this.Controls.Add(this._pictureBox1);
            this.Controls.Add(this._groupBoxRec);
            this.Cursor = System.Windows.Forms.Cursors.No;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this._groupBoxRec.ResumeLayout(false);
            this._groupBoxRec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox _groupBoxRec;
        private PictureBox _pictureBox1;
        private Label _labelShowInfo;
        private bool _exit = false;

        /// <summary>
        /// Метод інфрмаційне відображає вікно в потоці яким був викликаний. Потік призупинется на showTime секунд.
        /// Доцільніше використати статичний метод Show()
        /// </summary>
        /// <param name="showTime">час відображення інформаційного вікна</param>
        /// <param name="showInfo">інформація, що буде виведена</param>
        public MessageWindow(double showTime, string showInfo)
        {
            InitializeComponent();
            _labelShowInfo.Text = showInfo;
            Left = Cursor.Position.X;
            Top = Cursor.Position.Y + 15;

            //string[] lines = Regex.Replace(showInfo.TrimStart(' '), @"\s+", " ").Split(' ');

            _groupBoxRec.Width = _labelShowInfo.Width + 5;
            _groupBoxRec.Height = _labelShowInfo.Height + 15;

            Height = _groupBoxRec.Height;
            Width = _groupBoxRec.Width;

            _pictureBox1.Top = (Height - _pictureBox1.Height) / 2;

            Cursor.Hide();
            Show();
            Application.DoEvents();
            Thread.Sleep((int) (showTime*1000));
            Close();
        }

        /// Метод інфрмаційне відображає вікно в потоці яким був викликаний. Потік призупинется на showTime секунд.
        /// Доцільніше використати статичний метод Show()
        /// <param name="maxShowTime">максимальний час очікування в секундах</param>
        /// <param name="showInfo">інформація, що буде виведена</param>  
        public MessageWindow(string showInfo, int maxShowTime = 5, int x = 0, int y = 0)
        {
            InitializeComponent();
            _labelShowInfo.Text = showInfo;
            Left = x == 0 ? Cursor.Position.X : x;
            Top = y == 0 ? Cursor.Position.Y + 15 : y;

            _groupBoxRec.Width = _labelShowInfo.Width + 5;
            _groupBoxRec.Height = _labelShowInfo.Height + 15;
            
            Height = _groupBoxRec.Height;
            Width = _groupBoxRec.Width;

            _pictureBox1.Top = (Height - _pictureBox1.Height) / 2;

            Cursor.Hide();
            Show();
            Application.DoEvents();

            DateTime dateTime = DateTime.Now;
            int xx = Cursor.Position.X;
            int yy = Cursor.Position.Y;
            while ((DateTime.Now - dateTime).Seconds <= maxShowTime && Cursor.Position.X == xx && Cursor.Position.Y == yy && !_exit)
                Thread.Sleep(100);       
            Close();
        }
       
        /// <summary>
        /// Метод створює новий потік в якому відображається інфрмаційне вікно 
        /// </summary>
        /// <param name="showTime">час відображення інформаційного вікна в секундах</param>
        /// <param name="showInfo">інформація, що буде виведена</param>
        public static void Show(double showTime, string showInfo)
        {
            (new Thread(() => { new MessageWindow(showTime, showInfo); })).Start();
        }

        /// <summary>
        /// Метод створює новий потік в якому відображається інфрмаційне вікно.
        /// </summary> 
        /// <param name="showInfo">інформація, що буде виведена</param>    
        /// <param name="maxShowTime">максимальний час очікування в секундах</param>
        public static void Show(string showInfo, int maxShowTime = 5, int x = 0, int y = 0)
        {
            (new Thread(() => { new MessageWindow(showInfo, maxShowTime, x, y); })).Start();
        }
    }
}
