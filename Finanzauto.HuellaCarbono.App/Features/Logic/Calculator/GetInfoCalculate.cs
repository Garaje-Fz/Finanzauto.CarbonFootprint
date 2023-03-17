using Finanzauto.HuellaCarbono.App.Models.ViewModel;
using Finanzauto.HuellaCarbono.App.Models.ViewModel.Calculate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.App.Features.Logic.Calculator
{
    public class GetInfoCalculate : IRequest<Tuple<List<ResponseVM>, ExceptionVM>>
    {
        public string Codigo_Fasecolda { get; set; }
        public int Anio { get; set; }
        public int Kilometraje { get; set; }
    }
}
