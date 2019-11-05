using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Model_Class
{
    public class Class_Khach
    {
        private string MaKhach;
        private string TenKhach;
        private string DiaChi;
        private string DienThoai;

        public Class_Khach()
        {

        }
        public Class_Khach(string MaKhach, string TenKhach, string DiaChi, string DienThoai)
        {
            this.MaKhach = MaKhach;
            this.TenKhach = TenKhach;
            this.DiaChi = DiaChi;
            this.DienThoai = DienThoai;
        }

        public string MaKhach1 { get => MaKhach; set => MaKhach = value; }
        public string TenKhach1 { get => TenKhach; set => TenKhach = value; }
        public string DiaChi1 { get => DiaChi; set => DiaChi = value; }
        public string DienThoai1 { get => DienThoai; set => DienThoai = value; }
    }
}
