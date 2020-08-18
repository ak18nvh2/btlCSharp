using System;
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
                dsInventory.Add(inventoryDTO);
            }

            return dsInventory;
        }
    }
}
