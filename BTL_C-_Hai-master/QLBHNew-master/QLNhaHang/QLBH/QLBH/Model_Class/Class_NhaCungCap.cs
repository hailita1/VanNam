using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Model_Class
{
    public class Class_NhaCungCap
    {
        private string MaNhaCungCap;
        private string TenNhaCungCap;
        private string DiaChi;
        private string DienThoai;
        public Class_NhaCungCap()
        {

        }
        public Class_NhaCungCap(string MaNhaCungCap, string TenNhaCungCap, string DiaChi, string DienThoai)
        {
            this.MaNhaCungCap = MaNhaCungCap;
            this.TenNhaCungCap = TenNhaCungCap;
            this.DiaChi = DiaChi;
            this.DienThoai = DienThoai;
        }

        public string MaNhaCungCap1 { get => MaNhaCungCap; set => MaNhaCungCap = value; }
        public string TenNhaCungCap1 { get => TenNhaCungCap; set => TenNhaCungCap = value; }
        public string DiaChi1 { get => DiaChi; set => DiaChi = value; }
        public string DienThoai1 { get => DienThoai; set => DienThoai = value; }
    }
}
