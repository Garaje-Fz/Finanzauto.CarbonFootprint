using AutoMapper;
using Finanzauto.HuellaCarbono.App.Contracts.Persistence;
using Finanzauto.HuellaCarbono.App.Models.ViewModel;
using Finanzauto.HuellaCarbono.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.App.Features.Brands.Queries
{
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, List<BrandVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetBrandsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetBrandsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<BrandVM>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            var listBrands = await _unitOfWork.Repository<brand>().GetAllAsync();
            return _mapper.Map<List<BrandVM>>(listBrands);
        }
    }
}
