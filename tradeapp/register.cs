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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void geri_butonu_Click(object sender, EventArgs e)      //ana menüye döner
        {
            this.Hide();
            homepage homepage = new homepage();
            homepage.Show();           
        }

        private void kayit_ol_Click(object sender, EventArgs e)     //kayıt işlemini gerçekleştirir
        {
            if ((ad.Text == "") || (soyad.Text == "") || (tcno.Text == "") || (telno.Text == "") ||     //tüm verilerin girildiğini kontrol eder
               (email.Text == "") || (adres.Text == "") || (id.Text == "") || (pw.Text == ""))
            {
                MessageBox.Show("Tüm Alanları Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else        //tüm alanlar doldurulmuşsa kayıt işlemini gerçekleştirir
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
                con.Open();

                OleDbCommand cmd = new OleDbCommand("insert into users (adi,soyadi,tcno,telno,email,adres,id,pw) values ('" + ad.Text + "','" + soyad.Text + "','" + tcno.Text + "','" + telno.Text + "','" + email.Text + "','" + adres.Text + "','" + id.Text + "','" + pw.Text + "')", con);     //ekleme işlemini gerçekleştiren sql kodu
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Kayıt İşlemi Gerçekleşti.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                homepage homepage = new homepage();
                homepage.Show();
            }
        }
    }
}
