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
using System.Data.SqlClient;
using QLBH.Repository;

namespace QLBH.views
{
    public partial class frm_RpNhapXuat : DevExpress.XtraEditors.XtraForm
    {
        ConnectAndQuery db = new ConnectAndQuery();
        string sqlcon = @"Data Source=DESKTOP-MFCIF4Q\SQLEXPRESS;Initial Catalog=TestVanDuong;Integrated Security=True";
        public frm_RpNhapXuat()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            RpNhap rpn = new RpNhap();
            RpXuat rpx = new RpXuat();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(sqlcon);
            if (rdo_Nhap.Checked == true)
            {
                string sql;
                sql = " select * from BaoCaoNhapNL";
                dt = db.DocBang(sql);
                if(dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tháng hiện tại nhà hàng chưa nhập nguyên liệu nào.", "Thông Báo");
                    return;
                }
                rpn.SetDataSource(dt);
               crystalReportViewer1.ReportSource = rpn;
            }
            if (rdo_Xuat.Checked == true)
            {
                    string sql;
                    sql = " select * from BaoCaoXuatNL";
                    dt = db.DocBang(sql);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Tháng hiện tại nhà hàng chưa xuất nguyên liệu nào.", "Thông Báo");
                        return;
                    }
                    rpx.SetDataSource(dt);
                   crystalReportViewer1.ReportSource = rpx;
            }   
        }
    }
}