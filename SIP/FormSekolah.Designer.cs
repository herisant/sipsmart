namespace SIP
{
    partial class FormSekolah
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSekolah));
            this.btnSimpanIdentitas = new Bunifu.Framework.UI.BunifuThinButton2();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtKode = new System.Windows.Forms.TextBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
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
            this.btnSimpanIdentitas.Location = new System.Drawing.Point(299, 77);
            this.btnSimpanIdentitas.Margin = new System.Windows.Forms.Padding(5);
            this.btnSimpanIdentitas.Name = "btnSimpanIdentitas";
            this.btnSimpanIdentitas.Size = new System.Drawing.Size(181, 52);
            this.btnSimpanIdentitas.TabIndex = 8;
            this.btnSimpanIdentitas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSimpanIdentitas.Click += new System.EventHandler(this.btnSimpanIdentitas_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 136);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(492, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtKode
            // 
            this.txtKode.Location = new System.Drawing.Point(198, 15);
            this.txtKode.Name = "txtKode";
            this.txtKode.Size = new System.Drawing.Size(282, 22);
            this.txtKode.TabIndex = 10;
            this.txtKode.TextChanged += new System.EventHandler(this.txtKode_TextChanged);
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(198, 44);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(282, 22);
            this.txtNama.TabIndex = 10;
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(20, 44);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(172, 24);
            this.bunifuCustomLabel5.TabIndex = 4;
            this.bunifuCustomLabel5.Text = "NAMA SEKOLAH";
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(20, 12);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(169, 24);
            this.bunifuCustomLabel4.TabIndex = 5;
            this.bunifuCustomLabel4.Text = "KODE SEKOLAH";
            // 
            // FormSekolah
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 158);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.txtKode);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSimpanIdentitas);
            this.Controls.Add(this.bunifuCustomLabel5);
            this.Controls.Add(this.bunifuCustomLabel4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSekolah";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSekolah_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuThinButton2 btnSimpanIdentitas;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox txtKode;
        private System.Windows.Forms.TextBox txtNama;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
    }
}