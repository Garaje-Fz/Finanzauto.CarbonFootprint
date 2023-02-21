using Finanzauto.HuellaCarbono.App.Models.ViewModel;
using Finanzauto.HuellaCarbono.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.App.Features.Lines.Queries
{
    public class GetLinesQuery : IRequest<List<LineVM>>
    {
        public int brnId { get; set; }
        public int typId { get; set; }
    }
}
