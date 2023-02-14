using Finanzauto.HuellaCarbono.App.Contracts.Persistence;
using Finanzauto.HuellaCarbono.Auth.Models;
using Finanzauto.HuellaCarbono.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.Auth.Services
{
    public class Login
    {
        IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public Login(IConfiguration configuration, IMediator mediator, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        public async Task<Tuple<Tokens, ExceptVM>> Token(User request)
        {
            try
            {
                var user = await _unitOfWork.Repository<Domain.user>().GetFirstOrDefaultAsync(x => x.usrUserName == request.UserName);
                var except = new ExceptVM();
                if (user.usrPassword == request.Password)
                {
                    var getToken = GenerateToken(request.UserName, request.Password);
                    if (getToken != null)
                    {
                        return new Tuple<Tokens, ExceptVM>(getToken, null);
                    }
                    except = new ExceptVM()
                    {
                        result = "Error de generacion del token.",
                        except = "null",
                    };
                    return new Tuple<Tokens, ExceptVM>(null, except);
                }
                except = new ExceptVM()
                {
                    result = "Error de autenticacion.",
                    except = "null",
                };
                return new Tuple<Tokens, ExceptVM>(null, except);
            }
            catch (Exception ex)
            {
                var except = new ExceptVM()
                {
                    result = "Error consumo Token",
                    except = $"Excepcion no controlada {ex}"
                };
                return new Tuple<Tokens, ExceptVM>(null, except);
            }
        }

        public Tokens GenerateToken(string usrDomain, string pass)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var EndToken = int.Parse(_configuration["Jwt:EndToken"]);
            var claimsIdentity = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usrDomain),
                new Claim(JwtRegisteredClaimNames.Aud, pass),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claimsIdentity),
                Expires = DateTime.UtcNow.AddHours(EndToken),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            var response = new Tokens()
            {
                usrDomainName = usrDomain,
                tknId = token.Id,
                token = jwtToken,
            };
            return response;
        }
    }
}
