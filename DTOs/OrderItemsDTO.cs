using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class OrderItemsDTO
    {
        public string ID { get; set; }
        public string OrderID { get; set; }
        public string PartID { get; set; }
        public string BatchNumber { get; set; }
        public double Amount { get; set; }
        public OrderItemsDTO() { }
        public OrderItemsDTO(string id, string orderID, string partID, string batchNumber, double amount)
        {
            this.ID = id;
            this.OrderID = orderID;
            this.PartID = partID;
            this.BatchNumber = batchNumber;
            this.Amount = amount;
        }
    }
}
