using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class TransactionTypesDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public TransactionTypesDTO() { }
        public TransactionTypesDTO(string id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
