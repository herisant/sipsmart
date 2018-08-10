namespace SIP
{
    partial class FormDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDownload));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnDownload = new Bunifu.Framework.UI.BunifuThinButton2();
            this.pgBar = new Bunifu.Framework.UI.BunifuProgressBar();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.labelInformasi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 121);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(435, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Roboto Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(24, 9);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(389, 25);
            this.bunifuCustomLabel1.TabIndex = 1;
            this.bunifuCustomLabel1.Text = "Form Download Master Siswa dan Guru";
            // 
            // btnDownload
            // 
            this.btnDownload.ActiveBorderThickness = 1;
            this.btnDownload.ActiveCornerRadius = 20;
            this.btnDownload.ActiveFillColor = System.Drawing.Color.DodgerBlue;
            this.btnDownload.ActiveForecolor = System.Drawing.Color.Black;
            this.btnDownload.ActiveLineColor = System.Drawing.Color.Red;
            this.btnDownload.BackColor = System.Drawing.SystemColors.Control;
            this.btnDownload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDownload.BackgroundImage")));
            this.btnDownload.ButtonText = "DOWNLOAD";
            this.btnDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownload.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnDownload.IdleBorderThickness = 1;
            this.btnDownload.IdleCornerRadius = 20;
            this.btnDownload.IdleFillColor = System.Drawing.Color.White;
            this.btnDownload.IdleForecolor = System.Drawing.Color.Black;
            this.btnDownload.IdleLineColor = System.Drawing.Color.RoyalBlue;
            this.btnDownload.Location = new System.Drawing.Point(85, 45);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(5);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(255, 41);
            this.btnDownload.TabIndex = 13;
            this.btnDownload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // pgBar
            // 
            this.pgBar.BackColor = System.Drawing.Color.Transparent;
            this.pgBar.BorderRadius = 5;
            this.pgBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgBar.Location = new System.Drawing.Point(0, 111);
            this.pgBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pgBar.MaximumValue = 100;
            this.pgBar.Name = "pgBar";
            this.pgBar.ProgressColor = System.Drawing.Color.Crimson;
            this.pgBar.Size = new System.Drawing.Size(435, 10);
            this.pgBar.TabIndex = 14;
            this.pgBar.Value = 0;
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            // 
            // labelInformasi
            // 
            this.labelInformasi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelInformasi.Location = new System.Drawing.Point(0, 93);
            this.labelInformasi.Name = "labelInformasi";
            this.labelInformasi.Size = new System.Drawing.Size(435, 18);
            this.labelInformasi.TabIndex = 15;
            this.labelInformasi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 143);
            this.Controls.Add(this.labelInformasi);
            this.Controls.Add(this.pgBar);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnDownload;
        private Bunifu.Framework.UI.BunifuProgressBar pgBar;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Label labelInformasi;
    }
}