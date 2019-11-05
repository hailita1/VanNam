using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Model_Class
{
    public class Class_NhanVien
    {
        private string MaNhanVien;
        private string TenNhanVien;
        private bool GioiTinh;
        private DateTime NgaySinh;
        private string DiaChi;
        private string MaQue;
        private string DienThoai;
        public Class_NhanVien()
        {

        }
        public Class_NhanVien(string MaNhanVien, string TenNhanVien, bool GioiTinh, DateTime NgaySinh, string DiaChi, string MaQue, string DienThoai)
        {
            this.MaNhanVien = MaNhanVien;
            this.TenNhanVien = TenNhanVien;
            this.GioiTinh = GioiTinh;
            this.NgaySinh = NgaySinh;
            this.DiaChi = DiaChi;
            this.MaQue = MaQue;
            this.DienThoai = DienThoai;
        }

        public string MaNhanVien1 { get => MaNhanVien; set => MaNhanVien = value; }
        public string TenNhanVien1 { get => TenNhanVien; set => TenNhanVien = value; }
        public bool GioiTinh1 { get => GioiTinh; set => GioiTinh = value; }
        public DateTime NgaySinh1 { get => NgaySinh; set => NgaySinh = value; }
        public string DiaChi1 { get => DiaChi; set => DiaChi = value; }
        public string MaQue1 { get => MaQue; set => MaQue = value; }
        public string DienThoai1 { get => DienThoai; set => DienThoai = value; }
    }
}
