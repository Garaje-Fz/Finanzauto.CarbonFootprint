using Finanzauto.HuellaCarbono.App.Contracts.Persistence;
using Finanzauto.HuellaCarbono.App.Models.ViewModel.Calculate;
using Finanzauto.HuellaCarbono.Domain;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Finanzauto.HuellaCarbono.App.Features.Logic.Calculator
{
    public class Calculator
    {
        private readonly IUnitOfWork _unitOfWork;

        public Calculator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public double CalcEqui(double emisionTnKmdouble ,double equivalence)
        {
            try
            {
                double result = emisionTnKmdouble * equivalence;
                result = Math.Round(result, 0, MidpointRounding.ToEven);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calcular equivalencia" + ex);
            }
        }
    }
}
