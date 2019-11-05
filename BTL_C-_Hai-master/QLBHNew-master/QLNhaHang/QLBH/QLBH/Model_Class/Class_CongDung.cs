using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Model_Class
{
    public class Class_CongDung
    {
        private string MaCongDung;
        private string TenCongDung;
        public Class_CongDung()
        {

        }
        public Class_CongDung(string MaCongDung, string TenCongDung)
        {
            this.MaCongDung = MaCongDung;
            this.TenCongDung = TenCongDung;
        }

        public string MaCongDung1 { get => MaCongDung; set => MaCongDung = value; }
        public string TenCongDung1 { get => TenCongDung; set => TenCongDung = value; }
    }
}
