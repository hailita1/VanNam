using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBH.Model_Class;
using QLBH.Repository;
using System.Data.SqlClient;
using System.Data.Common;

namespace QLBH
{
    public partial class frm_ChiTietHD : DevExpress.XtraEditors.XtraForm
    {
        List<Class_HoaDonNhap> hoaDonNhap;
        List<Class_NguyenLieu> nguyenLieu;
        List<Class_ChiTietHoaDonNhap> chiTietHoaDonNhap;
        ConnectAndQuery query = new ConnectAndQuery();

        public frm_ChiTietHD()
        {
            InitializeComponent();
            hoaDonNhap = new frm_HoaDon().Select();
            nguyenLieu = new frm_NguyenLieu().Select();
        }
        public new List<Class_ChiTietHoaDonNhap> Select()
        {
            string sql = "Select * from ChiTietHoaDonNhap";
            List<Class_ChiTietHoaDonNhap> list = new List<Class_ChiTietHoaDonNhap>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-MFCIF4Q\SQLEXPRESS;Initial Catalog=TestVanDuong;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        String MaNguyenLieu = reader.GetString(0);
                        String MaHoaDonNhap = reader.GetString(1);
                        double SoLuong = (double)reader.GetValue(2);
                        decimal DonGia = reader.GetDecimal(3);
                        decimal KhuyenMai = reader.GetDecimal(4);
                        decimal ThanhTien = reader.GetDecimal(5);
                        Class_ChiTietHoaDonNhap chiTietHoaDonNhap1 = new Class_ChiTietHoaDonNhap(MaNguyenLieu, MaHoaDonNhap, SoLuong, DonGia, KhuyenMai, ThanhTien);
                        list.Add(chiTietHoaDonNhap1);
                    }
            }
            con.Close();
            return list;
        }
        private void fill()
        {
            dataGridView1.DataSource = query.DocBang("select * from ChiTietHoaDonNhap");
        }
        private void add()
        {
            hoaDonNhap = new frm_HoaDon().Select();
            nguyenLieu = new frm_NguyenLieu().Select();
            for (int i = 0; i < hoaDonNhap.Count; i++)
            {
                cb_mahd.Items.Add(hoaDonNhap[i].MaHoaDonNhap1);
            }
            for (int i = 0; i < nguyenLieu.Count; i++)
            {
                cb_manl.Items.Add(nguyenLieu[i].MaNguyenLieu1);
            }
        }

        private void Frm_ChiTietHD_Load(object sender, EventArgs e)
        {
            fill();
            cb_mahd.Focus();
            add();
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void Btn_refesrh_Click(object sender, EventArgs e)
        {
            hoaDonNhap = new frm_HoaDon().Select();
            nguyenLieu = new frm_NguyenLieu().Select();
            bool nl = false, hdn = false;
            for (int i = 0; i < hoaDonNhap.Count; i++)
            {
                if (hoaDonNhap[i].MaHoaDonNhap1.Equals(cb_mahd.Text))
                {
                    hdn = true;
                    break;
                }
            }
            if (hdn == false)
            {
                MessageBox.Show("Bạn chưa có mã hóa đơn này");
            }

            for (int i = 0; i < nguyenLieu.Count; i++)
            {
                if (nguyenLieu[i].MaNguyenLieu1.Equals(cb_manl.Text))
                {
                    nl = true;
                    break;
                }
            }
            if (nl == false)
            {
                MessageBox.Show("Bạn chưa có mã nguyên liệu này");
            }
            decimal x;
            bool number = false;
            if (!decimal.TryParse(txt_ThanhTien.Text, out x))
            {
                number = true;
                MessageBox.Show("Bạn cần nhập số");

            }
            decimal x1;
            bool number1 = false;
            if (!decimal.TryParse(txt_SoLuong.Text, out x))
            {
                number1 = true;
                MessageBox.Show("Bạn cần nhập số");

            }
            decimal x2;
            bool number2 = false;
            if (!decimal.TryParse(txt_DonGia.Text, out x))
            {
                number2 = true;
                MessageBox.Show("Bạn cần nhập số");

            }
            decimal x3;
            bool number3 = false;
            if (!decimal.TryParse(txt_KhuyenMai.Text, out x))
            {
                number3 = true;
                MessageBox.Show("Bạn cần nhập số");

            }
            chiTietHoaDonNhap = Select();

            if (cb_mahd.Text.Trim() != "" && cb_manl.Text.Trim() != "" && txt_SoLuong.Text.Trim() != "" && txt_ThanhTien.Text.Trim() != "" &&
                   txt_KhuyenMai.Text.Trim() != "" && txt_DonGia.Text.Trim() != "" && nl == true && hdn == true && number == false && number1 == false && number2 == false && number3 == false)
            {
                String sql = "update ChiTietHoaDonNhap set SoLuong=N'" + txt_SoLuong + "', DonGia=N'" + txt_DonGia.Text + "', KhuyenMai=N'" + txt_KhuyenMai.Text + "', ThanhTien=N'" + txt_ThanhTien.Text + "' where MaKhach = N'" + cb_mahd.Text + "' and MaNguyenLieu=N'" + cb_manl.Text + "'";
                query.CapNhatDuLieu(sql);
                fill();
                chiTietHoaDonNhap.Add(new Class_ChiTietHoaDonNhap(cb_mahd.Text, cb_manl.Text, Convert.ToDouble(txt_SoLuong.Text), Convert.ToDecimal(txt_DonGia.Text), Convert.ToDecimal(txt_KhuyenMai.Text), Convert.ToDecimal(txt_ThanhTien.Text)));
                cb_mahd.Text = "";
                cb_manl.Text = "";
                txt_SoLuong.Text = "";
                txt_DonGia.Text = "";
                txt_KhuyenMai.Text = "";
                txt_ThanhTien.Text = "";
                cb_mahd.Enabled = true;
                cb_manl.Enabled = true;
                cb_mahd.Focus();
            }
            else
            {
                MessageBox.Show("Bạn hãy nhập đủ thông tin");
            }
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "delete from ChiTietHoaDonNhap where MaHoaDonNhap=N'" + cb_mahd.Text + "'";
                query.CapNhatDuLieu(sql);
                fill();
                cb_mahd.Enabled = true;
                cb_mahd.Text = "";
                cb_manl.Text = "";
                txt_SoLuong.Text = " ";
                txt_DonGia.Text = "";
                txt_KhuyenMai.Text = " ";
                txt_ThanhTien.Text = "";
            }
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            cb_mahd.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cb_manl.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_SoLuong.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_DonGia.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_KhuyenMai.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_ThanhTien.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void Btn_Add_Click_1(object sender, EventArgs e)
        {
            chiTietHoaDonNhap = Select();
            hoaDonNhap = new frm_HoaDon().Select();
            nguyenLieu = new frm_NguyenLieu().Select();
            bool nl = false, hdn = false;
            bool check = false;
            for (int i = 0; i < chiTietHoaDonNhap.Count; i++)
            {
                if (chiTietHoaDonNhap[i].MaHoaDonNhap1.Equals(cb_mahd.Text) && chiTietHoaDonNhap[i].MaNguyenLieu1.Equals(cb_manl.Text))
                {
                    check = true;
                    MessageBox.Show("Đã có dữ liệu");
                    break;
                }
            }
            for (int i = 0; i < hoaDonNhap.Count; i++)
            {
                if (hoaDonNhap[i].MaHoaDonNhap1.Equals(cb_mahd.Text))
                {
                    hdn = true;
                    break;
                }
            }
            if (hdn == false)
            {
                MessageBox.Show("Bạn chưa có mã hóa đơn này");
            }

            for (int i = 0; i < nguyenLieu.Count; i++)
            {
                if (nguyenLieu[i].MaNguyenLieu1.Equals(cb_manl.Text))
                {
                    nl = true;
                    break;
                }
            }
            if (nl == false)
            {
                MessageBox.Show("Bạn chưa có mã nguyên liệu này");
            }

            decimal x;
            bool number = false;
            if (!decimal.TryParse(txt_ThanhTien.Text, out x))
            {
                number = true;
                MessageBox.Show("Bạn cần nhập số");

            }
            decimal x1;
            bool number1 = false;
            if (!decimal.TryParse(txt_SoLuong.Text, out x))
            {
                number = true;
                MessageBox.Show("Bạn cần nhập số");

            }
            decimal x2;
            bool number2 = false;
            if (!decimal.TryParse(txt_DonGia.Text, out x))
            {
                number = true;
                MessageBox.Show("Bạn cần nhập số");

            }
            decimal x3;
            bool number3 = false;
            if (!decimal.TryParse(txt_KhuyenMai.Text, out x))
            {
                number = true;
                MessageBox.Show("Bạn cần nhập số");

            }

            if (check == false && nl == true && hdn == true && number == false && number1 == false && number2 == false && number3 == false)
            {
                if (cb_mahd.Text.Trim() != "" && cb_manl.Text.Trim() != "" && txt_SoLuong.Text.Trim() != "" && txt_ThanhTien.Text.Trim() != "" &&
                    txt_KhuyenMai.Text.Trim() != "" && txt_DonGia.Text.Trim() != "")
                {

                    string sql = "insert into ChiTietHoaDonNhap values(N'" + cb_mahd.Text + "',N'" + cb_manl.Text + "',N'" + txt_SoLuong.Text + "',N'" + txt_DonGia.Text + "',N'" + txt_KhuyenMai.Text + "',N'" + txt_ThanhTien.Text + "')";
                    query.CapNhatDuLieu(sql);
                    fill();
                    chiTietHoaDonNhap.Add(new Class_ChiTietHoaDonNhap(cb_manl.Text, cb_mahd.Text, Convert.ToDouble(txt_SoLuong.Text), Convert.ToDecimal(txt_DonGia.Text), Convert.ToDecimal(txt_KhuyenMai.Text), Convert.ToDecimal(txt_SoLuong.Text)));
                    cb_manl.Text = "";
                    cb_mahd.Text = "";
                    txt_SoLuong.Text = "";
                    txt_DonGia.Text = "";
                    txt_KhuyenMai.Text = "";
                    txt_ThanhTien.Text = "";
                    cb_mahd.Focus();

                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
            }

        }
    }
}