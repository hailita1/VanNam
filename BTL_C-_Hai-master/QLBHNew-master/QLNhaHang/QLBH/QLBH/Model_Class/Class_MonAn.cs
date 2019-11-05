using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Model_Class
{
    public class Class_MonAn
    {
        private string MaMonAn;
        private string TenMonAn;
        private string MaCongDung;
        private string MaLoai;
        private string CachLam;
        private string YeuCau;
        private decimal DonGia;
        public Class_MonAn()
        {

        }
        public Class_MonAn(string MaMonAn, string TenMonAn, string MaCongDung, string MaLoai, string CachLam, string YeuCau, decimal DonGia)
        {
            this.MaMonAn = MaMonAn;
            this.TenMonAn = TenMonAn;
            this.MaCongDung = MaCongDung;
            this.MaLoai = MaLoai;
            this.CachLam = CachLam;
            this.YeuCau = YeuCau;
            this.DonGia = DonGia;
        }

        public string MaMonAn1 { get => MaMonAn; set => MaMonAn = value; }
        public string TenMonAn1 { get => TenMonAn; set => TenMonAn = value; }
        public string MaCongDung1 { get => MaCongDung; set => MaCongDung = value; }
        public string MaLoai1 { get => MaLoai; set => MaLoai = value; }
        public string CachLam1 { get => CachLam; set => CachLam = value; }
        public string YeuCau1 { get => YeuCau; set => YeuCau = value; }
        public decimal DonGia1 { get => DonGia; set => DonGia = value; }
    }

}
