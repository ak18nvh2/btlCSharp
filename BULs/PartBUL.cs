using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;
using DTOs;

namespace BULs
{
    public class PartBUL
    {
        public PartsDAL partsDAL = new PartsDAL();
        public List<PartsDTO> DocDanhSachPart()
        {
            return partsDAL.DocBanGhiPart();
        }
        public int TimBatchNumberHasRequiredBangID(string id)
        {
            return partsDAL.TimBatchNumberRequireBangID(id);
        }
        public string TimPartIDTheoTen(string partName)
        {
            return partsDAL.TimKiemPartIDTheoTen(partName);
        }
        public List<string> TimDanhSachPartIDTheoWarehouseID(string wareHouseID)
        {
            return partsDAL.TimDanhSachPartIDTungDuaHangDenKhoTheoIDKho(wareHouseID);
        }
        public string TimKiemTenTheoPartID(string ID)
        {
            return partsDAL.TimKiemTenPartTheoID(ID);
        }
        public double TimKiemMinimumAmountTheoID(string id)
        {
            return partsDAL.TimKiemMinimumAmountTheoID(id);
        }
        public List<string> TimDanhSachPartIDTungDuaHangDenKhoTheoIDKho(string wareHouseID)// tìm danh sách id part từng đưa hàng đến kho
        {
        
            return partsDAL.TimDanhSachPartIDTungDuaHangDenKhoTheoIDKho(wareHouseID);
        }
    }
}
