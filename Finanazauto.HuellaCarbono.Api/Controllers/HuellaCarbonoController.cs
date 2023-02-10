using Finanzauto.HuellaCarbono.App.Features.Brands.Queries;
using Finanzauto.HuellaCarbono.App.Features.Types.Queries;
using Finanzauto.HuellaCarbono.App.Features.Lines.Queries;
using Finanzauto.HuellaCarbono.App.Models.ViewModel;
using Finanzauto.HuellaCarbono.Infra.Persistence;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Finanzauto.HuellaCarbono.App.Features.Years.Queries;
using Finanzauto.HuellaCarbono.App.Contracts.Persistence;
using Azure;
using Finanzauto.HuellaCarbono.App.Features.Logic.Calculator;
using Finanzauto.HuellaCarbono.App.Models.ViewModel.Calculate;
using Finanzauto.HuellaCarbono.App.Features.Fuels.Queries;
using Microsoft.AspNetCore.Authorization;

namespace Finanzauto.HuellaCarbono.Api.Controllers
{
    [ApiController]
    [Route("Get")]
    [Authorize]
    public class HuellaCarbonoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly HuellaCarbonoDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public HuellaCarbonoController(IMediator mediator, HuellaCarbonoDbContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _context = context;
        }

        [HttpGet("Brands")]
        public async Task<ActionResult<List<BrandVM>>> GetBrands()
        {
            var query = await _mediator.Send(new GetBrandsQuery());
            return Ok(query);
        }

        [HttpGet("Types")]
        public async Task<ActionResult<List<TypeVM>>> GetTypes(int? brnId)
        {
            var query = await _mediator.Send(new GetTypesQuery(brnId));
            return Ok(query);
        }

        [HttpPost("Year")]
        public async Task<ActionResult<List<YearVM>>> GetYears([FromBody]GetYearsQuery command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("Lines")]
        public async Task<ActionResult<List<LineVM>>> GetLines([FromBody]GetLinesQuery command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("Fuels")]
        public async Task<ActionResult<List<FuelVM>>> GetFuels([FromBody]GetFuelsQuery command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("Info")]
        public async Task<ActionResult<Tuple<ResponseVM, ResponseVM>>> GetInfo([FromBody]GetInfoCalculate command)
        {
            var response = await _mediator.Send(command);
            if (command.Kilometraje > 0)
                return Ok(response.Item1);
            return Ok(response.Item2);
        }
    }
}
