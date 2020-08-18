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
    }
}
