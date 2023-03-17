using Finanzauto.HuellaCarbono.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.Domain
{
    public class line : Ordering
    {
        public int linId { get; set; }
        public string codigoFasecolda { get; set; }
        public int linYear { get; set; }

        public int brnId { get; set; }
        [ForeignKey("brnId")]
        public brand fkbrands { get; set; }

        public int typId { get; set; }
        [ForeignKey("typId")]
        public type fktypes { get; set; }

        public int fueId { get; set; }
        [ForeignKey("fueId")]
        public fuel fkfuel { get; set; }

        public string linDescription { get; set; }
        public string EmisionesCO2_GrKm { get; set; }
        public string huellaCarbono_TonKm { get; set; }

        [JsonIgnore]
        public List<record> GetRecords { get; set; }
    }
}
