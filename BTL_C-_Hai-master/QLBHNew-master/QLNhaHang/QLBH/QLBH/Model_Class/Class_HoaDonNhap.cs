using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Model_Class
{
    public class Class_HoaDonNhap
    {
        private string MaHoaDonNhap;
        private DateTime NgayNhap;
        private string MaNhanVien;
        private string MaNhaCungCap;
        private double TongTien;
        public Class_HoaDonNhap()
        {

        }
        public Class_HoaDonNhap(string MaHoaDonNhap, DateTime NgayNhap, string MaNhanVien, string MaNhaCungCap, double TongTien)
        {
            this.MaHoaDonNhap = MaHoaDonNhap;
            this.NgayNhap = NgayNhap;
            this.MaNhanVien = MaNhanVien;
            this.MaNhaCungCap = MaNhaCungCap;
            this.TongTien = TongTien;

        }

        public string MaHoaDonNhap1 { get => MaHoaDonNhap; set => MaHoaDonNhap = value; }
        public DateTime NgayNhap1 { get => NgayNhap; set => NgayNhap = value; }
        public string MaNhanVien1 { get => MaNhanVien; set => MaNhanVien = value; }
        public string MaNhaCungCap1 { get => MaNhaCungCap; set => MaNhaCungCap = value; }
        public double TongTien1 { get => TongTien; set => TongTien = value; }
    }


}