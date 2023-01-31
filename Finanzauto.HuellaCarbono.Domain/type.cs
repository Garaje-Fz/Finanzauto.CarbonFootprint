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
    public class type : Ordering
    {
        public int typId { get; set; }
        public string typName { get; set; }

        [JsonIgnore]
        public List<line> GetTypes { get; set; }

        [JsonIgnore]
        public List<brandType> GetTypeBrands { get; set; }
    }
}
