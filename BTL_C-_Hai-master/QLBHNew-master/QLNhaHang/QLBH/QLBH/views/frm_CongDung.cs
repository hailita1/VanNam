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
using System.Data.SqlClient;
using QLBH.Repository;
using System.Data.Common;

namespace QLBH
{
    public partial class frm_CongDung : DevExpress.XtraEditors.XtraForm
    {
        List<Class_CongDung> Test;
        List<Class_CongDung> Test1;
        ConnectAndQuery query = new ConnectAndQuery();
        public frm_CongDung()
        {
            InitializeComponent();
            fill();
        }
        public new List<Class_CongDung> test1()
        {
            string sql = "SELECT * FROM CongDung";
            List<Class_CongDung> list = new List<Class_CongDung>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-MFCIF4Q\SQLEXPRESS;Initial Catalog=TestVanDuong;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string MaCongDung = reader.GetString(0);
                        string TenCongDung = reader.GetString(1);
                        Class_CongDung Test = new Class_CongDung(MaCongDung, TenCongDung);
                        list.Add(Test);
                    }
                }
            }
            con.Close();
            return list;
        }
        private void fill()
        {
            DataTable data = query.DocBang("select * from CongDung");
            dataGridView1.DataSource = data;
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn xóa không ?", "thông báo", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "delete from CongDung where MaCongDung = N'" + txt_LoaiBenh.Text + "'";
                query.CapNhatDuLieu(sql);
                fill();

                txt_LoaiBenh.Text = "";
                txt_STT.Text = "";
            }
        }

        private void Btn_refesrh_Click(object sender, EventArgs e)
        {
            if (txt_LoaiBenh.Text.Trim() != "" && txt_STT.Text.Trim() != "")
            {
                string sql = "UPDATE CongDung set TenCongDung=N'" + txt_STT.Text + "' where MaCongDung=N'"+txt_LoaiBenh.Text+"'";
                query.CapNhatDuLieu(sql);
                fill();


                txt_LoaiBenh.Text = "";
                txt_STT.Text = "";
            }
            else
            {
                MessageBox.Show("vui lòng nhập đầy đủ thông tin");
            }
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            Test = test1();
            bool check = false;

            for (int i = 0; i < Test.Count; i++)
            {
                if (Test[i].MaCongDung1.Equals(txt_LoaiBenh.Text))
                {
                    check = true;
                    MessageBox.Show("đã có mã phiếu này, vui lòng nhập lại");
                    break;
                }

            }
            if (check == false && txt_LoaiBenh.Text.Trim() != "" && txt_STT.Text.Trim() != "")
            {
                string sql = "insert into CongDung values(N'" + txt_LoaiBenh.Text + "',N'" + txt_STT.Text+ "')";
                query.CapNhatDuLieu(sql);
                fill();

               
                txt_LoaiBenh.Text = "";
                txt_STT.Text = "";
            }
            else
            {
                MessageBox.Show("vui lòng nhập đầy đủ thông tin");
            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ban co muon thoat khong ?", "thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txt_LoaiBenh.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_STT.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}