namespace InputTracker
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.RepaintTimer = new System.Windows.Forms.Timer(this.components);
            this.PicTastatur = new System.Windows.Forms.PictureBox();
            this.PicScreens = new System.Windows.Forms.PictureBox();
            this.LblNumberKlicksStatic = new System.Windows.Forms.Label();
            this.PnlAllNumbers = new System.Windows.Forms.Panel();
            this.LblNumberKeys = new System.Windows.Forms.Label();
            this.LblNumberKlicks = new System.Windows.Forms.Label();
            this.LblNumberKeysStatic = new System.Windows.Forms.Label();
            this.BtnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicTastatur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicScreens)).BeginInit();
            this.PnlAllNumbers.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "InputTracker";
            this.NotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // RepaintTimer
            // 
            this.RepaintTimer.Enabled = true;
            this.RepaintTimer.Interval = 60000;
            this.RepaintTimer.Tick += new System.EventHandler(this.RepaintTimer_Tick);
            // 
            // PicTastatur
            // 
            this.PicTastatur.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PicTastatur.BackgroundImage")));
            this.PicTastatur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PicTastatur.Location = new System.Drawing.Point(56, 302);
            this.PicTastatur.Name = "PicTastatur";
            this.PicTastatur.Size = new System.Drawing.Size(588, 173);
            this.PicTastatur.TabIndex = 4;
            this.PicTastatur.TabStop = false;
            this.PicTastatur.Paint += new System.Windows.Forms.PaintEventHandler(this.PicTastatur_Paint);
            // 
            // PicScreens
            // 
            this.PicScreens.BackColor = System.Drawing.SystemColors.Control;
            this.PicScreens.Location = new System.Drawing.Point(25, 12);
            this.PicScreens.Name = "PicScreens";
            this.PicScreens.Size = new System.Drawing.Size(660, 224);
            this.PicScreens.TabIndex = 5;
            this.PicScreens.TabStop = false;
            this.PicScreens.Paint += new System.Windows.Forms.PaintEventHandler(this.PicScreens_Paint);
            // 
            // LblNumberKlicksStatic
            // 
            this.LblNumberKlicksStatic.AutoSize = true;
            this.LblNumberKlicksStatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumberKlicksStatic.Location = new System.Drawing.Point(3, 13);
            this.LblNumberKlicksStatic.Name = "LblNumberKlicksStatic";
            this.LblNumberKlicksStatic.Size = new System.Drawing.Size(162, 17);
            this.LblNumberKlicksStatic.TabIndex = 2;
            this.LblNumberKlicksStatic.Text = "Mouse Klicks Insgesamt:";
            // 
            // PnlAllNumbers
            // 
            this.PnlAllNumbers.Controls.Add(this.BtnReset);
            this.PnlAllNumbers.Controls.Add(this.LblNumberKeys);
            this.PnlAllNumbers.Controls.Add(this.LblNumberKlicks);
            this.PnlAllNumbers.Controls.Add(this.LblNumberKeysStatic);
            this.PnlAllNumbers.Controls.Add(this.LblNumberKlicksStatic);
            this.PnlAllNumbers.Location = new System.Drawing.Point(56, 242);
            this.PnlAllNumbers.Name = "PnlAllNumbers";
            this.PnlAllNumbers.Size = new System.Drawing.Size(588, 38);
            this.PnlAllNumbers.TabIndex = 6;
            // 
            // LblNumberKeys
            // 
            this.LblNumberKeys.AutoSize = true;
            this.LblNumberKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumberKeys.Location = new System.Drawing.Point(427, 13);
            this.LblNumberKeys.Name = "LblNumberKeys";
            this.LblNumberKeys.Size = new System.Drawing.Size(16, 17);
            this.LblNumberKeys.TabIndex = 5;
            this.LblNumberKeys.Text = "0";
            // 
            // LblNumberKlicks
            // 
            this.LblNumberKlicks.AutoSize = true;
            this.LblNumberKlicks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumberKlicks.Location = new System.Drawing.Point(171, 13);
            this.LblNumberKlicks.Name = "LblNumberKlicks";
            this.LblNumberKlicks.Size = new System.Drawing.Size(16, 17);
            this.LblNumberKlicks.TabIndex = 4;
            this.LblNumberKlicks.Text = "0";
            // 
            // LblNumberKeysStatic
            // 
            this.LblNumberKeysStatic.AutoSize = true;
            this.LblNumberKeysStatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumberKeysStatic.Location = new System.Drawing.Point(230, 13);
            this.LblNumberKeysStatic.Name = "LblNumberKeysStatic";
            this.LblNumberKeysStatic.Size = new System.Drawing.Size(191, 17);
            this.LblNumberKeysStatic.TabIndex = 3;
            this.LblNumberKeysStatic.Text = "Tastur Anschläge Insgesamt:";
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(488, 10);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(75, 23);
            this.BtnReset.TabIndex = 6;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 487);
            this.Controls.Add(this.PicTastatur);
            this.Controls.Add(this.PicScreens);
            this.Controls.Add(this.PnlAllNumbers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.PicTastatur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicScreens)).EndInit();
            this.PnlAllNumbers.ResumeLayout(false);
            this.PnlAllNumbers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.Timer RepaintTimer;
        private System.Windows.Forms.PictureBox PicTastatur;
        private System.Windows.Forms.PictureBox PicScreens;
        private System.Windows.Forms.Label LblNumberKlicksStatic;
        private System.Windows.Forms.Panel PnlAllNumbers;
        private System.Windows.Forms.Label LblNumberKeys;
        private System.Windows.Forms.Label LblNumberKlicks;
        private System.Windows.Forms.Label LblNumberKeysStatic;
        private System.Windows.Forms.Button BtnReset;
    }
}