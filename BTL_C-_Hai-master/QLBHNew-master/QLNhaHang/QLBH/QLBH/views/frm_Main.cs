using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using QLBH.views;
using System.Windows.Forms;
namespace QLBH
{
    public partial class frm_Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private static XtraTabControl tabstatic;
        

       
        public frm_Main()
        {
            InitializeComponent();
            tabstatic = xtraTabControl1;
            
        }
       // #region Kiểm tra TabPabPage có tồn tại không
        public static bool KiemTraTabPage(string Ten)
        {
            bool ok = false;
            foreach (XtraTabPage tabpage in tabstatic.TabPages)
            {
                if (tabpage.Text == Ten)
                {
                    return ok = true;
                }
            }
            return ok;
        }
        //#region Tìm vị trí TabPage
        public static int ViTriTabPage(string Ten)
        {
            int vitri = 0;
            for (int i = 0; i < tabstatic.TabPages.Count; i++)
            {
                if (tabstatic.TabPages[i].Text == Ten)
                    vitri = i;
            }
            return vitri;
        }
        public static void thoattab()
        {
            int i = tabstatic.SelectedTabPageIndex;
            tabstatic.TabPages.RemoveAt(i);
            tabstatic.SelectedTabPageIndex = i - 1;
        }

        private void xtraTabControl1_CloseButtonClick(object sender, System.EventArgs e)
        {
            int h = 0;
            ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
            if (xtraTabControl1.SelectedTabPage.Equals((arg.Page as XtraTabPage)))
                h =xtraTabControl1.SelectedTabPageIndex;
            if ((arg.Page as XtraTabPage).Text != "Bắt đầu")
            {
                xtraTabControl1.TabPages.Remove((arg.Page as XtraTabPage));

                xtraTabControl1.SelectedTabPageIndex = h - 1;
            }
            else
                XtraMessageBox.Show("Bạn không thể tắt\nTab bắt đầu này !", "Thông báo");
        }
        // Mở form chi tiết hồ sơ nhân viên.
        private void Bar_btn_HoSoNhanVien_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage TabHoSoNhanVien = new XtraTabPage();
            TabHoSoNhanVien.Text = "Hồ sơ nhân viên";
            if (KiemTraTabPage(TabHoSoNhanVien.Text) == false)
                xtraTabControl1.TabPages.Add(TabHoSoNhanVien);
            else
                TabHoSoNhanVien.PageVisible = true;
            frm_HoSoNhanVien frm = new frm_HoSoNhanVien();
            frm.TopLevel = false;
            frm.Parent = xtraTabControl1.TabPages[ViTriTabPage(TabHoSoNhanVien.Text)];
            frm.Dock = DockStyle.Fill;
            frm.Show();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[ViTriTabPage(TabHoSoNhanVien.Text)];
        }
        // Mở form Nhân viên quán.
        private void btn_QueQuan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage TabQueQuan = new XtraTabPage();
            TabQueQuan.Text = "Quê Quán-Nhân Viên";
            if (KiemTraTabPage(TabQueQuan.Text) == false)
            {
                xtraTabControl1.TabPages.Add(TabQueQuan);
            }
            else
                TabQueQuan.PageVisible = true;
            Frm_QueQuan frm = new Frm_QueQuan();
            frm.TopLevel = false;
            frm.Parent = xtraTabControl1.TabPages[ViTriTabPage(TabQueQuan.Text)];
            frm.Dock = DockStyle.Fill;
            frm.Show();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[ViTriTabPage(TabQueQuan.Text)];
        }

        //Mở Tab Chi Tiết Món Ăn
        private void btn_MonAn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage TabMonAn = new XtraTabPage();
            TabMonAn.Text = "Quản Lý Món Ăn";
            if (KiemTraTabPage(TabMonAn.Text) == false)
            {
                xtraTabControl1.TabPages.Add(TabMonAn);
            }
            else
                TabMonAn.PageVisible = true;
            frm_MonAn frm = new frm_MonAn();
            frm.TopLevel = false;
            frm.Parent = xtraTabControl1.TabPages[ViTriTabPage(TabMonAn.Text)];
            frm.Dock = DockStyle.Fill;
            frm.Show();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[ViTriTabPage(TabMonAn.Text)];
        }

        //Mở Tab Công Dụng
        private void btn_CongDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage TabCongDung = new XtraTabPage();
            TabCongDung.Text = "Công Dụng";
            if (KiemTraTabPage(TabCongDung.Text) == false)
            {
                xtraTabControl1.TabPages.Add(TabCongDung);
            }
            else
                TabCongDung.PageVisible = true;
            frm_CongDung frm = new frm_CongDung();
            frm.TopLevel = false;
            frm.Parent = xtraTabControl1.TabPages[ViTriTabPage(TabCongDung.Text)];
            frm.Dock = DockStyle.Fill;
            frm.Show();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[ViTriTabPage(TabCongDung.Text)];
        }

        //Mở tab Loại Món ăn
        private void btn_LoaiMonAn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage TabLoaiMonAn = new XtraTabPage();
            TabLoaiMonAn.Text = "Loại Món Ăn";
            if (KiemTraTabPage(TabLoaiMonAn.Text) == false)
            {
                xtraTabControl1.TabPages.Add(TabLoaiMonAn);
            }
            else
                TabLoaiMonAn.PageVisible = true;
            frm_LoaiMonAn frm = new frm_LoaiMonAn();
            frm.TopLevel = false;
            frm.Parent = xtraTabControl1.TabPages[ViTriTabPage(TabLoaiMonAn.Text)];
            frm.Dock = DockStyle.Fill;
            frm.Show();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[ViTriTabPage(TabLoaiMonAn.Text)];
        }

        //Mở Tab nguyên liệu-Món Ăn
        private void btn_NguyenLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage TabNL_MA = new XtraTabPage();
            TabNL_MA.Text = "Nguyên Liệu-Món Ăn";
            if (KiemTraTabPage(TabNL_MA.Text) == false)
            {
                xtraTabControl1.TabPages.Add(TabNL_MA);
            }
            else
                TabNL_MA.PageVisible = true;
            frm_NguyenLieu_MonAn frm = new frm_NguyenLieu_MonAn();
            frm.TopLevel = false;
            frm.Parent = xtraTabControl1.TabPages[ViTriTabPage(TabNL_MA.Text)];
            frm.Dock = DockStyle.Fill;
            frm.Show();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[ViTriTabPage(TabNL_MA.Text)];
        }

        //Mở Tab Nguyên Liệu
        private void btn_ChiTietNguyenLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage TabNguyenLieu = new XtraTabPage();
            TabNguyenLieu.Text = "Hồ Sơ Nguyên Liệu";
            if (KiemTraTabPage(TabNguyenLieu.Text) == false)
            {
                xtraTabControl1.TabPages.Add(TabNguyenLieu);
            }
            else
                TabNguyenLieu.PageVisible = true;
            frm_NguyenLieu frm = new frm_NguyenLieu();
            frm.TopLevel = false;
            frm.Parent = xtraTabControl1.TabPages[ViTriTabPage(TabNguyenLieu.Text)];
            frm.Dock = DockStyle.Fill;
            frm.Show();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[ViTriTabPage(TabNguyenLieu.Text)];
        }
        //Mở Tab Nhà Cung Cấp
        private void btn_NCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage TabNhaCungCap = new XtraTabPage();
            TabNhaCungCap.Text = "Nhà Cung Cấp";
            if (KiemTraTabPage(TabNhaCungCap.Text) == false)
            {
                xtraTabControl1.TabPages.Add(TabNhaCungCap);
            }
            else
                TabNhaCungCap.PageVisible = true;
            frm_NCC frm = new frm_NCC();
            frm.TopLevel = false;
            frm.Parent = xtraTabControl1.TabPages[ViTriTabPage(TabNhaCungCap.Text)];
            frm.Dock = DockStyle.Fill;
            frm.Show();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[ViTriTabPage(TabNhaCungCap.Text)];
        }
        //Mở tab khách hàng
        private void btn_KhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage TabKhachHang = new XtraTabPage();
            TabKhachHang.Text = "Hồ Sơ Khách Hàng";
            if (KiemTraTabPage(TabKhachHang.Text) == false)
            {
                xtraTabControl1.TabPages.Add(TabKhachHang);
            }
            else
                TabKhachHang.PageVisible = true;
            frm_KhachHang frm = new frm_KhachHang();
            frm.TopLevel = false;
            frm.Parent = xtraTabControl1.TabPages[ViTriTabPage(TabKhachHang.Text)];
            frm.Dock = DockStyle.Fill;
            frm.Show();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[ViTriTabPage(TabKhachHang.Text)];
        }
        //mở tab hóa đơn nhập
        private void btn_HoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage TabHoaDon = new XtraTabPage();
            TabHoaDon.Text = "Hóa Đơn Nhập";
            if (KiemTraTabPage(TabHoaDon.Text) == false)
            {
                xtraTabControl1.TabPages.Add(TabHoaDon);
            }
            else
                TabHoaDon.PageVisible = true;
            frm_HoaDon frm = new frm_HoaDon();
            frm.TopLevel = false;
            frm.Parent = xtraTabControl1.TabPages[ViTriTabPage(TabHoaDon.Text)];
            frm.Dock = DockStyle.Fill;
            frm.Show();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[ViTriTabPage(TabHoaDon.Text)];
        }
        //Mở Tab Chi tiết hóa đơn nhập
        private void btn_ChiTietHD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage TabChiTietHD = new XtraTabPage();
            TabChiTietHD.Text = "Chi Tiết Hóa Đơn Nhập";
            if (KiemTraTabPage(TabChiTietHD.Text) == false)
            {
                xtraTabControl1.TabPages.Add(TabChiTietHD);
            }
            else
                TabChiTietHD.PageVisible = true;
            frm_ChiTietHD frm = new frm_ChiTietHD();
            frm.TopLevel = false;
            frm.Parent = xtraTabControl1.TabPages[ViTriTabPage(TabChiTietHD.Text)];
            frm.Dock = DockStyle.Fill;
            frm.Show();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[ViTriTabPage(TabChiTietHD.Text)];
        }
        //Mở tab đặt bàn
        private void btn_DatBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage TabDatBan = new XtraTabPage();
            TabDatBan.Text = "Phiếu Đặt Bàn";
            if (KiemTraTabPage(TabDatBan.Text) == false)
            {
                xtraTabControl1.TabPages.Add(TabDatBan);
            }
            else
                TabDatBan.PageVisible = true;
            frm_DatBan frm = new frm_DatBan();
            frm.TopLevel = false;
            frm.Parent = xtraTabControl1.TabPages[ViTriTabPage(TabDatBan.Text)];
            frm.Dock = DockStyle.Fill;
            frm.Show();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[ViTriTabPage(TabDatBan.Text)];
        }
        //mở tab chi tiết đặt bàn
        private void btn_chitietdatban_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage TabChiTietDatBan = new XtraTabPage();
            TabChiTietDatBan.Text = "Chi Tiết Phiếu Đặt Bàn";
            if (KiemTraTabPage(TabChiTietDatBan.Text) == false)
            {
                xtraTabControl1.TabPages.Add(TabChiTietDatBan);
            }
            else
                TabChiTietDatBan.PageVisible = true;
            frm_chitietdatban frm = new frm_chitietdatban();
            frm.TopLevel = false;
            frm.Parent = xtraTabControl1.TabPages[ViTriTabPage(TabChiTietDatBan.Text)];
            frm.Dock = DockStyle.Fill;
            frm.Show();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[ViTriTabPage(TabChiTietDatBan.Text)];
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            
            this.Close();
        }

        private void Frm_Main_Load(object sender, System.EventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage TabBaoCaoTongTien = new XtraTabPage();
            TabBaoCaoTongTien.Text = "Chi Báo Cáo Tổng Tiền";
            if (KiemTraTabPage(TabBaoCaoTongTien.Text) == false)
            {
                xtraTabControl1.TabPages.Add(TabBaoCaoTongTien);
            }
            else
                TabBaoCaoTongTien.PageVisible = true;
            frm_RpTongTien frm = new frm_RpTongTien();
            frm.TopLevel = false;
            frm.Parent = xtraTabControl1.TabPages[ViTriTabPage(TabBaoCaoTongTien.Text)];
            frm.Dock = DockStyle.Fill;
            frm.Show();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[ViTriTabPage(TabBaoCaoTongTien.Text)];
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage TabThongTinPhienBan = new XtraTabPage();
            TabThongTinPhienBan.Text = "Thông Tin Phiên Bản";
            if (KiemTraTabPage(TabThongTinPhienBan.Text) == false)
            {
                xtraTabControl1.TabPages.Add(TabThongTinPhienBan);
            }
            else
                TabThongTinPhienBan.PageVisible = true;
            frm_ThongTinPhienBan frm = new frm_ThongTinPhienBan();
            frm.TopLevel = false;
            frm.Parent = xtraTabControl1.TabPages[ViTriTabPage(TabThongTinPhienBan.Text)];
            frm.Dock = DockStyle.Fill;
            frm.Show();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[ViTriTabPage(TabThongTinPhienBan.Text)];
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage TabBaoCaoPDB = new XtraTabPage();
            TabBaoCaoPDB.Text = "Báo Cáo Phiếu Đặt Bàn";
            if (KiemTraTabPage(TabBaoCaoPDB.Text) == false)
            {
                xtraTabControl1.TabPages.Add(TabBaoCaoPDB);
            }
            else
                TabBaoCaoPDB.PageVisible = true;
            frm_RpPhieuDatBan frm = new frm_RpPhieuDatBan();
            frm.TopLevel = false;
            frm.Parent = xtraTabControl1.TabPages[ViTriTabPage(TabBaoCaoPDB.Text)];
            frm.Dock = DockStyle.Fill;
            frm.Show();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[ViTriTabPage(TabBaoCaoPDB.Text)];
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage TabBaoCao = new XtraTabPage();
            TabBaoCao.Text = "Báo Cáo Món Ăn";
            if (KiemTraTabPage(TabBaoCao.Text) == false)
            {
                xtraTabControl1.TabPages.Add(TabBaoCao);
            }
            else
                TabBaoCao.PageVisible = true;
            frm_RpMonAn frm = new frm_RpMonAn();
            frm.TopLevel = false;
            frm.Parent = xtraTabControl1.TabPages[ViTriTabPage(TabBaoCao.Text)];
            frm.Dock = DockStyle.Fill;
            frm.Show();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[ViTriTabPage(TabBaoCao.Text)];
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage TabBaoCaoNhapXuat = new XtraTabPage();
            TabBaoCaoNhapXuat.Text = "Báo Cáo Nhập Xuất";
            if (KiemTraTabPage(TabBaoCaoNhapXuat.Text) == false)
            {
                xtraTabControl1.TabPages.Add(TabBaoCaoNhapXuat);
            }
            else
                TabBaoCaoNhapXuat.PageVisible = true;
            frm_RpNhapXuat frm = new frm_RpNhapXuat();
            frm.TopLevel = false;
            frm.Parent = xtraTabControl1.TabPages[ViTriTabPage(TabBaoCaoNhapXuat.Text)];
            frm.Dock = DockStyle.Fill;
            frm.Show();
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[ViTriTabPage(TabBaoCaoNhapXuat.Text)];
        }
    }
}
