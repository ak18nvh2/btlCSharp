using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

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
        public string TimKiemIDWareHouseTheoTen(string name)
        {
            
            cnn.Open();
            string sql = "SELECT ID FROM Warehouses WHERE Name=@name";
            string wareHouseID = "";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("name", name);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                wareHouseID = dr["ID"].ToString();
            }
            dr.Close();
            cnn.Close();
            return wareHouseID;
        }
        public List<WarehousesDTO> DocBanGhiWarehouses()
        {
            cnn.Open();
            List<WarehousesDTO> ds = new List<WarehousesDTO>();
            string sql = "SELECT * FROM Warehouses";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                WarehousesDTO warehousesDTO = new WarehousesDTO(dr["ID"].ToString(), dr["Name"].ToString());
                ds.Add(warehousesDTO);
            }
            dr.Close();
            cnn.Close();
            return ds;
        }
    }
}
