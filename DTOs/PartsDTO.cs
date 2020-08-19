using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PartsDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string EffectiveLife { get; set; }
        public int BatchNumberHasRequired { get; set; }
        public int MinimumAmount { get; set; }
        public PartsDTO() { }
        public PartsDTO(string id, string name, string effectiveLife, int batchNumberHasRequired, int minimumAmount)
        {
            this.ID = id;
            this.Name = name;
            this.EffectiveLife = effectiveLife;
            this.BatchNumberHasRequired = batchNumberHasRequired;
            this.MinimumAmount = minimumAmount;
        }
    }
}
