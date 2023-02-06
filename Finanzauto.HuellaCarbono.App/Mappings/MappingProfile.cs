using AutoMapper;
using Finanzauto.HuellaCarbono.App.Models.ViewModel;
using Finanzauto.HuellaCarbono.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.App.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<brand, BrandVM>();
            CreateMap<type, TypeVM>();
            CreateMap<brandType, TypeVM>();
            CreateMap<type, TypeVM>();
            CreateMap<fuel, FuelVM>();
        }
    }
}
