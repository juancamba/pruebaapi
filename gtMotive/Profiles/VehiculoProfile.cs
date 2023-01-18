using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gtMotive.Dto;
using gtMotive.Models;

namespace gtMotive.Profiles
{
    public class VehiculoProfile : Profile
    {

        public VehiculoProfile(){
            CreateMap<Vehiculo, VehiculoDto>();
            CreateMap<VehiculoDto, Vehiculo>();
            

            CreateMap<Vehiculo, RespuestaVehiculoDto>().ReverseMap();
        }
        
    }
}