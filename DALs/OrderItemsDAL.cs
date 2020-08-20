using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace DALs
{
    public class OrderItemsDAL
    {
        SqlConnection cnn = new SqlConnection(
           @"Data Source=DESKTOP-RJS8C83\SQLEXPRESS;Initial Catalog=Session4;Integrated Security=True");
        public List<OrderItemsDTO> DocBanGhiBangOrderItems()
        {
           
            List<OrderItemsDTO> dsOrderItem = new List<OrderItemsDTO>();
            cnn.Open();
            string sqlSelectOrderItems = "SELECT * FROM OrderItems";
            SqlCommand cmd = new SqlCommand(sqlSelectOrderItems, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                OrderItemsDTO orderItem = new OrderItemsDTO(dr["ID"].ToString(),
                                                            dr["OrderID"].ToString(),
                                                            dr["PartID"].ToString(),
                                                            dr["BatchNumber"].ToString() , 
                                                            Convert.ToDouble( dr["Amount"] )
                                                            );
                dsOrderItem.Add(orderItem);
            }
            dr.Close();
            cnn.Close();
            return dsOrderItem;

        }
        public void XoaOrderItem(string id)
        {
            
                cnn.Open();
                string sqlDelete = "DELETE OrderItems WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(sqlDelete, cnn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
                cnn.Close();
            
        }
        public string TimBatchNumberBangID(string id)
        {
            string batchNumber = "";
            cnn.Open();
            string sqlSelectOrderItems = "SELECT BatchNumber FROM OrderItems WHERE ID = @id";
            SqlCommand cmd = new SqlCommand(sqlSelectOrderItems, cnn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                batchNumber = dr["BatchNumber"].ToString();
            }
            dr.Close();
            cnn.Close();
            return batchNumber;
        }
        public int DemSoLuongBanGhi()
        {
            cnn.Open();
            string sql = "SELECT COUNT(ID) AS 'DEM' FROM OrderItems";
            SqlCommand cmd = new SqlCommand(sql, cnn);

            SqlDataReader dr = cmd.ExecuteReader();
            int demSoLuong = 0;
            if (dr.Read())
            {

                demSoLuong = Convert.ToInt32(dr["DEM"]);


            }
            dr.Close();
            cnn.Close();
            return demSoLuong;
        }
        public void ThemBanGhi(OrderItemsDTO orderItemsDTO)
        {
            cnn.Open();
            string sql2 = "SET IDENTITY_INSERT [dbo].[OrderItems] ON  ";
            SqlCommand cmd2 = new SqlCommand(sql2, cnn);
            cmd2.ExecuteNonQuery();
            string sql = "INSERT INTO OrderItems (ID, OrderID, PartID, BatchNumber, Amount )  VALUES (@id,@oID,@pID,@bn,@a)";
          //  string sql =
              //  "INSERT INTO OrderItems ( TransactionTypeID, SupplierID, DestinationWarehouseID, Date) VALUES (@ttID,@sID,@dwID,@d)";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            //SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(orderItemsDTO.ID));
            cmd.Parameters.AddWithValue("@oID", Convert.ToInt32(orderItemsDTO.OrderID));
            cmd.Parameters.AddWithValue("@pID", Convert.ToInt32(orderItemsDTO.PartID));
            cmd.Parameters.AddWithValue("@bn", orderItemsDTO.BatchNumber);
            cmd.Parameters.AddWithValue("@a", orderItemsDTO.Amount);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
