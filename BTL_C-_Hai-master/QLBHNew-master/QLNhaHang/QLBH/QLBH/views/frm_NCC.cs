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
    public partial class frm_NCC : DevExpress.XtraEditors.XtraForm
    {
        List<Class_NhaCungCap> nhacc = new List<Class_NhaCungCap>();
        ConnectAndQuery query = new ConnectAndQuery();
        public frm_NCC()
        {
            InitializeComponent();
        }
        private void fill()
        {
            dataGridView1.DataSource = query.DocBang("Select * from NhaCungCap");
        }
        private void frm_NCC_Load(object sender, EventArgs e)
        {
            fill();
        }

        public new List<Class_NhaCungCap> Select()
        {
            string sql = "SELECT * FROM NhaCungCap";
            List<Class_NhaCungCap> list = new List<Class_NhaCungCap>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=MINH_VU_PC\SQLEXPRESS;Initial Catalog=BTL;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string MaNhaCungCap = reader.GetString(0);
                        string TenNhaCungCap = reader.GetString(1);
                        string DiaChi = reader.GetString(2);
                        string DienThoai = reader.GetString(3);
                        Class_NhaCungCap ncc = new Class_NhaCungCap(MaNhaCungCap, TenNhaCungCap, DiaChi, DienThoai);
                        list.Add(ncc);
                    }
                }
            }
            con.Close();
            return list;
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            nhacc = Select();
            bool check = false;
            for (int i = 0; i < nhacc.Count; i++)
            {
                if (nhacc[i].MaNhaCungCap1.Equals(txt_mancc.Text) || nhacc[i].TenNhaCungCap1.Equals(txt_tenncc.Text))
                {
                    check = true;
                    MessageBox.Show("đã có mã hoặc tên nhà cung cấp này");
                    break;
                }
            }

            if (check == false)
            {

                if (txt_mancc.Text.Trim() != "" || txt_tenncc.Text.Trim() != "" || txt_diachincc.Text.Trim() != "" || txt_dienthoaincc.Text.Trim() != "")
                {

                    string sql = "insert into NhaCungCap values(N'" + txt_mancc.Text + "',N'" + txt_tenncc.Text + "',N'" + txt_diachincc.Text + "','" + txt_dienthoaincc.Text + "')";
                    query.CapNhatDuLieu(sql);
                    fill();
                    nhacc.Add(new Class_NhaCungCap(txt_mancc.Text, txt_tenncc.Text, txt_diachincc.Text, txt_dienthoaincc.Text));
                    txt_mancc.Text = "";
                    txt_tenncc.Text = "";
                    txt_diachincc.Text = "";
                    txt_dienthoaincc.Text = "";

                    
                }
                else
                {
                    MessageBox.Show("vui lòng nhập đầy đủ thông tin");
                }
            }
        }



        private void Btn_refesrh_Click(object sender, EventArgs e)
        {
            nhacc = Select();

            if (txt_mancc.Text.Trim() != "" || txt_tenncc.Text.Trim() != "" || txt_diachincc.Text.Trim() != "" || txt_dienthoaincc.Text.Trim() != "")
            {

                string sql = "update NhaCungCap set TenNhaCungCap=N'" + txt_tenncc.Text + "',DiaChi=N'" + txt_diachincc.Text + "',DienThoai='" + txt_dienthoaincc.Text + "' where MaNhaCungCap=N'" + txt_mancc.Text + "'";
                query.CapNhatDuLieu(sql);
                fill();
                nhacc.Add(new Class_NhaCungCap(txt_mancc.Text, txt_tenncc.Text, txt_diachincc.Text, txt_dienthoaincc.Text));
                txt_mancc.Text = "";
                txt_tenncc.Text = "";
                txt_diachincc.Text = "";
                txt_dienthoaincc.Text = "";
                txt_mancc.Enabled = true;
            }
            else
            {
                MessageBox.Show("vui lòng nhập đầy đủ thông tin");
            }


        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn xóa không ?", "thông báo", MessageBoxButtons.YesNo,
              MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string sql = "delete from NhaCungCap where MaNhaCungCap=N'" + txt_mancc.Text + "'";
                query.CapNhatDuLieu(sql);
                fill();
                txt_mancc.Text = "";
                txt_tenncc.Text = "";
                txt_diachincc.Text = "";
                txt_dienthoaincc.Text = "";

                txt_mancc.Enabled = true;
            }
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txt_mancc.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_tenncc.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_diachincc.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_dienthoaincc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_mancc.Enabled = false;
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn thoát không ?", "thông báo", MessageBoxButtons.YesNo,
              MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}