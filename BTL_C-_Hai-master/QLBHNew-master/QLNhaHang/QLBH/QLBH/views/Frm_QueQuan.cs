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
using QLBH.Repository;
using QLBH.Model_Class;
using System.Data.SqlClient;
using System.Data.Common;

namespace QLBH
{
    public partial class Frm_QueQuan : DevExpress.XtraEditors.XtraForm
    {
        List<Class_Que> que;
        ConnectAndQuery query = new ConnectAndQuery();

        public Frm_QueQuan()
        {
            InitializeComponent();
            //fill();
            //que = Select();
        }
        public void fill()
        {
            dataGridView1.DataSource = query.DocBang("select * from Que");

        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            //string a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            que = Select();
            bool check = false;
            for (int i = 0; i < que.Count; i++)
            {
                if (que[i].MaQue1.Equals(txt_MaQue.Text) || que[i].TenQue1.Equals(txt_TenQue.Text))
                {
                    check = true;

                    MessageBox.Show("Đã có dữ liệu");
                    break;
                }
            }
            if (check == false)
            {
                if (txt_MaQue.Text.Trim() != "" && txt_TenQue.Text.Trim() != "")
                {

                    string sql = "insert into Que values(N'" + txt_MaQue.Text + "',N'" + txt_TenQue.Text + "')";
                    query.CapNhatDuLieu(sql);
                    fill();
                    que.Add(new Class_Que(txt_MaQue.Text, txt_TenQue.Text));
                    txt_MaQue.Text = "";
                    txt_TenQue.Text = "";
                    txt_MaQue.Focus();

                }
                else
                {
                    MessageBox.Show("vui lòng nhập đầy đủ thông tin");
                }
            }
        }
        public new List<Class_Que> Select()
        {
            string sql = "SELECT * FROM Que";
            List<Class_Que> list = new List<Class_Que>();
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
                        string MaQue = reader.GetString(0);
                        string TenQue = reader.GetString(1);
                        Class_Que que = new Class_Que(MaQue, TenQue);
                        list.Add(que);
                    }
                }
            }
            con.Close();
            return list;
        }

        private void Btn_refesrh_Click(object sender, EventArgs e)
        {
            que = Select();
            //bool check = false;
            //for (int i = 0; i < que.Count; i++)
            //{
            //    if (que[i].TenQue1.Equals(txt_TenQue.Text))
            //    {
            //        check = true;

            //        MessageBox.Show("Đã có tỉnh " + txt_TenQue.Text + " rồi");
            //        break;
            //    }
            //}
          //  if (check == false)
            //{
                if (txt_TenQue.Text.Trim() != "")
                {

                    string sql = "update Que set TenQue=N'" + txt_TenQue.Text + "' where MaQue = N'" + txt_MaQue.Text + "'";
                    query.CapNhatDuLieu(sql);
                    fill();

                    que.Add(new Class_Que(txt_MaQue.Text, txt_TenQue.Text));
                    txt_MaQue.Text = "";
                    txt_TenQue.Text = "";
                    txt_MaQue.Enabled = true;
                    txt_MaQue.Focus();

                }
                else
                {
                    MessageBox.Show("vui lòng nhập đầy đủ thông tin");
                }
        //    }

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn xóa không ?", "thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "delete from Que where MaQue=N'" + txt_MaQue.Text + "'"; ;
                query.CapNhatDuLieu(sql);
                fill();
                txt_MaQue.Enabled = true;
                txt_MaQue.Text = "";
                txt_TenQue.Text = "";
            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn thoát không ?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }

        }



        private void Frm_QueQuan_Load(object sender, EventArgs e)
        {
            fill();
            txt_MaQue.Focus();
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txt_MaQue.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_TenQue.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_MaQue.Enabled = false;

        }
    }
}