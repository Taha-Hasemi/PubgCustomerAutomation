using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PubgMusteriUygulamasi
{
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }

        DataBase.Inserts.KayitEkleme kayitEkleme = new DataBase.Inserts.KayitEkleme();
        DataBase.Selects.Selects secme = new DataBase.Selects.Selects();
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            Musteri musteri = new Musteri()
            {
                adSoyad = txtadsoyad.Text,
                numara = txtNumara.Text,
                hesapAd = txtHesapAdi.Text,
                hesapID = txtHesapId.Text,
                hesapMail = txtHesapGmail.Text,
                hesapSifre = txtHesapSifre.Text,
                kullanilacakSilah = cmbKulanilacakSilah.Text,
                oyunSaat = dttmedtOyunSaat.Text,
                oyunTarih = dttmedtOyunTarihi.Text,
                oyunSayi = Convert.ToInt32(numOyunSayisi.Value),
                kayitSaat = (date.Hour + ":" + date.Minute).ToString(),
                kayitTarih = (date.Year + "." + date.Month + "." + date.Day).ToString()
            };
            string sonuc = kayitEkleme.MusteriIlkKayit(musteri);
            MessageBox.Show(sonuc, "Ekleme işlemi");
            txtadsoyad.Clear();
            txtNumara.Clear();
            txtHesapAdi.Clear();
            txtHesapId.Clear();
            txtHesapGmail.Clear();
            txtHesapSifre.Clear();
            numOyunSayisi.Value = 0;
        }

        private void AnaMenu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pubgGameDataSet3.m24' table. You can move, or remove it, as needed.
            this.m24TableAdapter.Fill(this.pubgGameDataSet3.m24);

        }

        private void fillByOyunTarihToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.m24TableAdapter.FillByOyunTarih(this.pubgGameDataSet3.m24);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByOyunSaatToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.m24TableAdapter.FillByOyunSaat(this.pubgGameDataSet3.m24);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Guncelleme guncellemeForm = new Guncelleme();

            //FormlarArasiDeger formlarArasiDeger = new FormlarArasiDeger();
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            guncellemeForm.id = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value);
            guncellemeForm.Show();

        }

        private void yenileToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.m24TableAdapter.Yenile(this.pubgGameDataSet3.m24);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByOyunSayiToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.m24TableAdapter.FillByOyunSayi(this.pubgGameDataSet3.m24);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
