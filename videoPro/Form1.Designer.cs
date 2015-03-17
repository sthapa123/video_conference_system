namespace videoPro
{
    partial class Form1
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
            this.pictureBoxPeer1 = new System.Windows.Forms.PictureBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.WebCamCapture = new WebCam_Capture.WebCamCapture();
            this.Capturing = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxPeer2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPeer1Port = new System.Windows.Forms.TextBox();
            this.textBoxPeer2Port = new System.Windows.Forms.TextBox();
            this.textBoxPeer2IP = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPeer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPeer2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxPeer1
            // 
            this.pictureBoxPeer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxPeer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPeer1.Location = new System.Drawing.Point(518, 52);
            this.pictureBoxPeer1.Name = "pictureBoxPeer1";
            this.pictureBoxPeer1.Size = new System.Drawing.Size(344, 269);
            this.pictureBoxPeer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPeer1.TabIndex = 0;
            this.pictureBoxPeer1.TabStop = false;
            // 
            // buttonStart
            // 
            this.buttonStart.BackgroundImage = global::videoPro.Properties.Resources._98__2_;
            this.buttonStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonStart.Font = new System.Drawing.Font("Tahoma", 11F);
            this.buttonStart.Location = new System.Drawing.Point(33, 20);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(112, 52);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // WebCamCapture
            // 
            this.WebCamCapture.CaptureHeight = 240;
            this.WebCamCapture.CaptureWidth = 320;
            this.WebCamCapture.FrameNumber = ((ulong)(0ul));
            this.WebCamCapture.Location = new System.Drawing.Point(17, 17);
            this.WebCamCapture.Name = "WebCamCapture";
            this.WebCamCapture.Size = new System.Drawing.Size(342, 252);
            this.WebCamCapture.TabIndex = 0;
            this.WebCamCapture.TimeToCapture_milliseconds = 100;
            this.WebCamCapture.ImageCaptured += new WebCam_Capture.WebCamCapture.WebCamEventHandler(this.WebCamCapture_ImageCaptured);
            // 
            // Capturing
            // 
            this.Capturing.Interval = 10;
            this.Capturing.Tick += new System.EventHandler(this.Capturing_Tick);
            // 
            // pictureBoxPeer2
            // 
            this.pictureBoxPeer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPeer2.Location = new System.Drawing.Point(12, 52);
            this.pictureBoxPeer2.Name = "pictureBoxPeer2";
            this.pictureBoxPeer2.Size = new System.Drawing.Size(481, 359);
            this.pictureBoxPeer2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPeer2.TabIndex = 2;
            this.pictureBoxPeer2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxPeer1Port);
            this.panel1.Controls.Add(this.textBoxPeer2Port);
            this.panel1.Controls.Add(this.textBoxPeer2IP);
            this.panel1.Location = new System.Drawing.Point(518, 379);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 143);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Your Port Num :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Receiver Port Num :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Reciever IP :";
            // 
            // textBoxPeer1Port
            // 
            this.textBoxPeer1Port.Location = new System.Drawing.Point(174, 96);
            this.textBoxPeer1Port.Name = "textBoxPeer1Port";
            this.textBoxPeer1Port.Size = new System.Drawing.Size(131, 20);
            this.textBoxPeer1Port.TabIndex = 2;
            this.textBoxPeer1Port.Text = "50001";
            // 
            // textBoxPeer2Port
            // 
            this.textBoxPeer2Port.Location = new System.Drawing.Point(174, 57);
            this.textBoxPeer2Port.Name = "textBoxPeer2Port";
            this.textBoxPeer2Port.Size = new System.Drawing.Size(131, 20);
            this.textBoxPeer2Port.TabIndex = 1;
            this.textBoxPeer2Port.Text = "50000";
            // 
            // textBoxPeer2IP
            // 
            this.textBoxPeer2IP.Location = new System.Drawing.Point(174, 20);
            this.textBoxPeer2IP.Name = "textBoxPeer2IP";
            this.textBoxPeer2IP.Size = new System.Drawing.Size(131, 20);
            this.textBoxPeer2IP.TabIndex = 0;
            this.textBoxPeer2IP.Text = "192.168.10.100";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.buttonEnd);
            this.panel2.Controls.Add(this.buttonStop);
            this.panel2.Controls.Add(this.buttonStart);
            this.panel2.Location = new System.Drawing.Point(12, 426);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(481, 100);
            this.panel2.TabIndex = 4;
            // 
            // buttonEnd
            // 
            this.buttonEnd.BackgroundImage = global::videoPro.Properties.Resources._116__2_;
            this.buttonEnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonEnd.Font = new System.Drawing.Font("Tahoma", 10F);
            this.buttonEnd.Location = new System.Drawing.Point(335, 20);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(115, 53);
            this.buttonEnd.TabIndex = 3;
            this.buttonEnd.UseVisualStyleBackColor = true;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.BackgroundImage = global::videoPro.Properties.Resources._91__2_;
            this.buttonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonStop.Font = new System.Drawing.Font("Tahoma", 14F);
            this.buttonStop.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.buttonStop.Location = new System.Drawing.Point(181, 21);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(113, 52);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackgroundImage = global::videoPro.Properties.Resources._48__3_;
            this.buttonRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRefresh.Font = new System.Drawing.Font("Tahoma", 10F);
            this.buttonRefresh.Location = new System.Drawing.Point(518, 327);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(86, 36);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(189, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Receiver Camera";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(636, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "My Camera";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 20F);
            this.label6.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label6.Location = new System.Drawing.Point(353, -2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(223, 33);
            this.label6.TabIndex = 8;
            this.label6.Text = "Video Conference";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::videoPro.Properties.Resources.autorun_silver_bground__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(874, 534);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxPeer2);
            this.Controls.Add(this.pictureBoxPeer1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPeer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPeer2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPeer1;
        private System.Windows.Forms.Button buttonStart;
        private WebCam_Capture.WebCamCapture WebCamCapture;
        private System.Windows.Forms.Timer Capturing;
        private System.Windows.Forms.PictureBox pictureBoxPeer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPeer1Port;
        private System.Windows.Forms.TextBox textBoxPeer2Port;
        private System.Windows.Forms.TextBox textBoxPeer2IP;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonEnd;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

