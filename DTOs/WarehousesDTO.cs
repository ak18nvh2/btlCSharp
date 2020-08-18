using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class WarehousesDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public WarehousesDTO() { }
        public WarehousesDTO(string id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
