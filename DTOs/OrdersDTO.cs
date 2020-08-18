using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class OrdersDTO
    {
        public string ID { get; set; }
        public string TransactionTypeID { get; set; }
        public string SupplierID { get; set; }
        public string SourceWarehouseID { get; set; }
        public string DestinationWarehouseID { get; set; }
        public DateTime Date { get; set; }
        public OrdersDTO() { }
        public OrdersDTO(string id, string transactionTypeID, string supplierID, string sourceWarehouseID, 
            string destinationWarehouseID, DateTime date)
        {
            this.ID = id;
            this.TransactionTypeID = transactionTypeID;
            this.SupplierID = supplierID;
            this.SourceWarehouseID = sourceWarehouseID;
            this.DestinationWarehouseID = destinationWarehouseID;
            this.Date = date;
        }
    }
}
