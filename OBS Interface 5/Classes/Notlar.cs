using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS_Interface_5.Classes
{
    class Notlar
    {

        public Notlar(string dersKodu, string dersAdi, string vize, string final, string ortalama, string katsayi, string harf)
        {
            this.dersAdi = dersAdi;
            this.vize = vize;
            this.final = final;
            this.ortalama = ortalama;
            this.harf = harf;
            this.katsayi = katsayi;
            this.dersKodu = dersKodu;

        }

        public string katsayi { get; set; }
        public string dersKodu { get; set; }
        public string dersAdi { get; set; }
        public string vize { get; set; }
        public string final { get; set; }
        public string ortalama { get; set; }
        public string harf { get; set; }
        
    }
}
