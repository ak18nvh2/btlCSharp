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
    }
}
