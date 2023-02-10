using Finanzauto.HuellaCarbono.App.Contracts.Persistence;
using Finanzauto.HuellaCarbono.Auth.Models;
using Finanzauto.HuellaCarbono.Auth.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Finanzauto.HuellaCarbono.Api.Controllers
{
    [ApiController]
    [Route("Login")]
    public class LoginController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public LoginController(IConfiguration configuration, IMediator mediator, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Token")]
        public async Task<ActionResult> Token([FromBody]User user)
        {
            Login login = new Login(_configuration, _mediator, _unitOfWork);
            var token = login.Token(user);
            if (token.Result.Item2 == null)
                return Ok(token.Result.Item1);
            return Ok(token.Result.Item2);

        }
    }
}
