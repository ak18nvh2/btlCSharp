using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;
using DTOs;

namespace BULs
{
    public class SuppliersBUL
    {
        public SuppliersDAL suppliersDal = new SuppliersDAL();
        public string TimTenSupplierTheoID(string ID)
        {
            return suppliersDal.TimKiemTenSupplierTheoID(ID);
        }
        public List<SuppliersDTO> LayDanhSachSuplier()
        {
            return suppliersDal.DocBanGhiSuppliers();
        }

    }
}
