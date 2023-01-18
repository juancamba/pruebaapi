using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gtMotive.Data;
using gtMotive.Dto;
using gtMotive.Errors;
using gtMotive.Models;
using Microsoft.AspNetCore.Mvc;

namespace gtMotive.Controllers
{/*
    Una Empresa de renting. El microservicio debería de permitir realizar las siguientes acciones (a
    través de llamadas REST):
    - Debería de gestionar la creación de nuevos vehículos para la flota.
    - Poder listar los vehículos disponibles de la flota.
    - Poder alquilar un vehículo.
    - Devolución del vehículo.
    */
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoRepo _repository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public VehiculosController(IVehiculoRepo repository, IMapper mapper, ILogger<VehiculosController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult<IEnumerable<VehiculoDto>> GetVehiculos()
        {

            var Vehiculos = _repository.GetAllVehiculos();
            return Ok(_mapper.Map<IEnumerable<VehiculoDto>>(Vehiculos));
        }
        [HttpGet("{id}", Name = "GetVehiculoById")]
        public ActionResult<VehiculoDto> GetVehiculoById(int id)
        {
            var vehiculoItem = _repository.GetVehiculoById(id);
            if (vehiculoItem != null)
            {
                return Ok(_mapper.Map<VehiculoDto>(vehiculoItem));
            }
            return NotFound();

        }
        [HttpPost]
        public ActionResult<RespuestaVehiculoDto> Create(VehiculoDto vehiculoDto)
        {

            RespuestaVehiculoDto respuesta = new();

            try
            {
                _logger.LogInformation("Crear alquiler");
                var vehiculoModel = _mapper.Map<Vehiculo>(vehiculoDto);

                _repository.Create(vehiculoModel);
                _repository.SaveChanges();

                respuesta = _mapper.Map<RespuestaVehiculoDto>(vehiculoModel);

                //2:10
                return CreatedAtRoute(nameof(GetVehiculoById), new { Id = respuesta.Id }, respuesta);
            }
            catch (VehiculoException e)
            {
                respuesta.Mensaje = e.Message;
                _logger.LogInformation(e.Message);
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                respuesta.Mensaje = "Error en la petición";
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, respuesta);
            }


        }
    }
}