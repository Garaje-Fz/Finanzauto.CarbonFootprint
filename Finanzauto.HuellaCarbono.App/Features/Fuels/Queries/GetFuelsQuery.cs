using Finanzauto.HuellaCarbono.App.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.App.Features.Fuels.Queries
{
    public class GetFuelsQuery : IRequest<List<FuelVM>>
    {
        public int brnId { get; set; }
        public int typId { get; set; }
        public int linYear { get; set; }
    }
}
