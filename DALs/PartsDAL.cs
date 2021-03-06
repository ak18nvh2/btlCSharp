﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

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
        public List<PartsDTO> DocBanGhiPart()
        {
            cnn.Open();
            List<PartsDTO> ds = new List<PartsDTO>();
            string sql = "SELECT * FROM Parts";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                
                PartsDTO partsDTO = new PartsDTO(dr["ID"].ToString(),
                                                 dr["Name"].ToString(),
                                                 dr["EffectiveLife"].ToString(),
                                                 Convert.ToInt32(dr["BatchNumberHasRequired"]),
                                                 Convert.ToInt32(dr["MinimumAmount"])
                    ) ;
                ds.Add(partsDTO);
            }
            dr.Close();
            cnn.Close();
            return ds;
        }
        public int TimBatchNumberRequireBangID(string id)
        {
            int i = 0;
            cnn.Open();
            string sql = "SELECT BatchNumberHasRequired FROM Parts WHERE ID = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                i = Convert.ToInt32(dr["BatchNumberHasRequired"]);
            }
            dr.Close();
            cnn.Close();
            return i;
        }
        public List<string> TimDanhSachPartIDTungDuaHangDenKhoTheoIDKho(string wareHouseID)// tìm danh sách id part từng đưa hàng đến kho
        {
            cnn.Open();
            string sql = "SELECT DISTINCT OrderItems.PartID FROM OrderItems inner join Orders on OrderItems.OrderID = Orders.ID WHERE DestinationWarehouseID = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("id", wareHouseID);
            SqlDataReader dr = cmd.ExecuteReader();

            List<string> dsPartID = new List<string>();
            while (dr.Read())
            {
                dsPartID.Add(dr["PartID"].ToString());
            }
            dr.Close();
            cnn.Close();
            return dsPartID;
        }
    }
}
