using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.App.Models.ViewModel.Calculate
{
    public class EquivalenceVM
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Image { get; set; }
        public double Calculo { get; set; }
        public double Equivalencia { get; set; }
        public int Orden { get; set; }
    }
}
