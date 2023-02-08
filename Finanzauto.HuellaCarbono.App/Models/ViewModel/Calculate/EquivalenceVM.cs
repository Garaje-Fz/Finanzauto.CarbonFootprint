using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.App.Models.ViewModel.Calculate
{
    public class EquivalenceVM
    {
        [JsonIgnore]
        public int Order { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Calculate { get; set; }
    }
}
