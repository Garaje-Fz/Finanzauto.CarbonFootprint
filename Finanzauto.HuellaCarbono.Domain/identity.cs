using Finanzauto.HuellaCarbono.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.Domain
{
    public class identity : Ordering
    {
        public int idnId { get; set; }
        public string idnDescription { get; set; }
        public string idnImage { get; set; }
        public double idnEquivalence { get; set; }
        public int idnOrden { get; set; }

        public int fueId { get; set; }
        [ForeignKey("fueId")]
        public fuel fkFuelIdent { get; set; }
    }
}
