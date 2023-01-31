using Finanzauto.HuellaCarbono.App.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.App.Features.Types.Queries
{
    public class GetTypesQuery : IRequest<List<TypeVM>>
    {
        public GetTypesQuery(int? Brand)
        {
            brnId = Brand;
        }
        public int? brnId { get; set; }
    }
}
