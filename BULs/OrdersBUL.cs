using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;
using DTOs;

namespace BULs
{
    public class OrdersBUL
    {
        public OrdersDAL ordersDAL = new OrdersDAL();
        public OrdersDTO TimOrderTheoID(string orderID)
        {
            return ordersDAL.TimBanGhiOrdersTheoID(orderID);
        }
        public int DemSoLuongOrder()
        {
            return ordersDAL.DemSoLuongBanGhi();
        }
        public void ThemMotOrder(OrdersDTO ordersDTO)
        {
            ordersDAL.ThemBanGhi(ordersDTO);
        }
        public void ThemMotOrder2(OrdersDTO ordersDTO)
        {
            ordersDAL.ThemBanGhi2(ordersDTO);
        }
        public List<string> DocDanhSachBatchNumberTheoPartID(string partID)
        {
            return ordersDAL.TimDanhSachBatchNumberTuPartID(partID);
        }
    }
}
