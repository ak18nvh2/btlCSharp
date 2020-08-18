using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALs
{
    public class WarehousesDAL
    {
        SqlConnection cnn = new SqlConnection(
            @"Data Source=DESKTOP-RJS8C83\SQLEXPRESS;Initial Catalog=Session4;Integrated Security=True");

        public string TimKiemTenWarehouseTheoID(string ID)
        {
            cnn.Open();
            string wareHouseName = "";
            string sql = "SELECT Name FROM Warehouses WHERE ID=@id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("id", ID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                wareHouseName = dr["Name"].ToString();
            }
            dr.Close();
            cnn.Close();
            return wareHouseName;
        }
    }
}
