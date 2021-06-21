using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PubgMusteriUygulamasi.DataBase.Inserts
{
    class KayitEkleme
    {
        Baglanti baglanti = new Baglanti();
        public string MusteriIlkKayit(Musteri musteri)
        {
            SqlConnection baglan = baglanti.Baglan();
            try
            {
                baglan.Open();
                SqlCommand ekle_komut = new SqlCommand("insert into m24(AdSoyad,Numara,HesapAdi,HesapID,HesapMail,HesapSifre,KullanilacakSilah,OyunSaat,OyunTarih,OyunSayi,KayitSaat,KayitTarih,Tamamlanma) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,0)", baglan);
                ekle_komut.Parameters.AddWithValue("@p1", musteri.adSoyad);
                ekle_komut.Parameters.AddWithValue("@p2", musteri.numara);
                ekle_komut.Parameters.AddWithValue("@p3", musteri.hesapAd);
                ekle_komut.Parameters.AddWithValue("@p4", musteri.hesapID);
                ekle_komut.Parameters.AddWithValue("@p5", musteri.hesapMail);
                ekle_komut.Parameters.AddWithValue("@p6", musteri.hesapSifre);
                ekle_komut.Parameters.AddWithValue("@p7", musteri.kullanilacakSilah);
                ekle_komut.Parameters.AddWithValue("@p8", musteri.oyunSaat);
                ekle_komut.Parameters.AddWithValue("@p9", musteri.oyunTarih);
                ekle_komut.Parameters.AddWithValue("@p10", musteri.oyunSayi);
                ekle_komut.Parameters.AddWithValue("@p11", musteri.kayitSaat);
                ekle_komut.Parameters.AddWithValue("@p12", musteri.kayitTarih);
                ekle_komut.ExecuteNonQuery();
                baglan.Close();
                return "Işlem tamamlandı";
            }
            catch (Exception aciklama)
            {
                baglan.Close();
                return aciklama.Message.ToString();
            }
        }
        public string Musteri_kayit_Kurtarma(Musteri musteri,int id)
        {
            SqlConnection baglan = baglanti.Baglan();
            try
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("Insert into dbo.m24 VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13)", baglan);
                komut.Parameters.AddWithValue("@p1", musteri.adSoyad);
                komut.Parameters.AddWithValue("@p2", musteri.numara);
                komut.Parameters.AddWithValue("@p3", musteri.hesapAd);
                komut.Parameters.AddWithValue("@p4", musteri.hesapID);
                komut.Parameters.AddWithValue("@p5", musteri.hesapMail);
                komut.Parameters.AddWithValue("@p6", musteri.hesapSifre);
                komut.Parameters.AddWithValue("@p7", musteri.kullanilacakSilah);
                komut.Parameters.AddWithValue("@p8", musteri.oyunSaat);
                komut.Parameters.AddWithValue("@p9", musteri.oyunTarih);
                komut.Parameters.AddWithValue("@p10", musteri.oyunSayi);
                komut.Parameters.AddWithValue("@p11", musteri.kayitSaat);
                komut.Parameters.AddWithValue("@p12", DateTime.Parse(musteri.kayitTarih));
                komut.Parameters.AddWithValue("@p13", musteri.tamamlanma);
                komut.ExecuteNonQuery();
                baglan.Close();
                return "İşlem tamamlandı";
            }
            catch (Exception aciklama)
            {
                baglan.Close();
                return aciklama.Message;
            }
        }
    }
}
