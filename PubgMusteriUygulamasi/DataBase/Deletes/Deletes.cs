using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PubgMusteriUygulamasi.DataBase.Deletes
{
    class Deletes
    {
        Baglanti baglanti = new Baglanti();
        public string Kayit_Silme(int id)
        {
            SqlConnection baglan = baglanti.Baglan();
            try
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("DELETE from dbo.m24 WHERE ID like @id", baglan);
                komut.Parameters.AddWithValue("@id", id);
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
