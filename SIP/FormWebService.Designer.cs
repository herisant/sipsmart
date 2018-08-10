namespace SIP
{
    partial class FormWebService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWebService));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtAbsen = new System.Windows.Forms.TextBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtMasterData = new System.Windows.Forms.TextBox();
            this.btnSimpan = new Bunifu.Framework.UI.BunifuThinButton2();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 146);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(576, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Roboto Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(12, 28);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(123, 25);
            this.bunifuCustomLabel3.TabIndex = 1;
            this.bunifuCustomLabel3.Text = "URL ABSEN";
            // 
            // txtAbsen
            // 
            this.txtAbsen.Location = new System.Drawing.Point(213, 28);
            this.txtAbsen.Name = "txtAbsen";
            this.txtAbsen.Size = new System.Drawing.Size(351, 25);
            this.txtAbsen.TabIndex = 2;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Roboto Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(12, 56);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(195, 25);
            this.bunifuCustomLabel1.TabIndex = 1;
            this.bunifuCustomLabel1.Text = "URL MASTER DATA";
            // 
            // txtMasterData
            // 
            this.txtMasterData.Location = new System.Drawing.Point(213, 56);
            this.txtMasterData.Name = "txtMasterData";
            this.txtMasterData.Size = new System.Drawing.Size(351, 25);
            this.txtMasterData.TabIndex = 2;
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
            this.btnSimpan.ButtonText = "CREATE";
            this.btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSimpan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnSimpan.IdleBorderThickness = 1;
            this.btnSimpan.IdleCornerRadius = 20;
            this.btnSimpan.IdleFillColor = System.Drawing.Color.White;
            this.btnSimpan.IdleForecolor = System.Drawing.Color.Black;
            this.btnSimpan.IdleLineColor = System.Drawing.Color.RoyalBlue;
            this.btnSimpan.Location = new System.Drawing.Point(378, 89);
            this.btnSimpan.Margin = new System.Windows.Forms.Padding(5);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(186, 41);
            this.btnSimpan.TabIndex = 8;
            this.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // FormWebService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 168);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.txtMasterData);
            this.Controls.Add(this.txtAbsen);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWebService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Service";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWebService_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private System.Windows.Forms.TextBox txtAbsen;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.TextBox txtMasterData;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSimpan;
    }
}