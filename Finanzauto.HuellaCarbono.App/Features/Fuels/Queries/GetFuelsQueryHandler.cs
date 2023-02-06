using AutoMapper;
using Finanzauto.HuellaCarbono.App.Contracts.Persistence;
using Finanzauto.HuellaCarbono.App.Features.Years.Queries;
using Finanzauto.HuellaCarbono.App.Models.ViewModel;
using Finanzauto.HuellaCarbono.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.App.Features.Fuels.Queries
{
    public class GetFuelsQueryHandler : IRequestHandler<GetFuelsQuery, List<FuelVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetFuelsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetFuelsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<FuelVM>> Handle(GetFuelsQuery request, CancellationToken cancellationToken)
        {
            var lines = await _unitOfWork.Repository<line>()
                .GetAsync(x => x.brnId == request.brnId && x.typId == request.typId && x.linYear == request.linYear);
            List<FuelVM> result = new List<FuelVM>();
            for (int i = 0; i < lines.Count - 1; i++)
            {
                var fuels = await _unitOfWork.Repository<fuel>().GetAsync(x => x.fueId == lines[i].fueId);
                var year = result.Find(x => x.fueId == lines[i].fueId);
                if (year == null)
                {
                    result.Add(new FuelVM()
                    {
                        fueId= lines[i].fueId,
                        fueName = fuels[0].fueName
                    });
                }
            }
            return _mapper.Map<List<FuelVM>>(result);
        }
    }
}
