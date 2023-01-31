using Finanzauto.HuellaCarbono.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.Domain
{
    public class brandType : Ordering
    {
        public int brtId { get; set; }
        
        public int brnId { get; set; }
        [ForeignKey("brnId")]
        public brand fkbrand { get; set; }

        public int typId { get; set; }
        [ForeignKey("typId")]
        public type fktype { get; set; }
    }
}
