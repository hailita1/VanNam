using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;

namespace QLBH.Model_Class
{
    public class Class_ChiTietHoaDonNhap
    {
        private string MaHoaDonNhap;
        private string MaNguyenLieu;
        private double SoLuong;
        private decimal DonGia;
        private decimal KhuyenMai;
        private decimal ThanhTien;
        private TextEdit txt_MaHoaDonNhap;
        private object text1;
        private object text2;
        private object text3;

        public Class_ChiTietHoaDonNhap()
        {

        }

        public Class_ChiTietHoaDonNhap(TextEdit txt_MaHoaDonNhap, object text1, object text2, object text3)
        {
            this.txt_MaHoaDonNhap = txt_MaHoaDonNhap;
            this.text1 = text1;
            this.text2 = text2;
            this.text3 = text3;
        }

        public Class_ChiTietHoaDonNhap(string MaHoaDonNhap, string MaNguyenLieu, double SoLuong, decimal DonGia, decimal KhuyenMai, decimal ThanhTien)
        {
            this.MaHoaDonNhap = MaHoaDonNhap;
            this.MaNguyenLieu = MaNguyenLieu;
            this.SoLuong = SoLuong;
            this.DonGia = DonGia;
            this.KhuyenMai = KhuyenMai;
            this.ThanhTien = ThanhTien;
        }

        public string MaHoaDonNhap1 { get => MaHoaDonNhap; set => MaHoaDonNhap = value; }
        public string MaNguyenLieu1 { get => MaNguyenLieu; set => MaNguyenLieu = value; }
        public double SoLuong1 { get => SoLuong; set => SoLuong = value; }
        public decimal DonGia1 { get => DonGia; set => DonGia = value; }
        public decimal KhuyenMai1 { get => KhuyenMai; set => KhuyenMai = value; }
        public decimal ThanhTien1 { get => ThanhTien; set => ThanhTien = value; }
    }
}
