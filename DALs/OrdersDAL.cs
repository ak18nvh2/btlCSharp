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
        public int DemSoLuongBanGhi()
        {
            cnn.Open();
            string sql = "SELECT COUNT(ID) AS 'DEM' FROM Orders";
            SqlCommand cmd = new SqlCommand(sql, cnn);
      
            SqlDataReader dr = cmd.ExecuteReader();
            int demSoLuong = 0;
            if (dr.Read())
            {
                
                demSoLuong = Convert.ToInt32( dr["DEM"]) ;

               
            }
            dr.Close();
            cnn.Close();
            return demSoLuong;
        }
        public void ThemBanGhi(OrdersDTO ordersDTO)
        {
            cnn.Open();
            string sql2 = "SET IDENTITY_INSERT [dbo].[Orders] ON ";
            SqlCommand cmd2 = new SqlCommand(sql2, cnn);
            cmd2.ExecuteNonQuery();
            string sql =
                "INSERT INTO Orders (ID, TransactionTypeID, SupplierID, DestinationWarehouseID, Date) VALUES (@id,@ttID,@sID,@dwID,@d)";
            SqlCommand cmd = new SqlCommand(sql, cnn);
           
            cmd.Parameters.AddWithValue("ttID",ordersDTO.TransactionTypeID);
            cmd.Parameters.AddWithValue("sID",ordersDTO.SupplierID);
            cmd.Parameters.AddWithValue("id", ordersDTO.ID);
            cmd.Parameters.AddWithValue("dwID",ordersDTO.DestinationWarehouseID);
            cmd.Parameters.AddWithValue("d",ordersDTO.Date);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void ThemBanGhi2(OrdersDTO ordersDTO)
        {
            cnn.Open();
            string sql2 = "SET IDENTITY_INSERT [dbo].[Orders] ON ";
            SqlCommand cmd2 = new SqlCommand(sql2, cnn);
            cmd2.ExecuteNonQuery();
            string sql =
                "INSERT INTO Orders (ID, TransactionTypeID,SourceWarehouseID, DestinationWarehouseID, Date) VALUES (@id,@ttID,@sID,@dwID,@d)";
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("ttID", ordersDTO.TransactionTypeID);
            cmd.Parameters.AddWithValue("sID", ordersDTO.SourceWarehouseID);
            cmd.Parameters.AddWithValue("id", ordersDTO.ID);
            cmd.Parameters.AddWithValue("dwID", ordersDTO.DestinationWarehouseID);
            cmd.Parameters.AddWithValue("d", ordersDTO.Date);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public List<string> TimDanhSachBatchNumberTuPartID(string partID)
        {
            List<string> ds = new List<string>();
            cnn.Open();
            string sql = " SELECT DISTINCT BatchNumber FROM OrderItems inner join Parts on OrderItems.PartID = Parts.ID WHERE PartID = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("id", Convert.ToInt32(partID));
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ds.Add(dr["BatchNumber"].ToString());
            }
            dr.Close();
            cnn.Close();
            return ds;
        }
    }
}
