using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PubgMusteriUygulamasi.DataBase
{
    class Baglanti
    {
        public SqlConnection Baglan()
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=KI\SQLDEVELOPER;Initial Catalog=PubgGame;Integrated Security=True");
            return baglanti;
        }
    }
}
