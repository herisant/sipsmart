namespace SIP
{
    partial class FormDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDevice));
            this.TextReader = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.cmbReader = new System.Windows.Forms.ComboBox();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnSimpan = new Bunifu.Framework.UI.BunifuThinButton2();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SuspendLayout();
            // 
            // TextReader
            // 
            this.TextReader.BorderColor = System.Drawing.Color.SeaGreen;
            this.TextReader.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextReader.Location = new System.Drawing.Point(167, 54);
            this.TextReader.Name = "TextReader";
            this.TextReader.Size = new System.Drawing.Size(302, 29);
            this.TextReader.TabIndex = 14;
            // 
            // cmbReader
            // 
            this.cmbReader.Font = new System.Drawing.Font("Roboto Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReader.FormattingEnabled = true;
            this.cmbReader.Items.AddRange(new object[] {
            "READER 1",
            "READER 2",
            "READER 3",
            "READER 4",
            "READER 5",
            "READER 6"});
            this.cmbReader.Location = new System.Drawing.Point(167, 12);
            this.cmbReader.Name = "cmbReader";
            this.cmbReader.Size = new System.Drawing.Size(302, 36);
            this.cmbReader.TabIndex = 13;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Roboto Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(7, 12);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(147, 25);
            this.bunifuCustomLabel3.TabIndex = 10;
            this.bunifuCustomLabel3.Text = "PILIH READER";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Roboto Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(7, 54);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(96, 25);
            this.bunifuCustomLabel2.TabIndex = 11;
            this.bunifuCustomLabel2.Text = "READER ";
            // 
            // btnSimpan
            // 
            this.btnSimpan.ActiveBorderThickness = 1;
            this.btnSimpan.ActiveCornerRadius = 20;
            this.btnSimpan.ActiveFillColor = System.Drawing.Color.DodgerBlue;
            this.btnSimpan.ActiveForecolor = System.Drawing.Color.Black;
            this.btnSimpan.ActiveLineColor = System.Drawing.Color.Red;
            this.btnSimpan.BackColor = System.Drawing.SystemColors.Control;
            this.btnSimpan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSimpan.BackgroundImage")));
            this.btnSimpan.ButtonText = "SIMPAN";
            this.btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSimpan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnSimpan.IdleBorderThickness = 1;
            this.btnSimpan.IdleCornerRadius = 20;
            this.btnSimpan.IdleFillColor = System.Drawing.Color.White;
            this.btnSimpan.IdleForecolor = System.Drawing.Color.Black;
            this.btnSimpan.IdleLineColor = System.Drawing.Color.RoyalBlue;
            this.btnSimpan.Location = new System.Drawing.Point(359, 91);
            this.btnSimpan.Margin = new System.Windows.Forms.Padding(5);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(110, 41);
            this.btnSimpan.TabIndex = 12;
            this.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 149);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(476, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // FormDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 171);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TextReader);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.cmbReader);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsFormsControlLibrary1.BunifuCustomTextbox TextReader;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSimpan;
        private System.Windows.Forms.ComboBox cmbReader;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}