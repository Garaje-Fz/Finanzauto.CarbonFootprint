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

        public Login(IMediator meediator, IUnitOfWork unitOfWork)
        {
            _meediator = meediator;
            _unitOfWork = unitOfWork;
        }

        public async Task<Tuple<Tokens, ExceptVM>> Token(User user)
        {
            var token = new Tokens();
            var except = new ExceptVM();

            var auth = ServiceLogin(user);
            if (auth == "0")
            {
                var getToken = GenerateToken();
            }
            return new Tuple<Tokens, ExceptVM>(token, except);
        }

        public string GenerateToken(string usrDomain)
        {
            try
            {
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));

                var claimsIdentity = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, usrDomain),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var tokenDescriptor = new SecurityTokenDescriptor();
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);

                return jwtToken;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Crear/Generar el token.", ex);
            }
        }

        public string ServiceLogin(User user)
        {
            try
            {
                string api = _configuration["Apis:Finanzauto"];
                var client = new RestClient(api);
                RestRequest request = new RestRequest("", Method.Post);
                String body = @"{
                " + "\n" + @"  ""User"": ""@username"",
                " + "\n" + @"  ""Passwd"": ""@password"",
                " + "\n" + @"  ""IdAplicativo"": 3,
                " + "\n" + @"  ""Firma"": ""KdNESJeIadQ+U+Q5Qs+8BQ==""
                " + "\n" +
                @"}";
                body = body.Replace("@username", user.UserName);
                body = body.Replace("@password", user.Password);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                dynamic data = JsonConvert.DeserializeObject(response.Content);
                return data.Mensaje.CodigoMensaje.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error respuesta Login Finanzauto.", ex);
            }
        }
    }
}
