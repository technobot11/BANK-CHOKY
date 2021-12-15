using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BNIWebServiceTest.Models
{
    public class DataNasabah
    {
        public string NamaLengkap { get; set; }
        public string Alamat { get; set; }
        public string Kota { get; set; }
        public string TempatLahir { get; set; }
        public DateTime TanggalLahir { get; set; }
        public string NomorKTP { get; set; }
        public string NomorHandphone { get; set; }
        public string DeskripsiKota { get; set; }
    }
}