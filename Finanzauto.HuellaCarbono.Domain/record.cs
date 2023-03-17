using Finanzauto.HuellaCarbono.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.Domain
{
    public class record : Ordering
    {
        public int recId { get; set; }

        public int linId { get; set; }
        [ForeignKey("linId")]
        public line Line { get; set; }

        public int recKm { get; set; }
        public double recEmisionGrKm { get; set; }
        public double recEmisionTnKm { get; set; }
        public double recCalculateTnKm { get; set; }
        public DateTime recCreateDate { get; set; }
    }
}
