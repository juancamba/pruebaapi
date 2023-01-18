using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gtMotive.Data;
using gtMotive.Dto;
using Microsoft.AspNetCore.Mvc;

namespace gtMotive.Controllers
{

  [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepo _repository;
        private readonly IMapper _mapper;


        public ClientesController(IClienteRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ClienteDto>> GetClientes()
        {

            var clientes = _repository.GetAllClientes();
            return Ok(_mapper.Map<IEnumerable<ClienteDto>>(clientes));
        }

    }
}