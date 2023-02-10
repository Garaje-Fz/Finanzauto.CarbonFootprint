using Finanzauto.HuellaCarbono.App.Contracts.Persistence;
using Finanzauto.HuellaCarbono.Auth.Models;
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
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.Auth.Services
{
    public class Login
    {
        IConfiguration _configuration;
        private readonly IMediator _meediator;
        private readonly IUnitOfWork _unitOfWork;

        public Login(IConfiguration configuration, IMediator meediator, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _meediator = meediator;
            _unitOfWork = unitOfWork;
        }

        public async Task<Tuple<Tokens, ExceptVM>> Token(User user)
        {
            try
            {
                var except = new ExceptVM();
                if ((_configuration["Jwt:Issuer"] == user.UserName) && (_configuration["Jwt:Audience"] == user.Password))
                {
                    var getToken = GenerateToken(user.UserName);
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

        public Tokens GenerateToken(string usrDomain)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var EndToken = int.Parse(_configuration["Jwt:EndToken"]);
            var claimsIdentity = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usrDomain),
                new Claim(JwtRegisteredClaimNames.Iss, issuer),
                new Claim(JwtRegisteredClaimNames.Aud, audience),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
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
