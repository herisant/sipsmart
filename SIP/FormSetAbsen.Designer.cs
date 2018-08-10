namespace SIP
{
    partial class FormSetAbsen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetAbsen));
            this.btnSimpanIdentitas = new Bunifu.Framework.UI.BunifuThinButton2();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.mulai_masuk = new System.Windows.Forms.DateTimePicker();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.selesai_masuk = new System.Windows.Forms.DateTimePicker();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.mulai_pulang = new System.Windows.Forms.DateTimePicker();
            this.selesai_pulang = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnSimpanIdentitas
            // 
            this.btnSimpanIdentitas.ActiveBorderThickness = 1;
            this.btnSimpanIdentitas.ActiveCornerRadius = 20;
            this.btnSimpanIdentitas.ActiveFillColor = System.Drawing.Color.RoyalBlue;
            this.btnSimpanIdentitas.ActiveForecolor = System.Drawing.Color.Black;
            this.btnSimpanIdentitas.ActiveLineColor = System.Drawing.Color.Silver;
            this.btnSimpanIdentitas.BackColor = System.Drawing.SystemColors.Control;
            this.btnSimpanIdentitas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSimpanIdentitas.BackgroundImage")));
            this.btnSimpanIdentitas.ButtonText = "Simpan";
            this.btnSimpanIdentitas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSimpanIdentitas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpanIdentitas.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnSimpanIdentitas.IdleBorderThickness = 1;
            this.btnSimpanIdentitas.IdleCornerRadius = 20;
            this.btnSimpanIdentitas.IdleFillColor = System.Drawing.Color.White;
            this.btnSimpanIdentitas.IdleForecolor = System.Drawing.Color.Black;
            this.btnSimpanIdentitas.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSimpanIdentitas.Location = new System.Drawing.Point(221, 218);
            this.btnSimpanIdentitas.Margin = new System.Windows.Forms.Padding(5);
            this.btnSimpanIdentitas.Name = "btnSimpanIdentitas";
            this.btnSimpanIdentitas.Size = new System.Drawing.Size(181, 52);
            this.btnSimpanIdentitas.TabIndex = 8;
            this.btnSimpanIdentitas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSimpanIdentitas.Click += new System.EventHandler(this.btnSimpanIdentitas_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 275);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(662, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(12, 9);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(189, 24);
            this.bunifuCustomLabel4.TabIndex = 5;
            this.bunifuCustomLabel4.Text = "Waktu Mulai Masuk";
            // 
            // mulai_masuk
            // 
            this.mulai_masuk.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.mulai_masuk.Location = new System.Drawing.Point(280, 12);
            this.mulai_masuk.Name = "mulai_masuk";
            this.mulai_masuk.ShowUpDown = true;
            this.mulai_masuk.Size = new System.Drawing.Size(200, 22);
            this.mulai_masuk.TabIndex = 16;
            this.mulai_masuk.Value = new System.DateTime(2018, 7, 25, 6, 0, 0, 0);
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(12, 47);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(207, 24);
            this.bunifuCustomLabel1.TabIndex = 17;
            this.bunifuCustomLabel1.Text = "Waktu Selesai Masuk";
            // 
            // selesai_masuk
            // 
            this.selesai_masuk.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.selesai_masuk.Location = new System.Drawing.Point(280, 49);
            this.selesai_masuk.Name = "selesai_masuk";
            this.selesai_masuk.ShowUpDown = true;
            this.selesai_masuk.Size = new System.Drawing.Size(200, 22);
            this.selesai_masuk.TabIndex = 18;
            this.selesai_masuk.Value = new System.DateTime(2018, 7, 25, 7, 30, 0, 0);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(12, 108);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(194, 24);
            this.bunifuCustomLabel2.TabIndex = 19;
            this.bunifuCustomLabel2.Text = "Waktu Mulai Pulang";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(12, 153);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(212, 24);
            this.bunifuCustomLabel3.TabIndex = 20;
            this.bunifuCustomLabel3.Text = "Waktu Selesai Pulang";
            // 
            // mulai_pulang
            // 
            this.mulai_pulang.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.mulai_pulang.Location = new System.Drawing.Point(280, 109);
            this.mulai_pulang.Name = "mulai_pulang";
            this.mulai_pulang.ShowUpDown = true;
            this.mulai_pulang.Size = new System.Drawing.Size(200, 22);
            this.mulai_pulang.TabIndex = 21;
            this.mulai_pulang.Value = new System.DateTime(2018, 7, 25, 0, 0, 0, 0);
            // 
            // selesai_pulang
            // 
            this.selesai_pulang.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.selesai_pulang.Location = new System.Drawing.Point(280, 155);
            this.selesai_pulang.Name = "selesai_pulang";
            this.selesai_pulang.ShowUpDown = true;
            this.selesai_pulang.Size = new System.Drawing.Size(200, 22);
            this.selesai_pulang.TabIndex = 22;
            this.selesai_pulang.Value = new System.DateTime(2018, 7, 25, 15, 0, 0, 0);
            // 
            // FormSetAbsen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 297);
            this.Controls.Add(this.selesai_pulang);
            this.Controls.Add(this.mulai_pulang);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.selesai_masuk);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.mulai_masuk);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSimpanIdentitas);
            this.Controls.Add(this.bunifuCustomLabel4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetAbsen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSekolah_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuThinButton2 btnSimpanIdentitas;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private System.Windows.Forms.DateTimePicker mulai_masuk;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.DateTimePicker selesai_masuk;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private System.Windows.Forms.DateTimePicker mulai_pulang;
        private System.Windows.Forms.DateTimePicker selesai_pulang;
    }
}