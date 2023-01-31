using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.App.Models.ViewModel.Calculate
{
    public class ResponseVM
    {
        public double Emisiones_Gr_Km { get; set; }
        public double Emisiones_Tn_Km { get; set; }
        public EquivalenceVM Equivalencia { get; set; }
    }
}
