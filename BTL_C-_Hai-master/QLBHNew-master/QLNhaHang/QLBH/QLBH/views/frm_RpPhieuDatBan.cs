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
    public partial class frm_RpPhieuDatBan : DevExpress.XtraEditors.XtraForm
    {
        ConnectAndQuery db = new ConnectAndQuery();
        public frm_RpPhieuDatBan()
        {
            InitializeComponent();
        }

        private void frm_RpPhieuDatBan_Load(object sender, EventArgs e)
        {
            cb_Select.SelectedIndex = 0;
        }

        private void cb_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_Select.SelectedIndex == 1)
            {
                txt_MaPhieu.Enabled = false;
                txt_MaPhieu.Text = "";
            }
            if(cb_Select.SelectedIndex == 0)
            {
                txt_MaPhieu.Enabled = true;
            }
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            RpPDB rp_PDB = new RpPDB();
            if (cb_Select.SelectedIndex == 0)
            {
                if (txt_MaPhieu.Text == "")
                {
                    MessageBox.Show("Hãy nhập mã Phiếu Đặt Bàn","Thông Báo");
                }
                else
                {
                    string mapdb = txt_MaPhieu.Text;
                    dt = db.DocBang(" Select MaPhieu from PhieuDatBan where MaPhieu = '" + mapdb + "'");
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Mã Phiếu này không tồn tại. Hãy Nhập Mã khác", "Thông Báo");
                        return;
                    }
                    string sql;
                    sql = " exec RpPDB '" + mapdb + "'";
                    dt = db.DocBang(sql);
                    rp_PDB.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = rp_PDB;
                }
            }
            if(cb_Select.SelectedIndex == 1)
            {
                string sql;
                sql = " Select * from PhieuDatBan";
                dt = db.DocBang(sql);
                rp_PDB.SetDataSource(dt);
                crystalReportViewer1.ReportSource = rp_PDB;
            }
        }
    }
}