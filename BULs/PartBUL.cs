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
    }
}
