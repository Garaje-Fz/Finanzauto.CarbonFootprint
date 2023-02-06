using Finanzauto.HuellaCarbono.App.Models.ViewModel.Calculate.Equivalences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.App.Models.ViewModel.Calculate
{
    public class AveragueVM
    {
        public string Clase { get; set; }
        public int Promedio_Año_Km { get; set; }
        public string años { get; set; }
        public double Emisiones_Gr_Km { get; set; }
        public double Emisiones_Tn_Km { get; set; }
        public ArbolesVM Arboles { get; set; }
        public CelularesVM Celulares { get; set; }
        public ViajesVM Viajes { get; set; }
        public ComputadoresVM Computadores { get; set; }
        public CarneVM Carne { get; set; }
    }
}
