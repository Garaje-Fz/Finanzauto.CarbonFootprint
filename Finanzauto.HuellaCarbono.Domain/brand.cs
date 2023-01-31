using Finanzauto.HuellaCarbono.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.Domain
{
    public class brand : Ordering
    {
        public int brnId { get; set; }
        public string brnName { get; set; }

        [JsonIgnore]
        public List<line> GetBrands { get; set; }
        [JsonIgnore]
        public List<brandType> GetBrandTypes { get; set; }
    }
}
