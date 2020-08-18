using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class SuppliersDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public SuppliersDTO() { }
        public SuppliersDTO(string id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
