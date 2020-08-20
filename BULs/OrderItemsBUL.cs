using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;
using DTOs;

namespace BULs
{
    public class OrderItemsBUL
    {
        public OrderItemsDAL orderItemDAL = new OrderItemsDAL();
        public List<OrderItemsDTO> DocDanhSachOrderItems()
        {
            return orderItemDAL.DocBanGhiBangOrderItems();
        }
        public string TimBatchNumberBangID(string id)
        {
            return orderItemDAL.TimBatchNumberBangID(id);
        }
        public int DemSoLuongOrderItem()
        {
            return orderItemDAL.DemSoLuongBanGhi();
        }
        public void ThemMotOrderItem(OrderItemsDTO ordersDTO)
        {
            orderItemDAL.ThemBanGhi(ordersDTO);
        }
    }
}
