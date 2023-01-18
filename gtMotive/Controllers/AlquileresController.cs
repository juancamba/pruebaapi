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
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquileresController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IAlquilerRepo _repository;
        private readonly IMapper _mapper;

        public AlquileresController(IAlquilerRepo repository, IMapper mapper, ILogger<AlquileresController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

       /* public ActionResult<IEnumerable<VehiculoDto>> GetVehiculosDisponibles()
        {
            _logger.LogInformation("getting platforms");
            var vehiculosItem = _repository.GetVehiculosDisponibles();
            return Ok(_mapper.Map<IEnumerable<VehiculoDto>>(vehiculosItem));
        }
*/
        [HttpGet]
        public ActionResult<IEnumerable<AlquilerDto>> GetAlquileres()
        {

            var alquieleres = _repository.GetAlquileres();
            return Ok(_mapper.Map<IEnumerable<AlquilerDto>>(alquieleres));
        }

        [HttpGet("{id}", Name = "GetAlquilerById")]
        public ActionResult<AlquilerDto> GetAlquilerById(int id)
        {
            var alquilerItem = _repository.GetAlquilerById(id);
            if (alquilerItem != null)
            {
                return Ok(_mapper.Map<AlquilerDto>(alquilerItem));
            }
            return NotFound();

        }
        [HttpPost]
        public ActionResult<RespuestaAlquilerDto> Create(SolicitudAlquilerDto alquilerDto)
        {
            RespuestaAlquilerDto respuesta = new();
            try
            {
                _logger.LogInformation("Crear alquiler");
                //var alquilerModel = _mapper.Map<Alquiler>(alquilerDto);

                Alquiler alquilerModel =_repository.Create(alquilerDto);
                _repository.SaveChanges();

                var AlquilerDto = _mapper.Map<RespuestaAlquilerDto>(alquilerModel);

                return CreatedAtRoute(nameof(GetAlquilerById), new { Id = AlquilerDto.Id }, AlquilerDto);
            }
            catch (AlquilerException e)
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

        [HttpPut]
        public ActionResult<RespuestaAlquilerDto> Update(AlquilerEntregaDto alquilerEntregaDto)
        {
            RespuestaAlquilerDto respuesta = new();
            try
            {
                var alquilerItem = _repository.GetAlquilerById(alquilerEntregaDto.IdAlquiler);
                if (alquilerItem != null)
                {
                    respuesta = _repository.EntregarVehiculo(alquilerItem);
                    //var AlquilerDto = _mapper.Map<AlquilerDto>(alquilerModel);
                    _logger.LogInformation(respuesta.ToString());
                    return Ok(respuesta);

                }
                else
                {
                    respuesta.Mensaje = "No existe el alquiler";
                    _logger.LogInformation(respuesta.ToString());
                    return Ok(respuesta);
                }
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