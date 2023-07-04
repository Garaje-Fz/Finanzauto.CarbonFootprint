using Finanzauto.HuellaCarbono.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.Domain
{
    public class fuel : Ordering
    {
        public int fueId { get; set; }
        public string fueName { get; set; }

        [JsonIgnore]
        public List<line> GetFuel { get; set; }

        [JsonIgnore]
        public virtual List<identity> GetIdentLogic { get; set; }
    }
}
