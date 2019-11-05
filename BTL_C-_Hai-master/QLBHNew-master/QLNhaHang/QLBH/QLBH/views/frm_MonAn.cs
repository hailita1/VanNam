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
    public partial class frm_MonAn : DevExpress.XtraEditors.XtraForm
    {
        List<Class_CongDung> CD = new List<Class_CongDung>();
        List<Class_LoaiMon> LM = new List<Class_LoaiMon>();
        List<Class_MonAn> MonAn;
        ConnectAndQuery query = new ConnectAndQuery();
        public frm_MonAn()
        {
            InitializeComponent();
            //fill();
            //add();
            this.textEdit2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textEdit9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textEdit4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textEdit6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
        private void add()
        {
            CD = new frm_CongDung().test1();
            LM = new frm_LoaiMonAn().Select();
            for (int i = 0; i < CD.Count; i++)
            {
                textEdit4.Items.Add(CD[i].MaCongDung1);
                textEdit9.Items.Add(CD[i].MaCongDung1);
            }
            for (int i = 0; i < LM.Count; i++)
            {
                textEdit2.Items.Add(LM[i].MaLoai1);
                textEdit6.Items.Add(LM[i].MaLoai1);
            }
        }
        public new List<Class_MonAn> Select()
        {
            string sql = "SELECT * FROM MonAn";
            List<Class_MonAn> list = new List<Class_MonAn>();
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
                        string MaMonAn = reader.GetString(0);
                        string TenMonAn = reader.GetString(1);
                        string MaCongDung = reader.GetString(2);
                        string MaLoai = reader.GetString(3);
                        string CachLam = reader.GetString(4);
                        string YeuCau = reader.GetString(5);
                        decimal DonGia = reader.GetDecimal(6);
                        Class_MonAn Test = new Class_MonAn(MaMonAn, TenMonAn, MaCongDung, MaLoai, CachLam, YeuCau, DonGia);
                        list.Add(Test);
                    }
                }
            }
            con.Close();
            return list;
        }
        private void fill()
        {
            DataTable data = query.DocBang("select * from MonAn");
            dataGridView1.DataSource = data;
        }
        private void SimpleButton5_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text.Trim() != "" || textEdit2.Text.Trim() != "" || textEdit9.Text.TrimEnd() != "")
            {
                string sql = "select * from MonAn where MaMonAn is not null";
                if (textEdit1.Text.Trim() != "")
                {
                    sql += " and TenMonAn like N'" + textEdit1.Text.Trim() + "%'";
                }
                if (textEdit2.Text.Trim() != "")
                {
                    sql += " and MaLoai like N'" + textEdit2.Text.Trim() + "%'";
                }
                if (textEdit9.Text.Trim() != "")
                {
                    sql += " and MaCongDung like N'" + textEdit9.Text.Trim() + "%'";
                }
                DataTable a = query.DocBang(sql);
                dataGridView1.DataSource = a;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập ít nhất 1 dữ liệu tìm!!");
            }

        }

        private void SimpleButton2_Click(object sender, EventArgs e)
        {
            MonAn = Select();
            bool check = false;

            for (int i = 0; i < MonAn.Count; i++)
            {
                if (MonAn[i].MaMonAn1.Equals(textEdit5.Text))
                {
                    check = true;
                    MessageBox.Show("đã có mã món ăn này, vui lòng nhập lại");
                    break;
                }
            }
            decimal x;
            if (check == false && !decimal.TryParse(textEdit8.Text, out x))
            {
                check = true;
                MessageBox.Show("Nhập sai dữ liệu giá, vui lòng nhập lại!!");
            }
            bool cd = false;
            bool lm = false;
            CD = new frm_CongDung().test1();
            LM = new frm_LoaiMonAn().Select();

            for (int i = 0; i < CD.Count; i++)
            {
                if (CD[i].MaCongDung1.Equals(textEdit4.Text))
                {
                    cd = true;
                    break;
                }
            }
            if (cd == false)
            {
                MessageBox.Show("Chưa có mã công dụng này!", "Thông báo");
            }
            else
            {
                for (int i = 0; i < LM.Count; i++)
                {
                    if (LM[i].MaLoai1.Equals(textEdit6.Text))
                    {
                        lm = true;
                        break;
                    }
                }
                if (lm == false)
                {
                    MessageBox.Show("Chưa có mã loại món ăn này!", "Thông báo");
                }
            }



            if (check == false && lm == true && cd == true)
            {
                if (textEdit3.Text.Trim() != "" && textEdit4.Text.Trim() != "" && textEdit5.Text.Trim() != "" && textEdit6.Text.Trim() != "" && textEdit7.Text.Trim() != "" && textEdit8.Text.Trim() != "" && textBox1.Text.Trim() != "")
                {
                    string sql = "insert into MonAn values(N'" + textEdit5.Text + "',N'" + textEdit3.Text + "',N'" + textEdit4.Text + "',N'" + textEdit6.Text + "',N'" + textBox1.Text + "',N'" + textEdit7.Text + "', " + Convert.ToDecimal(textEdit8.Text) + ")";
                    query.CapNhatDuLieu(sql);
                    fill();

                    //MonAn.Add(new Class_MonAn(textEdit3.Text, textEdit5.Text, textEdit4.Text, textEdit6.Text, textBox1.Text, textEdit7.Text, Convert.ToDecimal(textEdit8.Text)));
                    textEdit3.Text = "";
                    textEdit4.Text = "";
                    textEdit5.Text = "";
                    textEdit7.Text = "";
                    textEdit6.Text = "";
                    textEdit8.Text = "";
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("vui lòng nhập đầy đủ thông tin");
                }
            }
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn thoát không ?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void SimpleButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn xóa không ?", "thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "delete from MonAn where MaMonAn=N'" + textEdit5.Text + "'"; ;
                query.CapNhatDuLieu(sql);
                fill();
                textEdit3.Text = "";
                textEdit4.Text = "";
                textEdit5.Text = "";
                textEdit7.Text = "";
                textEdit6.Text = "";
                textEdit8.Text = "";
                textBox1.Text = "";
            }
        }

        private void SimpleButton3_Click(object sender, EventArgs e)
        {
            bool cd = false;
            bool lm = false;
            CD = new frm_CongDung().test1();
            LM = new frm_LoaiMonAn().Select();

            for (int i = 0; i < CD.Count; i++)
            {
                if (CD[i].MaCongDung1.Equals(textEdit4.Text))
                {
                    cd = true;
                    break;
                }
            }
            if (cd == false)
            {
                MessageBox.Show("Chưa có mã công dụng này!", "Thông báo");
            }
            else
            {
                for (int i = 0; i < LM.Count; i++)
                {
                    if (LM[i].MaLoai1.Equals(textEdit6.Text))
                    {
                        lm = true;
                        break;
                    }
                }
                if (lm == false)
                {
                    MessageBox.Show("Chưa có mã công dụng này!", "Thông báo");
                }
            }

            if (cd == true && lm == true)
            {
                MonAn = Select();
                bool check = false;
                decimal x;
                if (check == false && !decimal.TryParse(textEdit4.Text, out x))
                {
                    check = true;
                    MessageBox.Show("Nhập sai dữ liệu giá, vui lòng nhập lại!!");
                }
                if (check == false && textEdit3.Text.Trim() != "" && textEdit4.Text.Trim() != "" && textEdit5.Text.Trim() != "" && textEdit6.Text.Trim() != "" && textEdit7.Text.Trim() != "" && textEdit8.Text.Trim() != "" && textBox1.Text.Trim() != "")
                {
                    string sql = "UPDATE MonAn set TenMonAn=N'" + textEdit3.Text + "', MaCongDung=N'" + textEdit4.Text + "', MaLoai=N'" + textEdit6.Text + "', Cachlam=N'" + textBox1.Text + "', YeuCau=N'" + textEdit7.Text + ", Dongia=" + Convert.ToDecimal(textEdit8.Text) + " where MaMonAn = N'" + textEdit5.Text + "'";
                    query.CapNhatDuLieu(sql);
                    fill();

                    //MonAn.Add(new Class_MonAn(textEdit3.Text, textEdit5.Text, textEdit4.Text, textEdit6.Text, textEdit7.Text, textBox1.Text, Convert.ToDecimal(textEdit8.Text)));
                    textEdit3.Text = "";
                    textEdit4.Text = "";
                    textEdit5.Text = "";
                    textEdit7.Text = "";
                    textEdit6.Text = "";
                    textEdit8.Text = "";
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("vui lòng nhập đầy đủ thông tin");
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textEdit3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textEdit4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textEdit5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textEdit6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textEdit7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textEdit8.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void Frm_MonAn_Load(object sender, EventArgs e)
        {
            fill();
            add();
        }

    }
}