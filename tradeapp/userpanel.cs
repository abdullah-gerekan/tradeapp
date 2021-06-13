using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace tradeapp
{
    public partial class userpanel : Form
    {
        public userpanel()
        {
            InitializeComponent();
        }

        public void guncelle()      //giriş yapan kullanıcının sahip olduğu güncel para ve malları getirir
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
            con.Open();

            OleDbCommand cmd = new OleDbCommand("select * from users where id='" + homepage.kullanici + "'", con);
            OleDbDataReader sorgu = cmd.ExecuteReader();

            while (sorgu.Read())        //getirilen veriler textbox'lara yazdırılır
            {
                bakiye.Text = Convert.ToString(sorgu["para"]);
                bugday_mikt.Text = Convert.ToString(sorgu["bugday"]);
                arpa_mikt.Text = Convert.ToString(sorgu["arpa"]);
                yulaf_mikt.Text = Convert.ToString(sorgu["yulaf"]);
                petrol_mikt.Text = Convert.ToString(sorgu["petrol"]);
                pamuk_mikt.Text = Convert.ToString(sorgu["pamuk"]);
            }

            con.Close();
        }

        public void satis_tablosu_doldur()      //satıştaki güncel verileri çeker
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
            con.Open();

            OleDbCommand cmd = new OleDbCommand("select kimlik,id,urun,miktar,fiyat,tarih from selling where islem='Satılık'", con);        //işlemi satılık olan verileri getiren sql kodu
            DataTable tablo1 = new DataTable();
            tablo1.Load(cmd.ExecuteReader());
            satis_tablosu.DataSource = tablo1;      //tabloları doldurur
            alis_tablosu.DataSource = tablo1;

            satis_tablosu.Sort(satis_tablosu.Columns[0], ListSortDirection.Ascending);      //verileri işlem sırasına göre sıralar

            con.Close();
        }

        private void urunler1_SelectedIndexChanged(object sender, EventArgs e)      //combobox değiştiğinde istenilen ürün bilgilerini getirir
        {
            liste_guncelle();
        }

        public void liste_guncelle()        //alım yapılmak istenen ürüne göre saıştaki ürünleri listeler
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
            con.Open();

            OleDbCommand cmd = new OleDbCommand("select kimlik,id,urun,miktar,fiyat,tarih from selling where urun='" + urunler1.Text + "' and islem='Satılık'", con);            

            DataTable tablo1 = new DataTable();
            tablo1.Load(cmd.ExecuteReader());
            alis_tablosu.DataSource = tablo1;

            alis_tablosu.Sort(alis_tablosu.Columns[4], ListSortDirection.Ascending);

            con.Close();
        }

        public void emir_tablosu_doldur()       //mevcut alım emri varsa emir tablosuna getirir
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
            con.Open();

            OleDbCommand cmd = new OleDbCommand("select kimlik,id,urun,miktar,fiyat,tarih from selling where islem='Alınacak'", con);

            DataTable tablo1 = new DataTable();
            tablo1.Load(cmd.ExecuteReader());
            emir_tablosu.DataSource = tablo1;

            con.Close();
        }

        public string urun_bul(string secim)        //seçim yapılan ürünün veritabanındaki ismine göre değişim yapar
        {
            string urun = "";

            switch (secim)
            {
                case "Buğday":
                    urun = "bugday";
                    break;
                case "Arpa":
                    urun = "arpa";
                    break;
                case "Yulaf":
                    urun = "yulaf";
                    break;
                case "Petrol":
                    urun = "petrol";
                    break;
                case "Pamuk":
                    urun = "pamuk";
                    break;
                default:
                    MessageBox.Show("Hatalı İşlem.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            
            return urun;
        }

        public int komisyon_al(int alinacak_miktar, int alinacak_fiyat)     //alım işlemi gerçekleştiğinde alınan ürünün tutarına göre admin hesabına eklenecek parayı hesaplar ve işlemi gerçekleştirir
        {
            int komisyon = 1;
            double tutar, miktar, fiyat;

            miktar = Convert.ToDouble(alinacak_miktar);
            fiyat = Convert.ToDouble(alinacak_fiyat);

            tutar = ((miktar * fiyat) / 100);

            tutar = Math.Round(tutar);

            if (tutar > komisyon)
            {
                komisyon = Convert.ToInt32(tutar);
            }

            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
            con.Open();

            OleDbCommand cmd1 = new OleDbCommand("update users set para=para+'" + komisyon + "' where id='admin'", con);        //admin hesabına parayı ekler
            cmd1.ExecuteNonQuery();

            OleDbCommand cmd2 = new OleDbCommand("update users set para=para-'" + komisyon + "' where id='" + homepage.kullanici + "'", con);       //kullanıcı hesabından komisyon tutarını düşer
            cmd2.ExecuteNonQuery();

            con.Close();

            return komisyon;
        }

        public void ekle(string urun, string miktar)        //para veya ürün ekleme işlemini veritabanına yazar
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
            con.Open();

            OleDbCommand cmd = new OleDbCommand("insert into approval (id,urun,miktar,islem) values('" + homepage.kullanici + "','" + urun + "','" + miktar + "','" + "Onaylanacak" + "')", con);       //eklenecek ürünün türüne ve miktarına göre veritabanına yazan sql kodu
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Onay Bekleniyor.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }        

        public void satisa_cikart(string satilacak_urun, int satilacak_miktar, int satilacak_fiyat)     //gerekli bilgileri alarak satılacak ürünlerin satışa çıkarılma işlemini gerçekleştirir
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
            con.Open();

            string secilen_urun = urun_bul(satilacak_urun);

            DateTime dt = new DateTime();       //işlemin gerçekleştiği tarih bilgisini alır
            dt = DateTime.Now;

            OleDbCommand cmd = new OleDbCommand("insert into selling (id,urun,ilk_miktar,miktar,fiyat,islem,tarih) values('" + homepage.kullanici + "','" + satilacak_urun + "','" + satilacak_miktar + "','" + satilacak_miktar + "','" + satilacak_fiyat + "','" + "Satılık" + "','" + dt.ToString("dd/MM/yyyy") + "')", con);        //satılacak ürünü veritabanına ekler
            cmd.ExecuteNonQuery();

            OleDbCommand cmd1 = new OleDbCommand("update users set " + secilen_urun + "=" + secilen_urun + "-'" + satilacak_miktar + "' where id='" + homepage.kullanici + "'", con);       //satılacak ürünü kullanıcı hesabından düşer
            cmd1.ExecuteNonQuery();

            MessageBox.Show("Ürün Satışa Çıkarıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            con.Close();
        }

        public void alis_yap(string alinacak_urun, int alinacak_miktar, int alinacak_fiyat)     //gerekli bilgileri alarak satın alım işlemini gerçekleştirir
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
            con.Open();

            int satir_sayisi = alis_tablosu.Rows.Count - 1;
            string durum, id;
            int fiyat, miktar, kalan, kimlik, tam_tutar, eksik_tutar;

            for (int i = 0; i < satir_sayisi; i++)          //satıştaki ürün sayısı kadar döngü kurar
            {
                fiyat = Convert.ToInt32(alis_tablosu.Rows[i].Cells["fiyat1"].Value.ToString());         //gerekli bilgilerin türlerini dönüştürür
                miktar = Convert.ToInt32(alis_tablosu.Rows[i].Cells["miktar1"].Value.ToString());
                kimlik = Convert.ToInt32(alis_tablosu.Rows[i].Cells["kimlik1"].Value.ToString());
                id = alis_tablosu.Rows[i].Cells["id1"].Value.ToString();
                tam_tutar = fiyat * alinacak_miktar;
                eksik_tutar = fiyat * miktar;

                if (fiyat <= alinacak_fiyat)      //satış fiyatı, alınacak fiyattan düşük yada eşit
                {
                    if (miktar >= alinacak_miktar)   //satılan miktar, alınacak miktardan fazla yada eşit
                    {
                        kalan = miktar - alinacak_miktar;

                        if (kalan == 0)
                        {
                            durum = "Satıldı";
                        }
                        else
                        {
                            durum = "Satılık";
                        }

                        OleDbCommand cmd1 = new OleDbCommand("update selling set miktar=miktar-'" + alinacak_miktar + "', islem='" + durum + "' where kimlik=" + kimlik + "", con);
                        cmd1.ExecuteNonQuery();     //satılan miktari düş ve satıldı yaz

                        string secilen_urun = urun_bul(alinacak_urun);
                        OleDbCommand cmd2 = new OleDbCommand("update users set " + secilen_urun + "=" + secilen_urun + "+'" + alinacak_miktar + "', para=para-" + tam_tutar + " where id='" + homepage.kullanici + "'", con);
                        cmd2.ExecuteNonQuery();     //alınan ürünü ekle ve parayı düş

                        OleDbCommand cmd3 = new OleDbCommand("update users set para=para+'" + tam_tutar + "' where id='" + id + "'", con);
                        cmd3.ExecuteNonQuery();     //satıcıya parasını ekle

                        alinacak_miktar = 0;

                        MessageBox.Show("Alış İşlemi Tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        break;     
                    }
                    else      //satılan miktar, alınacak miktardan az
                    {
                        OleDbCommand cmd1 = new OleDbCommand("update selling set miktar='0', islem='Satıldı' where kimlik=" + kimlik + "", con);
                        cmd1.ExecuteNonQuery();     //satılan miktari düş ve satıldı yaz

                        string secilen_urun = urun_bul(alinacak_urun);
                        OleDbCommand cmd2 = new OleDbCommand("update users set " + secilen_urun + "=" + secilen_urun + "+'" + miktar + "', para=para-" + eksik_tutar + " where id='" + homepage.kullanici + "'", con);
                        cmd2.ExecuteNonQuery();     //alınan ürünü ekle ve parayı düş

                        OleDbCommand cmd3 = new OleDbCommand("update users set para=para+'" + eksik_tutar + "' where id='" + id + "'", con);
                        cmd3.ExecuteNonQuery();     //satıcıya parasını ekle

                        alinacak_miktar = alinacak_miktar - miktar;
                    }

                }
                else      //satış fiyatı, alınacak fiyattan fazla
                {
                    MessageBox.Show("Eksik Ürünler İçin Alış Emri Oluşturuldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            DateTime dt = new DateTime();
            dt = DateTime.Now;

            if (alinacak_miktar == 0)
            {                
                OleDbCommand cmd4 = new OleDbCommand("insert into selling (id,urun,ilk_miktar,miktar,fiyat,islem,tarih) values('" + homepage.kullanici + "','" + alinacak_urun + "','" + Convert.ToInt32(alis_miktari.Text) + "','" + alinacak_miktar + "','" + alinacak_fiyat + "','" + "Alındı" + "','" + dt.ToString("dd/MM/yyyy") + "')", con);
                cmd4.ExecuteNonQuery();     //alınan ürünün bilgilerini kaydeder
            }
            else
            {
                OleDbCommand cmd5 = new OleDbCommand("insert into selling (id,urun,ilk_miktar,miktar,fiyat,islem,tarih) values('" + homepage.kullanici + "','" + alinacak_urun + "','" + Convert.ToInt32(alis_miktari.Text) + "','" + alinacak_miktar + "','" + alinacak_fiyat + "','" + "Alınacak" + "','" + dt.ToString("dd/MM/yyyy") + "')", con);
                cmd5.ExecuteNonQuery();     //alınan ürünün bilgilerini kaydeder
            }

            emir_tablosu_doldur();

            con.Close();
        }

        public void alis_emri_kontrol(int son_satis)        //satış işlemi gerçekleştiğinde bu ürün için hazırda bulunan bir alım emri olup olmadığını kontrol eder
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
            con.Open();

            OleDbCommand cmd = new OleDbCommand("select urun,miktar,fiyat from selling where kimlik=" + son_satis + "", con);       //son gerçekleştirilen satışın bilgilerini alır
            OleDbDataReader sorgu = cmd.ExecuteReader();

            string emir_urun, emir_id, son_urun, son_durum;
            int emir_miktar, emir_fiyat, emir_kimlik, son_miktar, son_fiyat, kalan_satilik_miktar, tam_tutar, eksik_tutar;
            

            while (sorgu.Read())
            {
                son_urun = Convert.ToString(sorgu["urun"]);
                son_miktar = Convert.ToInt32(sorgu["miktar"]);
                son_fiyat = Convert.ToInt32(sorgu["fiyat"]);

                OleDbCommand cmd1 = new OleDbCommand("select kimlik,id,urun,miktar,fiyat from selling where islem='Alınacak'", con);        //alış emirlerini listeler
                DataTable tablo1 = new DataTable();
                tablo1.Load(cmd1.ExecuteReader());

                int emir_sayisi = tablo1.Rows.Count;

                for (int i = 0; i < emir_sayisi; i++)       //alış emirlerinin sayısı kadar döngü kurar
                {
                    emir_kimlik = Convert.ToInt32(tablo1.Rows[i]["kimlik"].ToString());
                    emir_id = tablo1.Rows[i]["id"].ToString();
                    emir_urun = tablo1.Rows[i]["urun"].ToString();
                    emir_miktar = Convert.ToInt32(tablo1.Rows[i]["miktar"].ToString());
                    emir_fiyat = Convert.ToInt32(tablo1.Rows[i]["fiyat"].ToString());

                    tam_tutar = emir_miktar * son_fiyat;
                    eksik_tutar = son_miktar * son_fiyat;
                    kalan_satilik_miktar = son_miktar - emir_miktar;

                    if (emir_urun == son_urun)      //satılan ürün ile alınacak ürünün aynı olma durumunu kontrol eder
                    {
                        if (emir_fiyat >= son_fiyat)        //alım fiyatı ve satım fiyatını kontrol eder
                        {                            
                            if (emir_miktar <= son_miktar)//emir karşılandı ve kapandı
                            {                                
                                if (kalan_satilik_miktar == 0)
                                {
                                    son_durum = "Satıldı";
                                }
                                else
                                {
                                    son_durum = "Satılık";
                                }

                                OleDbCommand cmd2 = new OleDbCommand("update selling set miktar=miktar-'" + emir_miktar + "', islem='" + son_durum + "' where kimlik=" + son_satis + "", con);
                                cmd2.ExecuteNonQuery();     //satılan miktari düş ve satıldı yaz

                                string secilen_urun = urun_bul(son_urun);
                                OleDbCommand cmd3 = new OleDbCommand("update users set " + secilen_urun + "=" + secilen_urun + "+'" + emir_miktar + "', para=para-" + tam_tutar + " where id='" + emir_id + "'", con);
                                cmd3.ExecuteNonQuery();     //alınan ürünü ekle ve parayı düş

                                OleDbCommand cmd4 = new OleDbCommand("update users set para=para+'" + tam_tutar + "' where id='" + homepage.kullanici + "'", con);
                                cmd4.ExecuteNonQuery();     //satıcıya parasını ekle

                                OleDbCommand cmd5 = new OleDbCommand("update selling set miktar='0', islem='Alındı' where kimlik=" + emir_kimlik + "", con);
                                cmd5.ExecuteNonQuery();     //emiri kapa

                                son_miktar = son_miktar - emir_miktar;

                                MessageBox.Show("Alım Emri Bulundu ve Satış Gerçekleştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else//hala emir aktif sadece bir kısmı alındı
                            {
                                OleDbCommand cmd2 = new OleDbCommand("update selling set miktar='0', islem='Satıldı' where kimlik=" + son_satis + "", con);
                                cmd2.ExecuteNonQuery();     //satılan miktari düş ve satıldı yaz

                                string secilen_urun = urun_bul(son_urun);
                                OleDbCommand cmd3 = new OleDbCommand("update users set " + secilen_urun + "=" + secilen_urun + "+'" + son_miktar + "', para=para-" + eksik_tutar + " where id='" + emir_id + "'", con);
                                cmd3.ExecuteNonQuery();     //alınan ürünü ekle ve parayı düş

                                OleDbCommand cmd4 = new OleDbCommand("update users set para=para+'" + eksik_tutar + "' where id='" + homepage.kullanici + "'", con);
                                cmd4.ExecuteNonQuery();     //satıcıya parasını ekle

                                OleDbCommand cmd5 = new OleDbCommand("update selling set miktar=miktar-'" + son_miktar + "' where kimlik=" + emir_kimlik + "", con);
                                cmd5.ExecuteNonQuery();     //alış emrinden alınacak kalan miktarı düş

                                MessageBox.Show("Alım Emri Bulundu ve Satış Gerçekleştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                break;
                            }
                        }
                        else
                        {
                            //işlemyok
                        }
                    }
                    else
                    {
                        //işlemyok
                    }
                }
            }

            con.Close();
        }

        private void userpanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();            
        }

        private void userpanel_Load(object sender, EventArgs e)     //form çalıştığında gerekli tabloları doldurur
        {
            guncelle();
            satis_tablosu_doldur();
            emir_tablosu_doldur();
        }

        private void geri_butonu_Click(object sender, EventArgs e)      //önceki sayfaya döner
        {
            this.Hide();
            homepage homepage = new homepage();
            homepage.Show();
        }

        private void para_ekle_Click(object sender, EventArgs e)        //para eklemesi yapılır
        {
            if (paralar.Text != "Seçiniz" && para_gir.Text != "" && para_gir.Text != "0")
            {
                ekle(paralar.Text, para_gir.Text);
                paralar.Text = "Seçiniz";
                para_gir.Text = "";
            }
            else
            {
                MessageBox.Show("Seçim Yapınız ve Miktar Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void urun_ekle_Click(object sender, EventArgs e)        //ürün eklemesi yapılır
        {
            if (mallar.Text != "Seçiniz" && mal_gir.Text != "" && mal_gir.Text != "0")
            {
                ekle(mallar.Text, mal_gir.Text);
                mallar.Text = "Seçiniz";
                mal_gir.Text = "";
            }
            else
            {
                MessageBox.Show("Seçim Yapınız ve Miktar Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void satis_Click(object sender, EventArgs e)        //ürün satışa çıkartılır
        {
            if (urunler.Text != "Seçiniz" && satis_miktari.Text != "" && satis_miktari.Text != "0" && satis_fiyati.Text != "" && satis_fiyati.Text != "0") 
            {
                if ((urunler.Text == "Buğday" && (Convert.ToInt32(bugday_mikt.Text) >= Convert.ToInt32(satis_miktari.Text))) || 
                    (urunler.Text == "Arpa" && (Convert.ToInt32(arpa_mikt.Text) >= Convert.ToInt32(satis_miktari.Text))) ||
                    (urunler.Text == "Yulaf" && (Convert.ToInt32(yulaf_mikt.Text) >= Convert.ToInt32(satis_miktari.Text))) ||
                    (urunler.Text == "Petrol" && (Convert.ToInt32(petrol_mikt.Text) >= Convert.ToInt32(satis_miktari.Text))) ||
                    (urunler.Text == "Pamuk" && (Convert.ToInt32(pamuk_mikt.Text) >= Convert.ToInt32(satis_miktari.Text))))         //satılmak istenilen miktar ile sahip olunan ürün miktarlarını karşılaştırır
                {
                    string satilacak_urun = urunler.Text;
                    int satilacak_miktar = Convert.ToInt32(satis_miktari.Text);
                    int satilacak_fiyat = Convert.ToInt32(satis_fiyati.Text);

                    satisa_cikart(satilacak_urun, satilacak_miktar, satilacak_fiyat);       //satışı yapar ve güncel verileri tablolara doldurur
                    satis_tablosu_doldur();
                    guncelle();
                    
                    satis_tablosu.FirstDisplayedScrollingRowIndex = satis_tablosu.RowCount - 1;     //tabloyu en alta kaydırır

                    satis_tablosu.ClearSelection();     //eklenen son ürünü seçili hale getirir
                    satis_tablosu[0, satis_tablosu.RowCount - 2].Selected = true;
                    satis_tablosu.CurrentCell = satis_tablosu.Rows[satis_tablosu.RowCount - 2].Cells[0];

                    int son_satis = satis_tablosu.RowCount - 2;
                    son_satis = Convert.ToInt32(satis_tablosu[0, son_satis].Value.ToString());

                    alis_emri_kontrol(son_satis);       //satılan ürüne uygun alım emri olup olmadığını kontrol eder
                    emir_tablosu_doldur();
                    

                    urunler.Text = "Seçiniz";
                    satis_miktari.Text = "";
                    satis_fiyati.Text = "";
                }
                else
                {
                    MessageBox.Show("Hatalı Değer Girildi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yapıldı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void alis_Click(object sender, EventArgs e)     //alım işlemini gerçekleştirir
        {
            if (urunler1.Text != "Seçiniz" && alis_miktari.Text != "" && alis_miktari.Text != "0" && alis_fiyati.Text != "" && alis_fiyati.Text != "0")
            {
                int miktar = Convert.ToInt32(alis_miktari.Text);
                int fiyat = Convert.ToInt32(alis_fiyati.Text);
                int para = Convert.ToInt32(bakiye.Text);
                int alinacak_komisyon = komisyon_al(miktar, fiyat);//tüm komisyon

                if (para >= (alinacak_komisyon + (miktar * fiyat)))     //ürünü alacak ve komisyonu karşılayacak paranın olup olmadığı kontrol edilir
                {
                    MessageBox.Show(String.Format("İşleminizden {0}TL Komisyon Alındı.", Convert.ToString(alinacak_komisyon)), "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string alinacak_urun = urunler1.Text;
                    alis_yap(alinacak_urun, miktar, fiyat);

                    guncelle();
                    satis_tablosu_doldur();
                    liste_guncelle();
                    emir_tablosu_doldur();

                    alis_miktari.Text = "";
                    alis_fiyati.Text = "";
                }
                else
                {
                    MessageBox.Show("Paranız Yeterli Değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }     
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yapıldı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rapor_olustur_Click(object sender, EventArgs e)        //rapor oluşturma sayfasına geçilir
        {
            this.Hide();
            rapor rapor = new rapor();
            rapor.Show();
        }
    }
}
