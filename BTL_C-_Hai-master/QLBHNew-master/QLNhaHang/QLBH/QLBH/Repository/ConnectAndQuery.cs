using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Repository
{
    public class ConnectAndQuery
    {
        string con = @"Data Source=DESKTOP-MFCIF4Q\SQLEXPRESS;Initial Catalog=TestVanDuong;Integrated Security=True";
        SqlConnection sqlConection = null;

        public SqlConnection SqlConection { get => sqlConection; set => sqlConection = value; }

        public ConnectAndQuery()
        {
        }

        private void ketnoiSQL()
        {
            SqlConection = new SqlConnection(con);
            if (SqlConection.State != ConnectionState.Open)
            {
                SqlConection.Open();
            }
        }

        private void DongketnoiSQL()
        {
            if (SqlConection.State != ConnectionState.Closed)
            {
                SqlConection.Close();
            }
            SqlConection.Dispose();
        }

        public DataTable DocBang(String sql)
        {
            DataTable dtBang = new DataTable();
            ketnoiSQL();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, con);
            sqlDataAdapter.Fill(dtBang);
            DongketnoiSQL();
            return dtBang;
        }

        public void CapNhatDuLieu(String sql)
        {
            ketnoiSQL();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = SqlConection;
            sqlCommand.CommandText = sql;
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            DongketnoiSQL();
        }
    }


}
