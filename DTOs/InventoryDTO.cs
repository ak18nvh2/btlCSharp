using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class InventoryDTO: IComparable<InventoryDTO>
    {
        public string PartName { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public double Amount { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string OrderItemID { get; set; }
        public InventoryDTO() { }
        public InventoryDTO(string pn, string tt, DateTime td, double a, string s, string d)
        {
            this.PartName = pn;
            this.TransactionType = tt;
            this.TransactionDate = td;
            this.Amount = a;
            this.Source = s;
            this.Destination = d;
        }

        public int CompareTo(InventoryDTO other)
        {
           if(this.TransactionDate > other.TransactionDate)
            {
                return 1;
            }
           else if (this.TransactionDate == other.TransactionDate)
            {
                if (this.TransactionType != "Purchase Order")
                    return 1;
            }
            return 0;
        }
    }
}
