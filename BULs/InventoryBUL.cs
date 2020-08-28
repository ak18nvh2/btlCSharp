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
        public double TinhChenhLechTongAmountLoaiHangHoaNhapVaoKhoTheoPartNameVaWareNameVoiMinimumAmountCuaPart(string partName, string wareHouseName, string batchNumber)
        {
            return inventoryDAL.TinhChenhLechTongAmountLoaiHangHoaNhapVaoKhoVaSoMinimumAmount(partName, wareHouseName,batchNumber);
        }
        public void XoaMotDong(string orderItemID)
        {
            inventoryDAL.XoaMotDongTrongBang(orderItemID);
        }
        public double TinhChenhLechTongAmountLoaiHangHoaNhapVaoKhoTheoPartNameVaWareNameVoiMinimumAmountCuaPart(string partName, string wareHouseName)
        {
            return inventoryDAL.TinhChenhLechTongAmountLoaiHangHoaNhapVaoKhoVaSoMinimumAmount(partName, wareHouseName);
        }
        public double TinhTongAmountDuocNhapCuaPartTrongWarehouse(string wareHouseID, string partID)
        {
            return inventoryDAL.TinhTongAmountCuaPartMaKhoDaNhanTheoIDKhoVaIDPart(wareHouseID, partID);
        }
        public double TinhTongAmountCuaPartMaKhoDaNhanTheoIDKhoVaIDPart(string wareHouseId, string partID, string batchNumber)
        {
           
            return inventoryDAL.TinhTongAmountCuaPartMaKhoDaNhanTheoIDKhoVaIDPart(wareHouseId,partID,batchNumber);
        }
    }
}
