using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PubgMusteriUygulamasi.DataBase.Updates
{
    class Updates
    {
        Baglanti baglanti = new Baglanti();

        public string Musteri_Guncelle(Musteri musteri,int id)
        {
            try
            {
                SqlConnection baglan = baglanti.Baglan();
                baglan.Open();
                SqlCommand komut = new SqlCommand("update m24 set AdSoyad=@p1,Numara=@p2,HesapAdi=@p3,HesapID=@p4,HesapMail=@p5,HesapSifre=@p6,KullanilacakSilah=@p7,OyunSaat=@p8,OyunTarih=@p9,OyunSayi=@p10,Tamamlanma=@p11 WHERE ID like @id", baglan);
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
                komut.Parameters.AddWithValue("@p11", musteri.tamamlanma);
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();
                baglan.Close();
                return "İşlem tamamlandı";
            }
            catch (Exception aciklama)
            {
                return aciklama.Message;
            }
        }
    }
}
