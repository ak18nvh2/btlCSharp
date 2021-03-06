﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
namespace DALs
{
    public class InventoryDAL
    {
        private OrderItemsDAL orderItems = new OrderItemsDAL();
        private SuppliersDAL suppliersDAL = new SuppliersDAL();
        private WarehousesDAL warehousesDAL = new WarehousesDAL();
        private TransactionTypesDAL transactionTypesDAL = new TransactionTypesDAL();
        private OrdersDAL ordersDAL = new OrdersDAL();
        private PartsDAL partsDAL = new PartsDAL();
        SqlConnection cnn = new SqlConnection(
           @"Data Source=DESKTOP-RJS8C83\SQLEXPRESS;Initial Catalog=Session4;Integrated Security=True");

        public List<InventoryDTO> DocDanhSachInventory()
        {
            List<InventoryDTO> dsInventory = new List<InventoryDTO>();

            List<OrderItemsDTO> dsOrderItem = orderItems.DocBanGhiBangOrderItems();
            for (int i = 0; i < dsOrderItem.Count; i++)
            {
                InventoryDTO inventoryDTO = new InventoryDTO();
                inventoryDTO.Amount = dsOrderItem[i].Amount;
                inventoryDTO.PartName = partsDAL.TimKiemTenPartTheoID(dsOrderItem[i].PartID);
                OrdersDTO ordersDTO = ordersDAL.TimBanGhiOrdersTheoID(dsOrderItem[i].OrderID);
                inventoryDTO.TransactionType =
                    transactionTypesDAL.TimKiemTenTransactionTypeTheoID(ordersDTO.TransactionTypeID);
                inventoryDTO.TransactionDate = ordersDTO.Date;
                if(ordersDTO.TransactionTypeID == "1")
                {
                    inventoryDTO.Source = suppliersDAL.TimKiemTenSupplierTheoID(ordersDTO.SupplierID);
                } else
                {
                    inventoryDTO.Source = warehousesDAL.TimKiemTenWarehouseTheoID(ordersDTO.SourceWarehouseID);
                }
                inventoryDTO.Destination = warehousesDAL.TimKiemTenWarehouseTheoID(ordersDTO.DestinationWarehouseID);
                inventoryDTO.OrderItemID = dsOrderItem[i].ID;
                dsInventory.Add(inventoryDTO);
            }

            return dsInventory;
        }
        public double TinhChenhLechTongAmountLoaiHangHoaNhapVaoKhoVaSoMinimumAmount(string partName, string wareHouseName,string batchNumber)
        {
            // hàm này dùng để tính tổng số lượng đang có - amount - của 1 part bất kì ở 1 kho bất kì có batchNumber bất kì
            cnn.Open();
            double sumAmount = 0;
            string partID = partsDAL.TimKiemPartIDTheoTen(partName);
            string wareHouseID = warehousesDAL.TimKiemIDWareHouseTheoTen(wareHouseName);
            string sql =
           "SELECT * FROM Orders inner join OrderItems ON Orders.ID = OrderItems.OrderID WHERE DestinationWarehouseID = @desID and PartID = @partID and BatchNumber = @batchNumber ";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("desID", wareHouseID);
            cmd.Parameters.AddWithValue("partID", partID);
            cmd.Parameters.AddWithValue("batchNumber", batchNumber);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sumAmount += Convert.ToDouble(dr["Amount"]);
            }
            dr.Close();
            string sql2 =
             "SELECT * FROM Orders inner join OrderItems ON Orders.ID = OrderItems.OrderID WHERE SourceWarehouseID = @sID and PartID = @partID and BatchNumber = @batchNumber ";
            SqlCommand cmd2 = new SqlCommand(sql2, cnn);
            cmd2.Parameters.AddWithValue("sID", wareHouseID);
            cmd2.Parameters.AddWithValue("partID", partID);
            cmd2.Parameters.AddWithValue("batchNumber", batchNumber);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                sumAmount -= Convert.ToDouble(dr2["Amount"]);
            }
            dr2.Close();
            cnn.Close();
            double miniAmount = partsDAL.TimKiemMinimumAmountTheoID(partID);
            return sumAmount-miniAmount;
        }
        public double TinhChenhLechTongAmountLoaiHangHoaNhapVaoKhoVaSoMinimumAmount(string partName, string wareHouseName)
        {
            // hàm này dùng để tính tổng số lượng đang có - amount - của 1 part bất kì ở 1 kho bất kì có batchNumber bất kì
            cnn.Open();
            double sumAmount = 0;
            string partID = partsDAL.TimKiemPartIDTheoTen(partName);
            string wareHouseID = warehousesDAL.TimKiemIDWareHouseTheoTen(wareHouseName);
            string sql =
           "SELECT * FROM Orders inner join OrderItems ON Orders.ID = OrderItems.OrderID WHERE DestinationWarehouseID = @desID and PartID = @partID";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("desID", wareHouseID);
            cmd.Parameters.AddWithValue("partID", partID);
           
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sumAmount += Convert.ToDouble(dr["Amount"]);
            }
            dr.Close();
            string sql2 =
             "SELECT * FROM Orders inner join OrderItems ON Orders.ID = OrderItems.OrderID WHERE SourceWarehouseID = @sID and PartID = @partID";
            SqlCommand cmd2 = new SqlCommand(sql2, cnn);
            cmd2.Parameters.AddWithValue("sID", wareHouseID);
            cmd2.Parameters.AddWithValue("partID", partID);
            
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                sumAmount -= Convert.ToDouble(dr2["Amount"]);
            }
            dr2.Close();
            cnn.Close();
            double miniAmount = partsDAL.TimKiemMinimumAmountTheoID(partID);
            return sumAmount - miniAmount;
        }
        public void XoaMotDongTrongBang(string orderID)
        {
            orderItems.XoaOrderItem(orderID);
        }
        public double TinhTongAmountCuaPartMaKhoDaNhanTheoIDKhoVaIDPart(string wareHouseId, string partID)
        {
            cnn.Open();
            string sql = "SELECT Amount FROM Orders inner join OrderItems ON Orders.ID = OrderItems.OrderID WHERE DestinationWarehouseID = @wareHouseID and PartID = @partID ";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("wareHouseID", wareHouseId);
            cmd.Parameters.AddWithValue("partID", partID);
            SqlDataReader dr = cmd.ExecuteReader();
            double sumAmount = 0;
            while (dr.Read())
            {
                sumAmount += Convert.ToDouble(dr["Amount"]);
            }
            dr.Close();
            cnn.Close();
            return sumAmount;
        }
        public double TinhTongAmountCuaPartMaKhoDaNhanTheoIDKhoVaIDPart(string wareHouseId, string partID, string batchNumber)
        {
            cnn.Open();
            string sql = "SELECT Amount FROM Orders inner join OrderItems ON Orders.ID = OrderItems.OrderID WHERE DestinationWarehouseID = @did and PartID = @pid and BatchNumber = @bn ";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("did", wareHouseId);
            cmd.Parameters.AddWithValue("pid", partID);
            cmd.Parameters.AddWithValue("bn", batchNumber);
            SqlDataReader dr = cmd.ExecuteReader();
            double sumAmount = 0;
            while (dr.Read())
            {
                 sumAmount += Convert.ToDouble(dr["Amount"]);
               
            }
            dr.Close();
            cnn.Close();
            return sumAmount;
        }

    }
}
