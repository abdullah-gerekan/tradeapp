namespace tradeapp
{
    partial class homepage
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.giris_butonu = new System.Windows.Forms.Button();
            this.kayit_butonu = new System.Windows.Forms.Button();
            this.sifre = new System.Windows.Forms.TextBox();
            this.kullanici_adi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // giris_butonu
            // 
            this.giris_butonu.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.giris_butonu.Location = new System.Drawing.Point(666, 395);
            this.giris_butonu.Name = "giris_butonu";
            this.giris_butonu.Size = new System.Drawing.Size(250, 50);
            this.giris_butonu.TabIndex = 20;
            this.giris_butonu.Text = "Giriş";
            this.giris_butonu.UseVisualStyleBackColor = true;
            this.giris_butonu.Click += new System.EventHandler(this.giris_butonu_Click);
            // 
            // kayit_butonu
            // 
            this.kayit_butonu.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kayit_butonu.Location = new System.Drawing.Point(372, 395);
            this.kayit_butonu.Name = "kayit_butonu";
            this.kayit_butonu.Size = new System.Drawing.Size(250, 50);
            this.kayit_butonu.TabIndex = 19;
            this.kayit_butonu.Text = "Kayıt Ol";
            this.kayit_butonu.UseVisualStyleBackColor = true;
            this.kayit_butonu.Click += new System.EventHandler(this.kayit_butonu_Click);
            // 
            // sifre
            // 
            this.sifre.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifre.Location = new System.Drawing.Point(666, 301);
            this.sifre.Name = "sifre";
            this.sifre.Size = new System.Drawing.Size(250, 40);
            this.sifre.TabIndex = 18;
            this.sifre.UseSystemPasswordChar = true;
            // 
            // kullanici_adi
            // 
            this.kullanici_adi.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kullanici_adi.Location = new System.Drawing.Point(666, 207);
            this.kullanici_adi.Name = "kullanici_adi";
            this.kullanici_adi.Size = new System.Drawing.Size(250, 40);
            this.kullanici_adi.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(366, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 34);
            this.label3.TabIndex = 16;
            this.label3.Text = "Şifre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(366, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 34);
            this.label2.TabIndex = 15;
            this.label2.Text = "Kulanıcı Adı";
            // 
            // homepage
            // 
            this.AcceptButton = this.giris_butonu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1282, 653);
            this.Controls.Add(this.giris_butonu);
            this.Controls.Add(this.kayit_butonu);
            this.Controls.Add(this.sifre);
            this.Controls.Add(this.kullanici_adi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "homepage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TradeApp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.homepage_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button giris_butonu;
        public System.Windows.Forms.Button kayit_butonu;
        public System.Windows.Forms.TextBox sifre;
        public System.Windows.Forms.TextBox kullanici_adi;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
    }
}

