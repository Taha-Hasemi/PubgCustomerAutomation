using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubgMusteriUygulamasi
{
    class Musteri
    {
        public string adSoyad { get; set; }
        public string numara { get; set; }
        public string hesapAd { get; set; }
        public string hesapID { get; set; }
        public string hesapMail { get; set; }
        public string hesapSifre { get; set; }
        public string kullanilacakSilah { get; set; }
        public string oyunTarih { get; set; }
        public string oyunSaat { get; set; }
        public int oyunSayi { get; set; }
        public string kayitSaat { get; set; }
        public string kayitTarih { get; set; }
        public bool tamamlanma { get; set; }
    }
}
