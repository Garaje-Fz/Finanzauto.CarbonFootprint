using AutoMapper;
using Finanzauto.HuellaCarbono.App.Contracts.Persistence;
using Finanzauto.HuellaCarbono.App.Features.Brands.Queries;
using Finanzauto.HuellaCarbono.App.Models.ViewModel;
using Finanzauto.HuellaCarbono.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.App.Features.Types.Queries
{
    public class GetTypesQueryHandler : IRequestHandler<GetTypesQuery, List<TypeVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetTypesQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TypeVM>> Handle(GetTypesQuery request, CancellationToken cancellationToken)
        {
            var typebrand = await _unitOfWork.Repository<brandType>().GetAsync(x => x.brnId == request.brnId);
            List<TypeVM> result = new List<TypeVM>();
            for (int i = 0; i <= typebrand.Count - 1; i++)
            {
                var response = await _unitOfWork.Repository<type>().GetAsync(x => x.typId == typebrand[i].typId);
                result.Add(new TypeVM()
                {
                    typId = response[0].typId,
                    typName = response[0].typName
                });
            }
            return _mapper.Map<List<TypeVM>>(result);
        }
    }
}
