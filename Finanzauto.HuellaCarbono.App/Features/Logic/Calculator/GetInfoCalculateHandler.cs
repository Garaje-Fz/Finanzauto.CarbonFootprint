﻿using AutoMapper;
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
    public class GetInfoCalculateHandler : IRequestHandler<GetInfoCalculate, Tuple<List<ResponseVM>, ExceptionVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetInfoCalculateHandler> _logger;
        private readonly IMapper _mapper;

        public GetInfoCalculateHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Tuple<List<ResponseVM>, ExceptionVM>> Handle(GetInfoCalculate request, CancellationToken cancellationToken)
        {
            try
            {
                var responseVM = new List<ResponseVM>();
                var newRecord = new record();
                double calc;
                var line = await _unitOfWork.Repository<line>().GetAsync(x => x.codigoFasecolda == request.Codigo_Fasecolda && x.linYear == request.Anio);
                if (line == null) throw new Exception("Digite un año valido");

                var ident = await _unitOfWork.Repository<identity>().GetAsync(x => x.fueId == line[0].fueId);
                var averages = await _unitOfWork.Repository<type>().GetAsync(x => x.typId == line[0].typId);
                EquivalenceVM[] equivalences = new EquivalenceVM[ident.Count];
                double emisionesGrKm;
                double emisionesTnKm;
                double emision;
                if (request.Kilometraje > 0)
                {
                    if (line[0].fueId == 2)
                    {
                        emision = Convert.ToDouble(averages[0].averagueCo2);
                        emisionesGrKm = Convert.ToDouble(averages[0].averagueCo2) * 100000;
                        emisionesTnKm = Math.Round(request.Kilometraje * Convert.ToDouble(averages[0].averagueCo2), 3, MidpointRounding.ToEven);
                    }
                    else
                    {
                        emision = Convert.ToDouble(line[0].huellaCarbono_TonKm);
                        emisionesGrKm = Convert.ToDouble(line[0].EmisionesCO2_GrKm);
                        emisionesTnKm = Math.Round(request.Kilometraje * Convert.ToDouble(line[0].huellaCarbono_TonKm), 3, MidpointRounding.ToEven);
                    }
                    
                    for (int i = 0; i < ident.Count; i++)
                    {
                        calc = Math.Round(request.Kilometraje * emision * ident[i].idnEquivalence, 3, MidpointRounding.ToEven);
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
                    newRecord = new record()
                    {
                        linId = line[0].linId,
                        recKm = request.Kilometraje,
                        recEmisionGrKm = emisionesGrKm,
                        recCalculateTnKm = emisionesTnKm,
                        recEmisionTnKm = Convert.ToDouble(line[0].huellaCarbono_TonKm),
                        recCreateDate = DateTime.Now
                    };
                }
                else
                {

                    var anio = Convert.ToInt32(DateTime.Today.Year.ToString("D")) - line[0].linYear;
                    if (line[0].fueId == 2)
                    {
                        emision = Convert.ToDouble(averages[0].averagueCo2);
                        emisionesGrKm = Convert.ToDouble(averages[0].averagueCo2) * 100000;
                        emisionesTnKm = Math.Round(anio * averages[0].averagueKm * Convert.ToDouble(averages[0].averagueCo2), 3, MidpointRounding.ToEven);
                    }
                    else
                    {
                        emision = Convert.ToDouble(averages[0].averagueCo2);
                        emisionesGrKm = Convert.ToDouble(line[0].EmisionesCO2_GrKm);
                        emisionesTnKm = Math.Round(anio * averages[0].averagueKm * Convert.ToDouble(line[0].huellaCarbono_TonKm), 3, MidpointRounding.ToEven);
                    }
                    for (int i = 0; i < ident.Count; i++)
                    {
                        calc = Math.Round((anio * averages[0].averagueKm * ident[i].idnEquivalence), 3, MidpointRounding.ToEven);
                        equivalences[i] = new EquivalenceVM()
                        {
                            Order = ident[i].idnOrden,
                            Calculate = calc,
                            Description = ident[i].idnDescription,
                            Image = ident[i].idnImage
                        };
                    }
                    responseVM.Add(new ResponseVM()
                    {
                        EmissionsGr_Km = emisionesGrKm,
                        EmissionsTn_Km = emisionesTnKm,
                        equivalence = equivalences
                    });
                    newRecord = new record()
                    {
                        linId = line[0].linId,
                        recKm = request.Kilometraje,
                        recEmisionGrKm = emisionesGrKm,
                        recCalculateTnKm = emisionesTnKm,
                        recEmisionTnKm = Convert.ToDouble(line[0].huellaCarbono_TonKm),
                        recCreateDate = DateTime.Now
                    };
                }
                await _unitOfWork.Repository<record>().AddAsync(newRecord);
                return new Tuple<List<ResponseVM>, ExceptionVM>(responseVM, null);
            }
            catch (Exception ex)
            {
                var line = await _unitOfWork.Repository<line>().GetAsync(x => x.codigoFasecolda == request.Codigo_Fasecolda);
                List<YearVM> result = new List<YearVM>();
                for (int i = 0; i <= line.Count - 1; i++)
                {
                    result.Add(new YearVM()
                    {
                        linYear = line[i].linYear
                    });   
                }
                result.Sort(delegate (YearVM a, YearVM b)
                {
                    return a.linYear.CompareTo(b.linYear);
                });
                return new Tuple<List<ResponseVM>, ExceptionVM>
                    (null, (new ExceptionVM()
                    {
                        description = "Digite un año valido",
                        Anios = result
                    })
                );
            }
        }
    }
}
