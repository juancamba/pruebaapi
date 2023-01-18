using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gtMotive.Dto;
using gtMotive.Models;

namespace gtMotive.Profiles
{
    public class ClientesProfile : Profile
    {

        public ClientesProfile(){
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();
        }
        
    }
}