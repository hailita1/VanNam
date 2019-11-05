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
using System.Data.SqlClient;

namespace QLBH.views
{
    public partial class frm_RpTongTien : DevExpress.XtraEditors.XtraForm
    {
        QLBH.Repository.ConnectAndQuery db = new ConnectAndQuery();
        public frm_RpTongTien()
        {
            InitializeComponent();
        }

        private void frm_RpTongTien_Load(object sender, EventArgs e)
        {
            cb_Select.SelectedIndex = 0;
            string sql, sql1;
            DataTable dt = new DataTable();
            sql1 = "   select YEAR(NgayDat) as Nam from PhieuDatBan group by  YEAR(NgayDat)";
            dt = db.DocBang(sql1);
            cb_Nam.DataSource = dt;
            cb_Nam.DisplayMember = "Nam";
            cb_Nam.ValueMember = "Nam";

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            RpThang crt = new RpThang();
            RpQuy rpq = new RpQuy();
            RpNam rpn = new RpNam();
            RpAllNam rpallnam = new RpAllNam();
            Rp_AllQuy rpallquy = new Rp_AllQuy();
            Rp_AllThang rpallthang = new Rp_AllThang();
            SqlDataAdapter dap;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-MFCIF4Q\SQLEXPRESS;Initial Catalog=TestVanDuong;Integrated Security=True");
            if (cb_Select.SelectedIndex == 0)
            {
                if (cb_Thang.SelectedIndex == -1)
                {
                    MessageBox.Show("Bạn Hãy Chọn Một Tháng", "Thông Báo");
                }
                else if(cb_Thang.SelectedIndex == 12)
                {
                    string sql = " select * from TongTienThang('"+cb_Nam.SelectedValue.ToString()+"')";
                    dap = new SqlDataAdapter(sql, conn);
                    dap.Fill(ds);
                    rpallthang.SetDataSource(ds.Tables[0]);
                    crystalReportViewer1.ReportSource = rpallthang;

                }
                else
                {
                    //Check năm đang chọn có khách hàng đặt bàn vào tháng đang chọn hay không
                    dt = db.DocBang(" select Month(NgayDat) from PhieuDatBan where month(NgayDat) = '"+cb_Thang.SelectedItem.ToString()+"' and year(NgayDat) = '"+cb_Nam.SelectedValue.ToString()+"'");
                    if(dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Năm " + cb_Nam.SelectedValue.ToString() + " không có khách hàng đặt bàn tháng " + cb_Thang.SelectedItem.ToString(), "Thông Báo");
                        return;
                    }
                    conn.Open();
                    string t = cb_Thang.SelectedItem.ToString();
                    string n = cb_Nam.SelectedValue.ToString();
                    string sql = " exec RpThang '" + t + "',  '" + n + "'";
                    dap = new SqlDataAdapter(sql, conn);
                    dap.Fill(ds);
                    crt.SetDataSource(ds.Tables[0]);
                    crystalReportViewer1.ReportSource = crt;
                    conn.Close();
                }
            }
            if (cb_Select.SelectedIndex == 1)
            {
                if(cb_Quy.SelectedIndex == -1 )
                {
                    MessageBox.Show("Hãy chọn Một Quý");
                }else
                if (cb_Quy.SelectedItem.ToString() == "IV")
                {
                    string n = cb_Nam.SelectedValue.ToString();
                    dt = db.DocBang(" exec RpQuy 'IV',10,11,12, '" + n + "'");
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Năm " + cb_Nam.SelectedValue.ToString() + " không có quý IV ", "Thông Báo");
                        return;
                    }
                    conn.Open();
                    string sql1 = " exec RpQuy 'IV',10,11,12, '"+n+"'";
                    dap = new SqlDataAdapter(sql1, conn);
                    dap.Fill(ds);
                    rpq.SetDataSource(ds.Tables[0]);
                    crystalReportViewer1.ReportSource = rpq;
                    conn.Close();
                }
                else if (cb_Quy.SelectedItem.ToString() == "III")
                {
                    conn.Open();
                    string n = cb_Nam.SelectedValue.ToString();
                    dt = db.DocBang(" exec RpQuy 'III',7,8,9, '" + n + "'");
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Năm " + cb_Nam.SelectedValue.ToString() + " không có quý III ", "Thông Báo");
                        return;
                    }
                    string sql1 = " exec RpQuy 'III',7,8,9, '" + n + "'";
                    dap = new SqlDataAdapter(sql1, conn);
                    dap.Fill(ds);
                    rpq.SetDataSource(ds.Tables[0]);
                    crystalReportViewer1.ReportSource = rpq;
                    conn.Close();
                }
                else if (cb_Quy.SelectedItem.ToString() == "II")
                {
                    conn.Open();
                    string n = cb_Nam.SelectedValue.ToString();
                    dt = db.DocBang(" exec RpQuy 'II',7,8,9, '" + n + "'");
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Năm " + cb_Nam.SelectedValue.ToString() + " không có quý II ", "Thông Báo");
                        return;
                    }
                    string sql1 = " exec RpQuy 'II',4,5,6, '" + n + "'";
                    dap = new SqlDataAdapter(sql1, conn);
                    dap.Fill(ds);
                    rpq.SetDataSource(ds.Tables[0]);
                    crystalReportViewer1.ReportSource = rpq;
                    conn.Close();
                }
                else if (cb_Quy.SelectedItem.ToString() == "I")
                {
                    conn.Open();
                    string n = cb_Nam.SelectedValue.ToString();
                    dt = db.DocBang(" exec RpQuy 'I',7,8,9, '" + n + "'");
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Năm " + cb_Nam.SelectedValue.ToString() + " không có quý I", "Thông Báo");
                        return;
                    }
                    string sql1 = " exec RpQuy 'I',1,2,3, '" + n + "'";
                    dap = new SqlDataAdapter(sql1, conn);
                    dap.Fill(ds);
                    rpq.SetDataSource(ds.Tables[0]);
                    crystalReportViewer1.ReportSource = rpq;
                    conn.Close();
                }
                else if(cb_Quy.SelectedIndex == 4)
                {
                    string sql = " select * from TongTienQuy('" + cb_Nam.SelectedValue.ToString() + "')";
                    dap = new SqlDataAdapter(sql, conn);
                    dap.Fill(ds);
                    rpallquy.SetDataSource(ds.Tables[0]);
                    crystalReportViewer1.ReportSource = rpallquy;
                }
            }
            if(cb_Select.SelectedIndex == 2)
            {
                conn.Open();
                string n = cb_Nam.SelectedValue.ToString();
                string sql = " exec RpNam '"+n+"'";
                dap = new SqlDataAdapter(sql, conn);
                dap.Fill(ds);
                rpn.SetDataSource(ds.Tables[0]);
                crystalReportViewer1.ReportSource = rpn;
                conn.Close();
            }
            if (cb_Select.SelectedIndex == 3)
            {
                string sql = " select * from TongTienNam()";
                dt = db.DocBang(sql);
                rpallnam.SetDataSource(dt);
                crystalReportViewer1.ReportSource = rpallnam;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_Select.SelectedIndex == 0)
            {
                cb_Quy.Enabled = false;
                cb_Thang.Enabled = true;
                cb_Quy.SelectedIndex = -1;
            }
            if(cb_Select.SelectedIndex == 1)
            {
                cb_Thang.SelectedIndex = -1;
                cb_Thang.Enabled = false;
                cb_Quy.Enabled = true;
            }
            if(cb_Select.SelectedIndex == 2)
            {
                cb_Nam.Enabled = true;
                cb_Thang.SelectedIndex = -1;
                cb_Quy.SelectedIndex = -1;
                cb_Thang.Enabled = false;
                cb_Quy.Enabled = false;
            }
            if(cb_Select.SelectedIndex == 3)
            {
                cb_Thang.Enabled = false;
                cb_Quy.Enabled = false;
                cb_Nam.Enabled = false;
                cb_Nam.SelectedIndex = -1;
                cb_Quy.SelectedIndex = -1;
                cb_Thang.SelectedIndex = -1;
            }
        }

        private void cb_Nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //string sql = " select Month(NgayDat) as Thang from PhieuDatBan where Year(NgayDat) = '"+ cb_Nam.SelectedValue.ToString()+"' group by Month(NgayDat)";
            //dt = db.DocBang(sql);
            //cb_Thang.DataSource = dt;
            //cb_Thang.DisplayMember = "Thang";
            //cb_Thang.ValueMember = "Thang";
        }

        private void cb_Nam_SelectedValueChanged(object sender, EventArgs e)
        {
            //string sql;
            //string t = cb_Nam.SelectedValue.ToString();
            //sql = " exec getmonth '" + t + "'";
            //DataTable dt = new DataTable();
            //dt = db.DocBang(sql);
            //cb_Thang.DataSource = dt;
            //cb_Thang.DisplayMember = "Thang";
            //cb_Thang.ValueMember = "Thang";
        }

        private void cb_Thang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}