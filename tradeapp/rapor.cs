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
using Microsoft.Office.Interop.Excel;
using excel = Microsoft.Office.Interop.Excel;

namespace tradeapp
{
    public partial class rapor : Form
    {
        public rapor()
        {
            InitializeComponent();
        }

        public void rapor_getir()       //girilen değerlere ve tarihlere göre raporlanacak verileri getirir
        {
            if ((mallar.Text != "Seçiniz") && (islemler.Text != "Seçiniz") && 
                (dateTimePicker1.Value.ToString() != "10.06.2021 00:00:00" || dateTimePicker2.Value.ToString() != "10.06.2021 00:00:00"))       //yeni girilen değerleri kontrol eder
            {
                rapor_tablosu.Visible = true;       //tabloyu görünür  yapar
                raporu_al.Visible = true;

                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
                con.Open();

                OleDbCommand cmd = new OleDbCommand("select tarih,urun,islem,fiyat,ilk_miktar from selling where id='" + homepage.kullanici + "' and urun='" + mallar.Text + "' and islem='" + islemler.Text + "' and [tarih] BETWEEN ? AND ?", con);       //verilen bilgilere göre veri getiren sql kodu
                cmd.Parameters.AddWithValue("Tarih1", dateTimePicker1.Value);       //tarih aralığını alır
                cmd.Parameters.AddWithValue("Tarih2", dateTimePicker2.Value);
                System.Data.DataTable tablo1 = new System.Data.DataTable();     //tabloyu oluşturur
                tablo1.Load(cmd.ExecuteReader());
                rapor_tablosu.DataSource = tablo1;      //tablodaki verileri datagrid'e aktarır

                rapor_tablosu.Sort(rapor_tablosu.Columns[0], ListSortDirection.Ascending);      //tabloyu tarihe göre sıralar

                con.Close();
            }
            else
            {
                //işlemyok
            }
        }

        public void rapor_al()      //tablodaki verileri excel'e yazdırır
        {
            int i, j;

            excel.Application app = new excel.Application();        //excel uygulaması oluşturur
            app.Visible = true;
            Workbook kitap = app.Workbooks.Add(System.Reflection.Missing.Value);        //excel kitabı açar
            Worksheet sayfa = (Worksheet)kitap.Sheets[1];       //excel sayfası açar

            for (i = 0; i < rapor_tablosu.Columns.Count; i++)       //tablo başlıklarını excel'e alır
            {
                Range alan = (Range)sayfa.Cells[1, 1];
                alan.Cells[1, i + 1] = rapor_tablosu.Columns[i].HeaderText;
            }

            for (i = 0; i < rapor_tablosu.Columns.Count; i++)       //tablo satır ve sutunlarını excel'e alır
            {
                for (j = 0; j < rapor_tablosu.Rows.Count; j++) 
                {
                    Range alan2 = (Range)sayfa.Cells[j + 1, i + 1];
                    alan2.Cells[2, 1] = rapor_tablosu[i, j].Value;
                }
            }
        }

        private void rapor_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();        //uygulamayı kapatır
        }

        private void geri_butonu_Click(object sender, EventArgs e)      //önceki sayfaya gider
        {
            this.Hide();
            userpanel userpanel = new userpanel();
            userpanel.Show();
        }

        private void mallar_SelectedIndexChanged(object sender, EventArgs e)
        {
            rapor_getir();      //her yeni işlemde tabloyu günceller
        }

        private void islemler_SelectedIndexChanged(object sender, EventArgs e)
        {
            rapor_getir();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            rapor_getir();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            rapor_getir();
        }

        private void raporu_al_Click(object sender, EventArgs e)
        {
            rapor_al();     //raporu excel'e alır
        }
    }
}
