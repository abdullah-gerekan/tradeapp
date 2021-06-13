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
    public partial class homepage : Form
    {

        public static string kullanici;     //giriş yapan kullanıcıyı globalde tanıtan değişken

        public homepage()
        {
            InitializeComponent();
        }

        private void homepage_FormClosed(object sender, FormClosedEventArgs e)      //uygulamayı kapatır
        {
            Application.Exit();            
        }

        private void kayit_butonu_Click(object sender, EventArgs e)     //kayıt ekranını açar
        {
            this.Hide();
            register register = new register();
            register.Show();
        }

        private void giris_butonu_Click(object sender, EventArgs e)     //kullanıcı adı ve şifre ile giriş yapar
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");       //veritabanı bağlantısı
            con.Open();

            OleDbCommand cmd = new OleDbCommand("select * from users where id='" + kullanici_adi.Text + "' and pw='" + sifre.Text + "'", con);      //sql sorgusu ile kullanıcı adı ve şifre doğrulaması yapar
            OleDbDataReader sorgu = cmd.ExecuteReader();  

            if (sorgu.Read())       //girilen bilgiler doğru ise sisteme giriş yapar
            {
                kullanici = kullanici_adi.Text;

                if (kullanici_adi.Text == "admin")      //admin panelini açar
                {
                    this.Hide();
                    adminpanel adminpanel = new adminpanel();
                    adminpanel.Show();
                }
                else    //kullanıcı panelini açar
                {
                    this.Hide();
                    userpanel userpanel = new userpanel();
                    userpanel.Show();
                }
            }
            else        //hata mesajı verir
            {
                MessageBox.Show("Hatalı Giriş", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kullanici_adi.Text = "";
                sifre.Text = "";
            }

            con.Close();
        }
    }
}
