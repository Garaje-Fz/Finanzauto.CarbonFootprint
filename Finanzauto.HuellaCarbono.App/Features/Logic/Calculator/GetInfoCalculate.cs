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
    public class GetInfoCalculate : IRequest<Tuple<List<ResponseVM>, List<AveragueVM>>>
    {
        public int Id_Line { get; set; }
        public int Kilometraje { get; set; }
    }
}
