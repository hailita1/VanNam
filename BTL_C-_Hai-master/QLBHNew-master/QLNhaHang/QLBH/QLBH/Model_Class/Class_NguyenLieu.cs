using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Model_Class
{
    public class Class_NguyenLieu
    {
        private string MaNguyenLieu;
        private string TenNguyenLieu;
        private string DonViTinh;
        private double SoLuong;
        private decimal DonGiaNhap;
        private decimal DonGiaBan;
        private string CongDung;
        private string YeuCau;
        private string ChongChiDinh;
        public Class_NguyenLieu()
        {

        }
        public Class_NguyenLieu(string MaNguyenLieu, string TenNguyenLieu, string DonViTinh, double SoLuong, decimal DonGiaNhap, decimal DonGiaBan, string CongDung, string YeuCau, string ChongChiDinh)
        {
            this.MaNguyenLieu = MaNguyenLieu;
            this.TenNguyenLieu = TenNguyenLieu;
            this.DonViTinh = DonViTinh;
            this.SoLuong = SoLuong;
            this.DonGiaNhap = DonGiaNhap;
            this.DonGiaBan = DonGiaBan;
            this.CongDung = CongDung;
            this.YeuCau = YeuCau;
            this.ChongChiDinh = ChongChiDinh;
        }

        public string MaNguyenLieu1 { get => MaNguyenLieu; set => MaNguyenLieu = value; }
        public string TenNguyenLieu1 { get => TenNguyenLieu; set => TenNguyenLieu = value; }
        public string DonViTinh1 { get => DonViTinh; set => DonViTinh = value; }
        public double SoLuong1 { get => SoLuong; set => SoLuong = value; }
        public decimal DonGiaNhap1 { get => DonGiaNhap; set => DonGiaNhap = value; }
        public decimal DonGiaBan1 { get => DonGiaBan; set => DonGiaBan = value; }
        public string CongDung1 { get => CongDung; set => CongDung = value; }
        public string YeuCau1 { get => YeuCau; set => YeuCau = value; }
        public string ChongChiDinh1 { get => ChongChiDinh; set => ChongChiDinh = value; }
    }
}
