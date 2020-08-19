using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
namespace DALs
{
    public class OrdersDAL
    {
        SqlConnection cnn = new SqlConnection(
           @"Data Source=DESKTOP-RJS8C83\SQLEXPRESS;Initial Catalog=Session4;Integrated Security=True");
        public OrdersDTO TimBanGhiOrdersTheoID(string orderID)
        {
            cnn.Open();
            string sql = "SELECT * FROM Orders WHERE ID = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("id", orderID);
            SqlDataReader dr = cmd.ExecuteReader();
            OrdersDTO orderDTO = new OrdersDTO();
            if (dr.Read())
            {
                orderDTO.ID = orderID;
                orderDTO.TransactionTypeID = dr["TransactionTypeID"].ToString();
                orderDTO.SupplierID = dr["SupplierID"].ToString();
                orderDTO.SourceWarehouseID = dr["SourceWarehouseID"].ToString();
                orderDTO.DestinationWarehouseID = dr["DestinationWarehouseID"].ToString();
                orderDTO.Date = (DateTime)dr["Date"];
            }
            dr.Close();
            cnn.Close();
            return orderDTO;
        }
    }
}
