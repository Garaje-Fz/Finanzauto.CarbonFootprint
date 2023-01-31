using AutoMapper;
using Finanzauto.HuellaCarbono.App.Contracts.Persistence;
using Finanzauto.HuellaCarbono.App.Features.Lines.Queries;
using Finanzauto.HuellaCarbono.App.Models.ViewModel;
using Finanzauto.HuellaCarbono.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.App.Features.Years.Queries
{
    public class GetYearsQueryHandler : IRequestHandler<GetYearsQuery, List<YearVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetYearsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetYearsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<YearVM>> Handle(GetYearsQuery request, CancellationToken cancellationToken)
        {
            var lines = await _unitOfWork.Repository<line>().GetAsync(x => x.brnId == request.brnId && x.typId == request.typId);
            List<YearVM> result = new List<YearVM>();
            for (int i = 0; i <= lines.Count - 1; i++)
            {
                var year = result.Find(x => x.linYear == lines[i].linYear);
                if (year == null)
                {
                    result.Add(new YearVM()
                    {
                        linYear = lines[i].linYear
                    });
                }
            }
            return _mapper.Map<List<YearVM>>(result);
        }
    }
}
