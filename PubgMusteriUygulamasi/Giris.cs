using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PubgMusteriUygulamasi
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase.Selects.Login login = new DataBase.Selects.Login();
            string sonuc = login.Dogrulama(new Kullanici { ad = textBox1.Text.Trim(), sifre = textBox2.Text.Trim(), Saat = DateTime.Now.ToLongTimeString(), tarih = DateTime.Now.ToLongDateString() });
            if (sonuc == "true")
            {
                AnaMenu anaMenu = new AnaMenu();
                anaMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(sonuc);
            }
        }
    }
}
