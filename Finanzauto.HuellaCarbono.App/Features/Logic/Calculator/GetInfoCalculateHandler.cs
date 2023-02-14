using AutoMapper;
using Finanzauto.HuellaCarbono.App.Contracts.Persistence;
using Finanzauto.HuellaCarbono.App.Features.Lines.Queries;
using Finanzauto.HuellaCarbono.App.Models.ViewModel;
using Finanzauto.HuellaCarbono.App.Models.ViewModel.Calculate;
using Finanzauto.HuellaCarbono.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.App.Features.Logic.Calculator
{
    public class GetInfoCalculateHandler : IRequestHandler<GetInfoCalculate, Tuple<List<ResponseVM>, List<ResponseVM>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetInfoCalculateHandler> _logger;
        private readonly IMapper _mapper;

        public GetInfoCalculateHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Tuple<List<ResponseVM>, List<ResponseVM>>> Handle(GetInfoCalculate request, CancellationToken cancellationToken)
        {
            try
            {
                Calculator calculator = new Calculator(_unitOfWork);
                var responseVM = new List<ResponseVM>();
                double calc;
                var line = await _unitOfWork.Repository<line>().GetAsync(x => x.linId == request.Id_Line);
                var ident = await _unitOfWork.Repository<identity>().GetAllAsync();
                var averages = await _unitOfWork.Repository<type>().GetAsync(x => x.typId == line[0].typId);
                EquivalenceVM[] equivalences = new EquivalenceVM[ident.Count];

                if (request.Kilometraje > 0)
                {
                    double emisionesGrKm = Math.Round(request.Kilometraje * Convert.ToDouble(line[0].EmisionesCO2_GrKm), 3, MidpointRounding.ToEven);
                    double emisionesTnKm = Math.Round(request.Kilometraje * Convert.ToDouble(line[0].huellaCarbono_TonKm), 3, MidpointRounding.ToEven);
                    for (int i = 0; i < ident.Count; i++)
                    {
                        calc = Math.Round(request.Kilometraje * Convert.ToDouble(line[0].huellaCarbono_TonKm) * ident[i].idnEquivalence, 3, MidpointRounding.ToEven);
                        equivalences[i] = new EquivalenceVM()
                        {
                            Order = ident[i].idnOrden,
                            Calculate = calc,
                            Description = ident[i].idnDescription,
                            Image = ident[i].idnImage
                        };
                    }
                    var order = equivalences.OrderBy(x => x.Order).ToArray();
                    responseVM.Add(new ResponseVM()
                    {
                        EmissionsGr_Km = emisionesGrKm,
                        EmissionsTn_Km = emisionesTnKm,
                        equivalence = order
                    });
                }
                else
                {
                    var anio = Convert.ToInt32(DateTime.Today.Year.ToString("D")) - line[0].linYear;
                    double emisionesGrKm = Math.Round(anio * averages[0].averague * Convert.ToDouble(line[0].EmisionesCO2_GrKm), 3, MidpointRounding.ToEven);
                    double emisionesTnKm = Math.Round(anio * averages[0].averague * Convert.ToDouble(line[0].huellaCarbono_TonKm), 3, MidpointRounding.ToEven);
                    for (int i = 0; i < ident.Count; i++)
                    {
                        calc = Math.Round((anio * averages[0].averague * ident[i].idnEquivalence), 3, MidpointRounding.ToEven);
                        equivalences[i] = new EquivalenceVM()
                        {
                            Calculate = calc,
                            Description = ident[i].idnDescription,
                            Image = ident[i].idnImage
                        };
                    }
                    var order = equivalences.OrderBy(x => x.Order).ToArray();
                    responseVM.Add(new ResponseVM()
                    {
                        EmissionsGr_Km = emisionesGrKm,
                        EmissionsTn_Km = emisionesTnKm,
                        equivalence = equivalences
                    });
                }
                return new Tuple<List<ResponseVM>, List<ResponseVM>>(responseVM, responseVM);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Equivalencias. {ex}");
            }
        }
    }
}
