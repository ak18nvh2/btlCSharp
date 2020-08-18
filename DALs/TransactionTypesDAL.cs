using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALs
{
    public class TransactionTypesDAL
    {
        SqlConnection cnn = new SqlConnection(
            @"Data Source=DESKTOP-RJS8C83\SQLEXPRESS;Initial Catalog=Session4;Integrated Security=True");

        public string TimKiemTenTransactionTypeTheoID(string ID)
        {
            cnn.Open();
            string transactionTypesName = "";
            string sql = "SELECT Name FROM TransactionTypes WHERE ID=@id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("id", ID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                transactionTypesName = dr["Name"].ToString();
            }
            dr.Close();
            cnn.Close();
            return transactionTypesName;
        }
    }
}
