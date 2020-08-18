using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using DALs;
namespace BULs
{
    public class InventoryBUL
    {
        InventoryDAL inventoryDAL = new InventoryDAL();
        public List<InventoryDTO> DocDanhSachInventory()
        {
            
            return inventoryDAL.DocDanhSachInventory();
        }
    }
}
