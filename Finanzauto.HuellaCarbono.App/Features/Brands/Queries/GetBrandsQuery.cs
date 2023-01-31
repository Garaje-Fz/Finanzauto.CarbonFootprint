using Finanzauto.HuellaCarbono.App;
using Finanzauto.HuellaCarbono.App.Models.ViewModel;
using MediatR;

namespace Finanzauto.HuellaCarbono.App.Features.Brands.Queries
{
    public class GetBrandsQuery : IRequest<List<BrandVM>>
    {

    }
}
