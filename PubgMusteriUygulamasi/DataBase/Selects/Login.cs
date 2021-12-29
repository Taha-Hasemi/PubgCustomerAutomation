using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PubgMusteriUygulamasi.DataBase.Selects
{
    class Login
    {
        Baglanti baglanti = new Baglanti();
        public string Dogrulama(Kullanici kullanici)
        {
            try
            {
                SqlConnection baglan = baglanti.Baglan();
                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT * from dbo.kullanicilar WHERE KullaniciAdi=@p1 and Sifre=@p2", baglan);
                komut.Parameters.AddWithValue("@p1", kullanici.ad);
                komut.Parameters.AddWithValue("@p2", kullanici.sifre);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    Son_Giris(kullanici);
                    return "true";
                }
                else
                {
                    return "Hatalı Giriş";
                }
            }
            catch (Exception aciklama)
            {
                return aciklama.Message;
            }
        }
        private void Son_Giris(Kullanici kullanici)
        {
            try
            {
                SqlConnection baglan = baglanti.Baglan();
                baglan.Open();
                SqlCommand komut = new SqlCommand("UPDATE dbo.kullanicilar set EnSonGirisTarih=@p3,EnSonGirisSaat=@p4 WHERE KullaniciAdi=@p1 and Sifre=@p2", baglan);
                komut.Parameters.AddWithValue("@p1", kullanici.ad);
                komut.Parameters.AddWithValue("@p2", kullanici.sifre);
                komut.Parameters.AddWithValue("@p3", Convert.ToDateTime(kullanici.tarih));
                komut.Parameters.AddWithValue("@p4", Convert.ToDateTime(kullanici.Saat));
                komut.ExecuteNonQuery();
                baglan.Close();
            }
            catch (Exception aciklama)
            {
                MessageBox.Show(aciklama.Message);
            }

        }
    }
}
