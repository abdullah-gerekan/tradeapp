
namespace tradeapp
{
    partial class rapor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.geri_butonu = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.mallar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rapor_tablosu = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.islemler = new System.Windows.Forms.ComboBox();
            this.tarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.islem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ilk_miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.raporu_al = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rapor_tablosu)).BeginInit();
            this.SuspendLayout();
            // 
            // geri_butonu
            // 
            this.geri_butonu.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.geri_butonu.Location = new System.Drawing.Point(12, 12);
            this.geri_butonu.Name = "geri_butonu";
            this.geri_butonu.Size = new System.Drawing.Size(150, 40);
            this.geri_butonu.TabIndex = 22;
            this.geri_butonu.Text = "Geri";
            this.geri_butonu.UseVisualStyleBackColor = true;
            this.geri_butonu.Click += new System.EventHandler(this.geri_butonu_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(780, 74);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 29);
            this.dateTimePicker1.TabIndex = 23;
            this.dateTimePicker1.Value = new System.DateTime(2021, 6, 10, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(1045, 74);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 29);
            this.dateTimePicker2.TabIndex = 24;
            this.dateTimePicker2.Value = new System.DateTime(2021, 6, 10, 0, 0, 0, 0);
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // mallar
            // 
            this.mallar.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mallar.FormattingEnabled = true;
            this.mallar.Items.AddRange(new object[] {
            "Buğday",
            "Arpa",
            "Yulaf",
            "Petrol",
            "Pamuk"});
            this.mallar.Location = new System.Drawing.Point(205, 67);
            this.mallar.Name = "mallar";
            this.mallar.Size = new System.Drawing.Size(221, 36);
            this.mallar.TabIndex = 39;
            this.mallar.Text = "Seçiniz";
            this.mallar.SelectedIndexChanged += new System.EventHandler(this.mallar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(200, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 29);
            this.label1.TabIndex = 41;
            this.label1.Text = "Raporlanacak Ürün";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(775, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 29);
            this.label2.TabIndex = 42;
            this.label2.Text = "Başlangıç Tarihi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(1040, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 29);
            this.label3.TabIndex = 43;
            this.label3.Text = "Bitiş Tarihi";
            // 
            // rapor_tablosu
            // 
            this.rapor_tablosu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rapor_tablosu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.rapor_tablosu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rapor_tablosu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tarih,
            this.urun,
            this.islem,
            this.fiyat,
            this.ilk_miktar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rapor_tablosu.DefaultCellStyle = dataGridViewCellStyle2;
            this.rapor_tablosu.Location = new System.Drawing.Point(12, 224);
            this.rapor_tablosu.Name = "rapor_tablosu";
            this.rapor_tablosu.RowHeadersWidth = 51;
            this.rapor_tablosu.RowTemplate.Height = 30;
            this.rapor_tablosu.Size = new System.Drawing.Size(1258, 417);
            this.rapor_tablosu.TabIndex = 44;
            this.rapor_tablosu.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(490, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 29);
            this.label4.TabIndex = 45;
            this.label4.Text = "İşlem";
            // 
            // islemler
            // 
            this.islemler.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.islemler.FormattingEnabled = true;
            this.islemler.Items.AddRange(new object[] {
            "Satıldı",
            "Alındı"});
            this.islemler.Location = new System.Drawing.Point(495, 67);
            this.islemler.Name = "islemler";
            this.islemler.Size = new System.Drawing.Size(221, 36);
            this.islemler.TabIndex = 46;
            this.islemler.Text = "Seçiniz";
            this.islemler.SelectedIndexChanged += new System.EventHandler(this.islemler_SelectedIndexChanged);
            // 
            // tarih
            // 
            this.tarih.DataPropertyName = "tarih";
            this.tarih.HeaderText = "Tarih";
            this.tarih.MinimumWidth = 6;
            this.tarih.Name = "tarih";
            // 
            // urun
            // 
            this.urun.DataPropertyName = "urun";
            this.urun.HeaderText = "Ürün Tipi";
            this.urun.MinimumWidth = 6;
            this.urun.Name = "urun";
            // 
            // islem
            // 
            this.islem.DataPropertyName = "islem";
            this.islem.HeaderText = "İşlem";
            this.islem.MinimumWidth = 6;
            this.islem.Name = "islem";
            // 
            // fiyat
            // 
            this.fiyat.DataPropertyName = "fiyat";
            this.fiyat.HeaderText = "Tutar";
            this.fiyat.MinimumWidth = 6;
            this.fiyat.Name = "fiyat";
            // 
            // ilk_miktar
            // 
            this.ilk_miktar.DataPropertyName = "ilk_miktar";
            this.ilk_miktar.HeaderText = "Miktar";
            this.ilk_miktar.MinimumWidth = 6;
            this.ilk_miktar.Name = "ilk_miktar";
            // 
            // raporu_al
            // 
            this.raporu_al.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.raporu_al.Location = new System.Drawing.Point(12, 178);
            this.raporu_al.Name = "raporu_al";
            this.raporu_al.Size = new System.Drawing.Size(200, 40);
            this.raporu_al.TabIndex = 69;
            this.raporu_al.Text = "Raporu Al";
            this.raporu_al.UseVisualStyleBackColor = true;
            this.raporu_al.Visible = false;
            this.raporu_al.Click += new System.EventHandler(this.raporu_al_Click);
            // 
            // rapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1282, 653);
            this.Controls.Add(this.raporu_al);
            this.Controls.Add(this.islemler);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rapor_tablosu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mallar);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.geri_butonu);
            this.Name = "rapor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rapor Oluştur";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.rapor_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.rapor_tablosu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button geri_butonu;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox mallar;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView rapor_tablosu;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox islemler;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn urun;
        private System.Windows.Forms.DataGridViewTextBoxColumn islem;
        private System.Windows.Forms.DataGridViewTextBoxColumn fiyat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ilk_miktar;
        public System.Windows.Forms.Button raporu_al;
    }
}