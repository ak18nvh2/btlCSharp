using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALs
{
    public class PartsDAL
    {
        SqlConnection cnn = new SqlConnection(
            @"Data Source=DESKTOP-RJS8C83\SQLEXPRESS;Initial Catalog=Session4;Integrated Security=True");

        public string TimKiemTenPartTheoID(string ID)
        {
            cnn.Open();
            string partName = "";
            string sql = "SELECT Name FROM Parts WHERE ID=@id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("id", ID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                partName = dr["Name"].ToString();
            }
            dr.Close();
            cnn.Close();
            return partName;
        }
        public double TimKiemMinimumAmountTheoID(string ID)
        {
            cnn.Open();
            double minimumAmout = 0;
            string sql = "SELECT MinimumAmount FROM Parts WHERE ID=@id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("id", ID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                minimumAmout = Convert.ToDouble(dr["MinimumAmount"]);
            }
            dr.Close();
            cnn.Close();
            return minimumAmout;
        }
        public string TimKiemPartIDTheoTen(string name)
        {
            cnn.Open();
            string partID = "";
            string sql = "SELECT ID FROM Parts WHERE Name=@name";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("name", name);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                partID = dr["ID"].ToString();
            }
            dr.Close();
            cnn.Close();
            return partID;
        }
    }
}
