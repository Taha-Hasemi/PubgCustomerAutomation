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
    public partial class Guncelleme : Form
    {
        public Guncelleme()
        {
            InitializeComponent();
        }
        public int id = 0;

        bool silinmis_Mi = false;
        bool degistirilme = false;

        Musteri musteri_Edit;

        DataBase.Selects.Selects secme = new DataBase.Selects.Selects();
        DataBase.Updates.Updates guncelleme = new DataBase.Updates.Updates();
        DataBase.Deletes.Deletes silme = new DataBase.Deletes.Deletes();
        DataBase.Inserts.KayitEkleme ekleme = new DataBase.Inserts.KayitEkleme();

        private void Guncelleme_Load(object sender, EventArgs e)
        {
            SqlDataReader oku = secme.Goruntuleme(id);
            if (oku.Read())
            {
                txtadsoyad.Text = oku["AdSoyad"].ToString();
                txtNumara.Text = oku["Numara"].ToString();
                txtHesapAdi.Text = oku["HesapAdi"].ToString();
                txtHesapId.Text = oku["HesapID"].ToString();
                txtHesapGmail.Text = oku["HesapMail"].ToString();
                txtHesapSifre.Text = oku["HesapSifre"].ToString();
                numOyunSayisi.Value = Convert.ToDecimal(oku["oyunSayi"]);
                cmbKulanilacakSilah.Text = oku["KullanilacakSilah"].ToString();
                txtSaat.Text = oku["OyunSaat"].ToString().Remove(2);
                txtDakika.Text = oku["OyunSaat"].ToString().Remove(0,3);
                dttmedtOyunTarihi.Value = Convert.ToDateTime(oku["OyunTarih"]);
                txtKayitSaat.Text = oku["KayitSaat"].ToString();
                txtKayitTarih.Text = oku["KayitTarih"].ToString();
                cckbxTamamlanma.Checked = Convert.ToBoolean(oku["Tamamlanma"]);
                secme.Baglanti_Kapat();

                musteri_Edit = new Musteri()
                {
                    adSoyad = oku["AdSoyad"].ToString(),
                    numara = oku["Numara"].ToString(),
                    hesapAd = oku["HesapAdi"].ToString(),
                    hesapID = oku["HesapID"].ToString(),
                    hesapMail = oku["HesapMail"].ToString(),
                    hesapSifre = oku["HesapSifre"].ToString(),
                    oyunSayi = Convert.ToInt32(oku["oyunSayi"]),
                    kullanilacakSilah = oku["KullanilacakSilah"].ToString(),
                    oyunSaat = oku["OyunSaat"].ToString(),
                    oyunTarih = oku["OyunTarih"].ToString(),
                    kayitSaat = oku["KayitSaat"].ToString(),
                    kayitTarih = oku["KayitTarih"].ToString(),
                    tamamlanma = Convert.ToBoolean(oku["Tamamlanma"])
                };
            }
            else
            {
                MessageBox.Show("Hata");
            }
            //Bazi Ozel Eventler

            txtadsoyad.TextChanged += txtadsoyad_TextChanged;
            txtNumara.TextChanged += txtadsoyad_TextChanged;
            txtHesapAdi.TextChanged += txtadsoyad_TextChanged;
            txtHesapId.TextChanged += txtadsoyad_TextChanged;
            txtHesapGmail.TextChanged += txtadsoyad_TextChanged;
            txtHesapSifre.TextChanged += txtadsoyad_TextChanged;
            cmbKulanilacakSilah.SelectedIndexChanged += txtadsoyad_TextChanged;
            numOyunSayisi.ValueChanged += txtadsoyad_TextChanged;
            dttmedtOyunTarihi.ValueChanged += txtadsoyad_TextChanged;
            txtSaat.TextChanged += txtadsoyad_TextChanged;
            txtDakika.TextChanged += txtadsoyad_TextChanged;
            txtKayitSaat.TextChanged += txtadsoyad_TextChanged;
            txtKayitTarih.TextChanged += txtadsoyad_TextChanged;
            cckbxTamamlanma.CheckedChanged += txtadsoyad_TextChanged;

            //Bazi Ozel Eventler
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            musteri_Edit = new Musteri()
            {
                adSoyad = txtadsoyad.Text,
                numara = txtNumara.Text,
                hesapAd = txtHesapAdi.Text,
                hesapID = txtHesapId.Text,
                hesapMail = txtHesapGmail.Text,
                hesapSifre = txtHesapSifre.Text,
                kullanilacakSilah = cmbKulanilacakSilah.Text,
                oyunSaat = txtSaat.Text + txtDakika.Text,
                oyunTarih = dttmedtOyunTarihi.Text,
                oyunSayi = Convert.ToInt32(numOyunSayisi.Value),
                tamamlanma = cckbxTamamlanma.Checked
            };
            string sonuc = guncelleme.Musteri_Guncelle(musteri_Edit, id);
            MessageBox.Show(sonuc, "Müşteri işlemleri");
            degistirilme = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sonuc = silme.Kayit_Silme(id);
            MessageBox.Show(sonuc, "Müşteri işlemleri");
            if (sonuc == "İşlem tamamlandı")
            {
                silinmis_Mi = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (silinmis_Mi)
            {
                string sonuc = ekleme.Musteri_kayit_Kurtarma(musteri_Edit, id);
                MessageBox.Show(sonuc, "Müşteri işlemleri");
                silinmis_Mi = false;
            }
            else
            {
                MessageBox.Show("Bu kayıt silinmemiş", "Müşteri işlemleri");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (degistirilme)
            {
                MessageBox.Show("Değiştilenleri kaydetmedin!!!", "Müşteri işlemleri");
            }
            else
            {
                this.Close();
            }
        }

        private void txtadsoyad_TextChanged(object sender, EventArgs e)
        {
            degistirilme = true;
        }

    }
}

