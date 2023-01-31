using Finanzauto.HuellaCarbono.App.Contracts.Persistence;
using Finanzauto.HuellaCarbono.App.Models.ViewModel.Calculate;
using Finanzauto.HuellaCarbono.Domain;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Finanzauto.HuellaCarbono.App.Features.Logic.Calculator
{
    public class Calculator
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public Calculator(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseVM> ResponseCalculators(int linea, int km)
        {
            try
            {
                var response = new List<ResponseVM>();
                var line = _unitOfWork.Repository<line>().GetAsync(x => x.linId == linea);
                double emisionGrKm = Convert.ToDouble(line.Result[0].EmisionesCO2_GrKm) 
                    , emisionTnKm = km * Convert.ToDouble(line.Result[0].huellaCarbono_TonKm);
                response[0].Emisiones_Gr_Km = emisionGrKm;
                response[0].Emisiones_Tn_Km = emisionTnKm;

                return response[0];
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string CalculateTonKm()
        {

            return$"{CalculateTonKm()}";
        }
    }
}
