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
    public partial class frm_KhachHang : DevExpress.XtraEditors.XtraForm
    {
        List<Class_Khach> khach;
        ConnectAndQuery query = new ConnectAndQuery();
        public frm_KhachHang()
        {
            InitializeComponent();
        }
        public new List<Class_Khach> Select()
        {
            string sql = "Select * from Khach";
            List<Class_Khach> list = new List<Class_Khach>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-MFCIF4Q\SQLEXPRESS;Initial Catalog=TestVanDuong;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        String MaKhach = reader.GetString(0);
                        String TenKhach = reader.GetString(1);
                        String DiaChi = reader.GetString(2);
                        String DienThoai = reader.GetString(3);
                        Class_Khach khach1 = new Class_Khach(MaKhach, TenKhach, DiaChi, DienThoai);
                        list.Add(khach1);
                    }
            }
            con.Close();
            return list;
        }
        private void fill()
        {
            dataGridView1.DataSource = query.DocBang("select * from Khach");
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            khach = Select();
            bool check = false;
            for (int i = 0; i < khach.Count; i++)
            {
                if (khach[i].MaKhach1.Equals(txt_MaKhach.Text))
                {
                    check = true;
                    MessageBox.Show("Đã có dữ liệu");
                    break;
                }
            }
            if (check == false)
            {
                if (txt_MaKhach.Text.Trim() != "" && txt_TenKhach.Text.Trim() != "" && txt_DienThoai.Text.Trim() != "" && txt_DiaChi.Text.Trim() != "")
                {

                    string sql = "insert into Khach values(N'" + txt_MaKhach.Text + "',N'" + txt_TenKhach.Text + "',N'" + txt_DiaChi.Text + "',N'" + txt_DienThoai.Text + "')";
                    query.CapNhatDuLieu(sql);
                    fill();
                    khach.Add(new Class_Khach(txt_MaKhach.Text, txt_TenKhach.Text, txt_DiaChi.Text, txt_DienThoai.Text));
                    txt_TenKhach.Text = "";
                    txt_MaKhach.Text = "";
                    txt_DienThoai.Text = "";
                    txt_DiaChi.Text = "";
                    txt_MaKhach.Focus();

                }
                else
                {
                    MessageBox.Show("vui lòng nhập đầy đủ thông tin");
                }
            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ;
            this.Close();
        }

        private void Btn_refesrh_Click(object sender, EventArgs e)
        {
            khach = Select();
            if (txt_TenKhach.Text.Trim() != "" && txt_DiaChi.Text.Trim() != "" && txt_DienThoai.Text.Trim() != "" && txt_MaKhach.Text.Trim() != "")
            {
                String sql = "update Khach set TenKhach=N'" + txt_TenKhach.Text + "', DiaChi=N'" + txt_DiaChi.Text + "', DienThoai=N'" + txt_DienThoai.Text + "' where MaKhach = N'" + txt_MaKhach.Text + "'";
                query.CapNhatDuLieu(sql);
                fill();
                khach.Add(new Class_Khach(txt_MaKhach.Text, txt_TenKhach.Text, txt_DiaChi.Text, txt_DienThoai.Text));
                txt_MaKhach.Text = "";
                txt_TenKhach.Text = "";
                txt_DienThoai.Text = "";
                txt_DiaChi.Text = "";
                txt_MaKhach.Enabled = true;
                txt_MaKhach.Focus();
            }
            else
            {
                MessageBox.Show("Bạn hãy nhập đủ thông tin khách hàng");
            }

        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txt_MaKhach.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_TenKhach.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_DiaChi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_DienThoai.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "delete from Khach where MaKhach=N'" + txt_MaKhach.Text + "'";
                query.CapNhatDuLieu(sql);
                fill();
                txt_MaKhach.Enabled = true;
                txt_MaKhach.Text = "";
                txt_TenKhach.Text = "";
                txt_DienThoai.Text = " ";
                txt_DiaChi.Text = "";
            }
        }

        private void Frm_KhachHang_Load_1(object sender, EventArgs e)
        {
            fill();
            txt_MaKhach.Focus();
        }
    }
}