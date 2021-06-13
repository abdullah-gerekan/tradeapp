using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Xml;

namespace tradeapp
{
    public partial class adminpanel : Form
    {
        public adminpanel()
        {
            InitializeComponent();
        }

        public void listele()       //onay listesi tablosuna onaylanması beklenen işlemleri listeler, bu fonksiyon güncelleme için de kullanılır
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");       //database bağlantısı kurulur
            con.Open();   
            
            onay_listesi.Items.Clear();     //tablo temizlenir
            
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select id,urun,miktar from approval where islem='Onaylanacak'", con);      //tabloya eklenecek veriler getirilir
            DataTable tablo = new DataTable();
            adaptor.Fill(tablo);

            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                onay_listesi.Items.Add(tablo.Rows[i][0] + "\t\t" + tablo.Rows[i][1] + "\t\t" + tablo.Rows[i][2]);       //veriler tek tek tabloya eklenir
            }

            OleDbCommand cmd = new OleDbCommand("select para from users where id='admin'", con);        //adminin komisyondan aldığı parayı getirir
            OleDbDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                admin_para.Text = dr["para"].ToString();        //admin parasını yazdırır
            }

            con.Close();
        }

        public void onayla(int secim)       //secilen islemin onayını gerçekleştiren fonksiyon
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");       //veritabanı bağlantısı
            con.Open();

            OleDbDataAdapter adaptor = new OleDbDataAdapter("select kimlik,id,urun,miktar from approval where islem='Onaylanacak'", con);       //onaylanacak işlem bulunur
            DataTable tablo = new DataTable();
            adaptor.Fill(tablo);

            for (int i = 0; i <= secim; i++)        //seçilen işleme gelene kadar döngü kurulur
            {
                if (i == secim)
                {
                    string id = Convert.ToString(tablo.Rows[i][1]);     //secim bulunduğunda id, urun ve miktar değerleri alınır
                    string urun = Convert.ToString(tablo.Rows[i][2]);
                    int miktar = Convert.ToInt32(tablo.Rows[i][3]);

                    urunekle(id, urun, miktar);     //seçimin alınan değerlerine göre işlemi gerçekleştiren kullanıcıya urunleri eklenir

                    OleDbCommand onayla = new OleDbCommand("update approval set islem='Onaylandi' where kimlik=" + tablo.Rows[i][0] + "", con);     //ürünleri eklenen kullanıcının işlemi onaylandı olarak değiştirilir
                    onayla.ExecuteNonQuery();
                }
            }

            con.Close();
        }

        public void urunekle(string id, string urun, int miktar)        //alınan değerlere göre kullanıcıya urunleri eklenir
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
            con.Open();
            
            switch (urun)       //eklenecek her ürüne göre ayrı işlem yapılır
            {
                case "Buğday":
                    OleDbCommand bugdayekle = new OleDbCommand("update users set bugday=bugday+'" + miktar + "' where id='" + id + "'", con);       //seçilen ürüne göre ekleme yapılır
                    bugdayekle.ExecuteNonQuery();
                    break;
                case "Arpa":
                    OleDbCommand arpaekle = new OleDbCommand("update users set arpa=arpa+'" + miktar + "' where id='" + id + "'", con);
                    arpaekle.ExecuteNonQuery();
                    break;
                case "Yulaf":
                    OleDbCommand yulafekle = new OleDbCommand("update users set yulaf=yulaf+'" + miktar + "' where id='" + id + "'", con);
                    yulafekle.ExecuteNonQuery();
                    break;
                case "Petrol":
                    OleDbCommand petrolekle = new OleDbCommand("update users set petrol=petrol+'" + miktar + "' where id='" + id + "'", con);
                    petrolekle.ExecuteNonQuery();
                    break;
                case "Pamuk":
                    OleDbCommand pamukekle = new OleDbCommand("update users set pamuk=pamuk+'" + miktar + "' where id='" + id + "'", con);
                    pamukekle.ExecuteNonQuery();
                    break;
                default:
                    paraekle(id, urun, miktar);     //eklenecek ürün bir mal değil para ise para ekleme için ayrı fonksiyon kullanılır
                    break;
            }

            con.Close();
        }

        public void paraekle(string id, string birim, int miktar)       //eklenecek ürün para ise bu fonksiyon kullanılır
        {            
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
            con.Open();

            int guncel_tutar;

            switch (birim)      //eklenecek paranın birimine göre ayrı işlem yapılır
            {
                case "Türk Lirası (TL)":
                    OleDbCommand tlekle = new OleDbCommand("update users set para=para+'" + miktar + "' where id='" + id + "'", con);       //para birimi tl ise kur dönüşümü yapılmadan eklenir
                    tlekle.ExecuteNonQuery();
                    break;
                case "Dolar (USD)":
                    guncel_tutar = kur_cevir(usd_kuru.Text, miktar);        //eklenecek para döviz ise kur_cevir fonksiyonu kullanılarak güncel kura göre eklenecek tutar belirlenir
                    OleDbCommand usdekle = new OleDbCommand("update users set para=para+'" + guncel_tutar + "' where id='" + id + "'", con);
                    usdekle.ExecuteNonQuery();
                    break;
                case "Euro (EUR)":
                    guncel_tutar = kur_cevir(eur_kuru.Text, miktar);
                    OleDbCommand eurekle = new OleDbCommand("update users set para=para+'" + guncel_tutar + "' where id='" + id + "'", con);
                    eurekle.ExecuteNonQuery();
                    break;
                case "Sterlin (GBP)":
                    guncel_tutar = kur_cevir(gbp_kuru.Text, miktar);
                    OleDbCommand gbpekle = new OleDbCommand("update users set para=para+'" + guncel_tutar + "' where id='" + id + "'", con);
                    gbpekle.ExecuteNonQuery();
                    break;
                default:
                    MessageBox.Show("Hatalı İşlem.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            con.Close();
        }

        public int kur_cevir(string doviz_kuru, int doviz_miktari)      //eklenecek dövizin kur bilgisi ve döviz miktarı alınarak eklenecek tutar hesaplanır
        {
            int gonder;
            double tutar, kur;

            doviz_kuru = doviz_kuru.Replace('.', ',');
            kur = Convert.ToDouble(doviz_kuru);

            tutar = kur * doviz_miktari;
            tutar = Math.Round(tutar);     

            gonder = Convert.ToInt32(tutar);

            return gonder;
        }

        public void doviz_kuru_getir()      //xml kullanılarak tcmb sitesinden usd, eur ve gbp kur bilgileri çekilir
        {
            XmlTextReader rdr = new XmlTextReader("http://www.tcmb.gov.tr/kurlar/today.xml");
            XmlDocument myxml = new XmlDocument();
            myxml.Load(rdr);

            XmlNodeList kod = myxml.SelectNodes("/Tarih_Date/Currency/@Kod");
            XmlNodeList doviz_kuru = myxml.SelectNodes("/Tarih_Date/Currency/ForexSelling");

            for (int i = 0; i < 15; i++)
            {
                string birim = kod.Item(i).InnerText.ToString();

                if (birim == "USD")
                {
                    usd_kuru.Text = doviz_kuru.Item(i).InnerText.ToString();        //kur değeri usd_kuru.text'e yazılır
                }
                if (birim == "EUR")
                {
                    eur_kuru.Text = doviz_kuru.Item(i).InnerText.ToString();
                }
                if (birim == "GBP")
                {
                    gbp_kuru.Text = doviz_kuru.Item(i).InnerText.ToString();
                }
                if (usd_kuru.Text != "x" && eur_kuru.Text != "x" && gbp_kuru.Text != "x")
                    break;
            }
        }

        private void adminpanel_Load(object sender, EventArgs e)
        {
            listele();      //sayfa çalıştığında onay tablosunu listeler
            doviz_kuru_getir();     //sayfa çalıştığında güncel kur bilgilerini getirir
        }

        private void adminpanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void geri_butonu_Click(object sender, EventArgs e)
        {
            this.Hide();
            homepage homepage = new homepage();
            homepage.Show();
        }

        private void onayla_butonu_Click(object sender, EventArgs e)        //tablodan seçilen işlemi onaylar
        {
            int secim = onay_listesi.SelectedIndex;     //seçilen işlemin index değerine göre işlem yapar

            if (secim != -1)
            {
                onayla(secim);      //işlemin index değeri ile onayla fonksiyonunu çağırır
                listele();      //tabloyu günceller
                MessageBox.Show("İşlem Onaylandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);      //onay bilgisi yazdırır
            }
            else
            {
                MessageBox.Show("Seçim Yapınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
