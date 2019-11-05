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

namespace QLBH.views
{
    public partial class frm_RpMonAn : DevExpress.XtraEditors.XtraForm
    {
        ConnectAndQuery db = new ConnectAndQuery();
        public frm_RpMonAn()
        {
            InitializeComponent();
        }

        private void frm_RpMonAn_Load(object sender, EventArgs e)
        {
            cb_Select.SelectedIndex = 0;
        }

        private void cb_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Select.SelectedIndex == 1)
            {
                txt_MaMonAn.Enabled = false;
                txt_MaMonAn.Text = "";
            }
            if (cb_Select.SelectedIndex == 0)
            {
                txt_MaMonAn.Enabled = true;
            }
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            RpMonAn rp_MonAn = new RpMonAn();
            if (cb_Select.SelectedIndex == 0)
            {
                if (txt_MaMonAn.Text == "")
                {
                    MessageBox.Show("Hãy nhập mã Món Ăn", "Thông Báo");
                }
                else
                {
                    string mama = txt_MaMonAn.Text;
                    dt = db.DocBang(" Select MaMonAn from MonAn where MaMonAn = '" + mama + "'");
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Mã Món Ăn này không tồn tại. Hãy Nhập Mã khác", "Thông Báo");
                        return;
                    }
                    string sql;
                    sql = " exec RpMonAn '" + mama + "'";
                    dt = db.DocBang(sql);
                    rp_MonAn.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = rp_MonAn;
                }
            }
            if (cb_Select.SelectedIndex == 1)
            {
                string sql;
                sql = " Select * from MonAn";
                dt = db.DocBang(sql);
                rp_MonAn.SetDataSource(dt);
                crystalReportViewer1.ReportSource = rp_MonAn;
            }
        }
    }
}