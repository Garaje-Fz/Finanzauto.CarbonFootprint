using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.App.Models.ViewModel.Calculate
{
    public class ResponseVM
    {
        public double EmissionsGr_Km { get; set; }
        public double EmissionsTn_Km { get; set; }
        public EquivalenceVM[] equivalence { get; set; }
    }
}
