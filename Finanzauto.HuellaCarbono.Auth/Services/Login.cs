using Finanzauto.HuellaCarbono.App.Contracts.Persistence;
using Finanzauto.HuellaCarbono.Auth.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Tokens>> Token(User user)
        {
            try
            {
                var auth = ServiceLogin(user);
                return new List<Tokens>();
            }
            catch (Exception)
            {

                throw;
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
                return response.Content;
            }
            catch (Exception ex)
            {
                throw new Exception("Error respuesta Login Finanzauto.", ex);
            }
        }
    }
}
