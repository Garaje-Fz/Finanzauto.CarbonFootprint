using Finanzauto.HuellaCarbono.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.Domain
{
    public class Identity : Ordering
    {
        public int idnId { get; set; }
        public string idnName { get; set; }
        public string idnDescription { get; set; }
        public string idnImage { get; set; }
        public double idnEquivalence { get; set; }
        public int idnOrden { get; set; }
    }
}
