namespace tradeapp
{
    partial class adminpanel
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
            this.geri_butonu = new System.Windows.Forms.Button();
            this.onay_listesi = new System.Windows.Forms.ListBox();
            this.onayla_butonu = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.usd_kuru = new System.Windows.Forms.Label();
            this.eur_kuru = new System.Windows.Forms.Label();
            this.gbp_kuru = new System.Windows.Forms.Label();
            this.admin_para = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // geri_butonu
            // 
            this.geri_butonu.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.geri_butonu.Location = new System.Drawing.Point(12, 12);
            this.geri_butonu.Name = "geri_butonu";
            this.geri_butonu.Size = new System.Drawing.Size(150, 40);
            this.geri_butonu.TabIndex = 21;
            this.geri_butonu.Text = "Geri";
            this.geri_butonu.UseVisualStyleBackColor = true;
            this.geri_butonu.Click += new System.EventHandler(this.geri_butonu_Click);
            // 
            // onay_listesi
            // 
            this.onay_listesi.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.onay_listesi.FormattingEnabled = true;
            this.onay_listesi.ItemHeight = 30;
            this.onay_listesi.Location = new System.Drawing.Point(12, 105);
            this.onay_listesi.Name = "onay_listesi";
            this.onay_listesi.Size = new System.Drawing.Size(1081, 484);
            this.onay_listesi.TabIndex = 23;
            // 
            // onayla_butonu
            // 
            this.onayla_butonu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.onayla_butonu.Location = new System.Drawing.Point(1115, 213);
            this.onayla_butonu.Name = "onayla_butonu";
            this.onayla_butonu.Size = new System.Drawing.Size(150, 154);
            this.onayla_butonu.TabIndex = 24;
            this.onayla_butonu.Text = "Ekleme İşlemini Onayla";
            this.onayla_butonu.UseVisualStyleBackColor = true;
            this.onayla_butonu.Click += new System.EventHandler(this.onayla_butonu_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(240, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 29);
            this.label4.TabIndex = 28;
            this.label4.Text = "USD";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(490, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 29);
            this.label5.TabIndex = 29;
            this.label5.Text = "EUR";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(740, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 29);
            this.label6.TabIndex = 30;
            this.label6.Text = "GBP";
            // 
            // usd_kuru
            // 
            this.usd_kuru.AutoSize = true;
            this.usd_kuru.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.usd_kuru.Location = new System.Drawing.Point(314, 20);
            this.usd_kuru.Name = "usd_kuru";
            this.usd_kuru.Size = new System.Drawing.Size(25, 29);
            this.usd_kuru.TabIndex = 31;
            this.usd_kuru.Text = "x";
            // 
            // eur_kuru
            // 
            this.eur_kuru.AutoSize = true;
            this.eur_kuru.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.eur_kuru.Location = new System.Drawing.Point(562, 20);
            this.eur_kuru.Name = "eur_kuru";
            this.eur_kuru.Size = new System.Drawing.Size(25, 29);
            this.eur_kuru.TabIndex = 32;
            this.eur_kuru.Text = "x";
            // 
            // gbp_kuru
            // 
            this.gbp_kuru.AutoSize = true;
            this.gbp_kuru.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbp_kuru.Location = new System.Drawing.Point(812, 20);
            this.gbp_kuru.Name = "gbp_kuru";
            this.gbp_kuru.Size = new System.Drawing.Size(25, 29);
            this.gbp_kuru.TabIndex = 33;
            this.gbp_kuru.Text = "x";
            // 
            // admin_para
            // 
            this.admin_para.AutoSize = true;
            this.admin_para.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.admin_para.Location = new System.Drawing.Point(1064, 20);
            this.admin_para.Name = "admin_para";
            this.admin_para.Size = new System.Drawing.Size(25, 29);
            this.admin_para.TabIndex = 35;
            this.admin_para.Text = "x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(990, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 29);
            this.label2.TabIndex = 34;
            this.label2.Text = "PARA";
            // 
            // adminpanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1282, 653);
            this.Controls.Add(this.admin_para);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbp_kuru);
            this.Controls.Add(this.eur_kuru);
            this.Controls.Add(this.usd_kuru);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.onayla_butonu);
            this.Controls.Add(this.onay_listesi);
            this.Controls.Add(this.geri_butonu);
            this.Name = "adminpanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Panel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.adminpanel_FormClosed);
            this.Load += new System.EventHandler(this.adminpanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button geri_butonu;
        private System.Windows.Forms.ListBox onay_listesi;
        public System.Windows.Forms.Button onayla_butonu;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label usd_kuru;
        public System.Windows.Forms.Label eur_kuru;
        public System.Windows.Forms.Label gbp_kuru;
        public System.Windows.Forms.Label admin_para;
        public System.Windows.Forms.Label label2;
    }
}