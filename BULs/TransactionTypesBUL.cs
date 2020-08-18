using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;

namespace BULs
{
    public class TransactionTypesBUL
    {
        public TransactionTypesDAL transactionTypesDAL = new TransactionTypesDAL();
        public string TimTenTransactionTypeTheoID(string id)
        {
            return transactionTypesDAL.TimKiemTenTransactionTypeTheoID(id);
        }
    }
}
