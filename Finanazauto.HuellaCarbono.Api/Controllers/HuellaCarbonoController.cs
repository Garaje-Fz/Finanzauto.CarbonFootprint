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

namespace Finanzauto.HuellaCarbono.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpPost("Info")]
        public async Task<ActionResult<List<ResponseVM>>> GetInfo([FromBody]GetInfoCalculate request)
        {
            Calculator info = new Calculator(_mediator, _unitOfWork);
            var calculate = info.ResponseCalculators(request.Id_Line, request.Kilometraje);
            return Ok(calculate);
        }
    }
}
