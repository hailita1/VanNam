using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Model_Class
{
    public class Class_PhieuDatBan
    {
        private string MaPhieu;
        private string MaKhach;
        private string MaNhanVien;
        private DateTime NgayDat;
        private DateTime NgayDung;
        private decimal TongTien;
        public Class_PhieuDatBan()
        {

        }
        public Class_PhieuDatBan(string MaPhieu, string MaKhach, string MaNhanVien, DateTime NgayDat, DateTime NgayDung, decimal TongTien)
        {
            this.MaPhieu = MaPhieu;
            this.MaKhach = MaKhach;
            this.MaNhanVien = MaNhanVien;
            this.NgayDat = NgayDat;
            this.NgayDung = NgayDung;
            this.TongTien = TongTien;
        }

        public string MaPhieu1 { get => MaPhieu; set => MaPhieu = value; }
        public string MaKhach1 { get => MaKhach; set => MaKhach = value; }
        public string MaNhanVien1 { get => MaNhanVien; set => MaNhanVien = value; }
        public DateTime NgayDat1 { get => NgayDat; set => NgayDat = value; }
        public DateTime NgayDung1 { get => NgayDung; set => NgayDung = value; }
        public decimal TongTien1 { get => TongTien; set => TongTien = value; }
    }
}
