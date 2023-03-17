using AutoMapper;
using Finanzauto.HuellaCarbono.App.Contracts.Persistence;
using Finanzauto.HuellaCarbono.App.Features.Types.Queries;
using Finanzauto.HuellaCarbono.App.Models.ViewModel;
using Finanzauto.HuellaCarbono.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.App.Features.Lines.Queries
{
    public class GetLinesQueryHandler : IRequestHandler<GetLinesQuery, List<LineVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetLinesQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetLinesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<LineVM>> Handle(GetLinesQuery request, CancellationToken cancellationToken)
        {
            var lines = await _unitOfWork.Repository<line>()
                .GetAsync(x => x.brnId == request.brnId && x.typId == request.typId);
            List<LineVM> list = new List<LineVM>();
            List<LineVM> result = new List<LineVM>();
            for (int i = 0; i <= lines.Count - 1; i++)
            {
                var validation = list.Find(x => x.linDescription == lines[i].linDescription);
                if (validation == null)
                {
                    list.Add(new LineVM()
                    {
                        linId = lines[i].linId,
                        linDescription = lines[i].linDescription,
                        codigoFasecolda = lines[i].codigoFasecolda
                    });
                }
            }
            var order = from s in list
                        orderby s.linDescription
                        select s;
            foreach (var item in order)
                result.Add(item);

            return _mapper.Map<List<LineVM>>(result);
        }
    }
}
