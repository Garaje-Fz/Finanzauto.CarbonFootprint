using AutoMapper;
using Finanzauto.HuellaCarbono.App.Contracts.Persistence;
using Finanzauto.HuellaCarbono.App.Features.Lines.Queries;
using Finanzauto.HuellaCarbono.App.Models.ViewModel.Calculate;
using Finanzauto.HuellaCarbono.App.Models.ViewModel.Calculate.Equivalences;
using Finanzauto.HuellaCarbono.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.App.Features.Logic.Calculator
{
    public class GetInfoCalculateHandler : IRequestHandler<GetInfoCalculate, Tuple<List<ResponseVM>, List<AveragueVM>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetInfoCalculateHandler> _logger;
        private readonly IMapper _mapper;

        public GetInfoCalculateHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Tuple<List<ResponseVM>, List<AveragueVM>>> Handle(GetInfoCalculate request, CancellationToken cancellationToken)
        {
            try
            {
                Calculator calculator = new Calculator(_unitOfWork);
                var responseVM = new List<ResponseVM>();
                var averagueVM = new List<AveragueVM>();
                var equivalences = new List<EquivalenceVM>();

                var line = await _unitOfWork.Repository<line>().GetAsync(x => x.linId == request.Id_Line);
                var ident = await _unitOfWork.Repository<identity>().GetAllAsync();
                var averages = await _unitOfWork.Repository<type>().GetAsync(x => x.typId == line[0].typId);

                if (request.Kilometraje > 0)
                {
                    var emisionesGrKm = Math.Round(request.Kilometraje * Convert.ToDouble(line[0].EmisionesCO2_GrKm), 1, MidpointRounding.ToEven);
                    var emisionesTnKm = Math.Round((request.Kilometraje * Convert.ToDouble(line[0].huellaCarbono_TonKm)), 1, MidpointRounding.ToEven);
                    responseVM.Add(new ResponseVM()
                    {
                        Clase = averages[0].typName,
                        Emisiones_Gr_Km = emisionesGrKm,
                        Emisiones_Tn_Km = emisionesTnKm,
                        Arboles = new ArbolesVM()
                        {
                            Nombre = ident[0].idnName,
                            Descripcion = $"Has emitido alrededor de " +
                            $"@emisionesTnKm toneladas de CO2 equivalente, lo que lograría ser compensado con la siembra de " +
                            $"@calculo plantulas (árboles jovenes) con una esperanza de vida de 10 años.",
                            Image = ident[0].idnImage,
                            Equivalencia = ident[0].idnEquivalence,
                            Calculo = calculator.CalcEqui(emisionesTnKm, ident[0].idnEquivalence),
                            Orden = ident[0].idnOrden,
                        },
                        Celulares = new CelularesVM()
                        {
                            Nombre = ident[1].idnName,
                            Descripcion = $"Has emitido alrededor de " +
                            $"@emisionesTnKm toneladas de CO2 equivalente, lo que corresponde a cargar " +
                            $"@calculo telefonos celulares inteligentes.",
                            Image = ident[1].idnImage,
                            Equivalencia = ident[1].idnEquivalence,
                            Calculo = calculator.CalcEqui(emisionesTnKm, ident[1].idnEquivalence),
                            Orden = ident[1].idnOrden,
                        },
                        Viajes = new ViajesVM()
                        {
                            Nombre = ident[2].idnName,
                            Descripcion = $"Has emitido alrededor de " +
                            $"@emisionesTnKm toneladas de CO2 equivalente, lo que corresponde a realizar aproximadamente " +
                            $"{calculator.CalcEqui(emisionesTnKm, ident[2].idnEquivalence)} viajes de Bogotá a San Andrés en avión.",
                            Image = ident[2].idnImage,
                            Equivalencia = ident[2].idnEquivalence,
                            Calculo = calculator.CalcEqui(emisionesTnKm, ident[2].idnEquivalence),
                            Orden = ident[2].idnOrden,
                        },
                        Computadores = new ComputadoresVM()
                        {
                            Nombre = ident[3].idnName,
                            Descripcion = $"Has emitido alrededor de " +
                            $"@emisionesTnKm toneladas de CO2 equivalente, lo que corresponde a mantener encendido aproximadamente " +
                            $"{calculator.CalcEqui(emisionesTnKm, ident[3].idnEquivalence)} computadores durante 5 días a la semana, 9 horas al día, durante un año.",
                            Image = ident[3].idnImage,
                            Equivalencia = ident[3].idnEquivalence,
                            Calculo = calculator.CalcEqui(emisionesTnKm, ident[3].idnEquivalence),
                            Orden = ident[3].idnOrden,
                        },
                        Carne = new CarneVM()
                        {
                            Nombre = ident[4].idnName,
                            Descripcion = $"Has emitido alrededor de " +
                            $"@emisionesTnKm toneladas de CO2 equivalente, lo que corresponde a producir " +
                            $"{calculator.CalcEqui(emisionesTnKm, ident[4].idnEquivalence)} kg de carne de vaca.",
                            Image = ident[4].idnImage,
                            Equivalencia = ident[4].idnEquivalence,
                            Calculo = calculator.CalcEqui(emisionesTnKm, ident[4].idnEquivalence),
                            Orden = ident[4].idnOrden,
                        }
                    });
                }
                else
                {
                    var anio = Convert.ToInt32(DateTime.Today.Year.ToString("D")) - line[0].linYear;
                    var emisionesGrKm = Math.Round(anio * averages[0].Averague * Convert.ToDouble(line[0].EmisionesCO2_GrKm), 1, MidpointRounding.ToEven);
                    var emisionesTnKm = Math.Round(anio * averages[0].Averague * Convert.ToDouble(line[0].huellaCarbono_TonKm), 1, MidpointRounding.ToEven);
                    averagueVM.Add(new AveragueVM()
                    {
                        Clase = averages[0].typName,
                        Promedio_Año_Km = averages[0].Averague,
                        años = $"Vida del vehiculo desde {line[0].linYear} hasta {DateTime.Today.Year.ToString("D")} es de {anio} años",
                        Emisiones_Gr_Km = emisionesGrKm,
                        Emisiones_Tn_Km = emisionesTnKm,
                        Arboles = new ArbolesVM()
                        {
                            Nombre = ident[0].idnName,
                            Descripcion = $"Has emitido alrededor de " +
                            $"@emisionesTnKm toneladas de CO2 equivalente, lo que lograría ser compensado con la siembra de " +
                            $"{calculator.CalcEqui(emisionesTnKm, ident[0].idnEquivalence)} plantulas (árboles jovenes) con una esperanza de vida de 10 años.",
                            Image = ident[0].idnImage,
                            Equivalencia = ident[0].idnEquivalence,
                            Calculo = calculator.CalcEqui(emisionesTnKm, ident[0].idnEquivalence),
                            Orden = ident[0].idnOrden,
                        },
                        Celulares = new CelularesVM()
                        {
                            Nombre = ident[1].idnName,
                            Descripcion = $"Has emitido alrededor de " +
                            $"@emisionesTnKm toneladas de CO2 equivalente, lo que corresponde a cargar " +
                            $"@calculo telefonos celulares inteligentes.",
                            Image = ident[1].idnImage,
                            Equivalencia = ident[1].idnEquivalence,
                            Calculo = calculator.CalcEqui(emisionesTnKm, ident[1].idnEquivalence),
                            Orden = ident[1].idnOrden,
                        },
                        Viajes = new ViajesVM()
                        {
                            Nombre = ident[2].idnName,
                            Descripcion = $"Has emitido alrededor de " +
                            $"@emisionesTnKm toneladas de CO2 equivalente, lo que corresponde a realizar aproximadamente " +
                            $"{calculator.CalcEqui(emisionesTnKm, ident[2].idnEquivalence)} viajes de Bogotá a San Andrés en avión.",
                            Image = ident[2].idnImage,
                            Equivalencia = ident[2].idnEquivalence,
                            Calculo = calculator.CalcEqui(emisionesTnKm, ident[2].idnEquivalence),
                            Orden = ident[2].idnOrden,
                        },
                        Computadores = new ComputadoresVM()
                        {
                            Nombre = ident[3].idnName,
                            Descripcion = $"Has emitido alrededor de " +
                            $"@emisionesTnKm toneladas de CO2 equivalente, lo que corresponde a mantener encendido aproximadamente " +
                            $"{calculator.CalcEqui(emisionesTnKm, ident[3].idnEquivalence)} computadores durante 5 días a la semana, 9 horas al día, durante un año.",
                            Image = ident[3].idnImage,
                            Equivalencia = ident[3].idnEquivalence,
                            Calculo = calculator.CalcEqui(emisionesTnKm, ident[3].idnEquivalence),
                            Orden = ident[3].idnOrden,
                        },
                        Carne = new CarneVM()
                        {
                            Nombre = ident[4].idnName,
                            Descripcion = $"Has emitido alrededor de " +
                            $"@emisionesTnKm toneladas de CO2 equivalente, lo que corresponde a producir " +
                            $"{calculator.CalcEqui(emisionesTnKm, ident[4].idnEquivalence)} kg de carne de vaca.",
                            Image = ident[4].idnImage,
                            Equivalencia = ident[4].idnEquivalence,
                            Calculo = calculator.CalcEqui(emisionesTnKm, ident[4].idnEquivalence),
                            Orden = ident[4].idnOrden,
                        }
                    });
                }
                return new Tuple<List<ResponseVM>, List<AveragueVM>>(responseVM, averagueVM);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Equivalencias. {ex}");
            }
        }
    }
}
