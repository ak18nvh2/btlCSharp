using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;
using DTOs;

namespace BULs
{
    public class WarehousesBUL
    {
        public WarehousesDAL warehousesDAL = new WarehousesDAL();
        public string TimTenWareHouseTheoID(string id)
        {
            return warehousesDAL.TimKiemTenWarehouseTheoID(id);
        }
        public List<WarehousesDTO> LayDanhSachWarehouse()
        {
            return warehousesDAL.DocBanGhiWarehouses();
        }
    }
}
