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
            var lines = await _unitOfWork.Repository<line>().GetAsync(x => x.linId == request.linId);
            var fuels = await _unitOfWork.Repository<fuel>().GetAsync(x => x.fueId == lines[0].fueId);
            List<FuelVM> result = new List<FuelVM>();
            result.Add(new FuelVM()
            {
                fueId = lines[0].fueId,
                fueName = fuels[0].fueName
            });
            return _mapper.Map<List<FuelVM>>(result);
        }
    }
}
