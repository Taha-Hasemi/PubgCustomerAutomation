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
    class Selects
    {
        Baglanti baglanti = new Baglanti();
        public DataSet AnaMenuList()
        {
            try
            {
                SqlConnection baglan = baglanti.Baglan();
                baglan.Open();
                SqlDataAdapter komut = new SqlDataAdapter("SELECT ID, AdSoyad, KullanilacakSilah, OyunSaat, OyunTarih, OyunSayi, Tamamlanma FROM dbo.m24 WHERE Tamamlanma like 0", baglan);
                DataSet dshafiza = new DataSet();
                komut.Fill(dshafiza);
                baglan.Close();
                return dshafiza;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public SqlDataReader Goruntuleme(int id)
        {
            try
            {
                SqlConnection baglan = baglanti.Baglan();
                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM dbo.m24 WHERE ID like '" + id + "'", baglan);
                komut.Parameters.AddWithValue("@p1", id);
                SqlDataReader oku = komut.ExecuteReader();
                return oku;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Baglanti_Kapat()
        {
            SqlConnection baglan = baglanti.Baglan();
            baglan.Close();
        }
        
    }
}
