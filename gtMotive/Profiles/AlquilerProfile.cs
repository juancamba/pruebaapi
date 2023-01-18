using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gtMotive.Dto;
using gtMotive.Models;

namespace gtMotive.Profiles
{
    public class AlquilerProfile : Profile
    {
        public AlquilerProfile(){
            CreateMap<Alquiler, AlquilerDto>();
            CreateMap<AlquilerDto, Alquiler>();

            CreateMap<Alquiler, RespuestaAlquilerDto>().ReverseMap();
        }
    }
}