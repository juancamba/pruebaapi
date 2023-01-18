using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gtMotive.Dto;
using gtMotive.Errors;
using gtMotive.Models;
using Microsoft.EntityFrameworkCore;

namespace gtMotive.Data
{
    public class AlquilerRepo : IAlquilerRepo
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AlquilerRepo(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public Alquiler Create(SolicitudAlquilerDto alquiler)
        {
            // _context.Alquileres.FirstOrDefault(a => a.FechaEntrada == null && a.Cliente.)
            if (alquiler == null)
            {
                throw new ArgumentNullException(nameof(alquiler));
            }
            var cliente = _context.Clientes.FirstOrDefault(a => a.Id == alquiler.ClienteId);
            var vehiculo = _context.Vehiculos.FirstOrDefault(a => a.Id == alquiler.VehiculoId);
            //var alquiles = _context.Alquileres.FirstOrDefault(a=>!a.Devuelto);

            List<Alquiler> alquileresEnCurso = _context.Alquileres.Where(a => !a.Devuelto).ToList();

            
            if (cliente == null || vehiculo == null)
            {
                throw new AlquilerException("no encuentro el vehiculo o el cliente");
            }
            else if(DateTime.Now.Year - vehiculo.FechaFabricacion.Year> 5 )
            {
                throw new AlquilerException("Vehiculo muy antiguo para alquilar");
            }
            else if (alquileresEnCurso.Any(a => a.ClienteId == alquiler.ClienteId))
            {
                throw new AlquilerException("El cliente ya tiene un vehiculo en alquiler");
            }
            else if (alquileresEnCurso.Any(a => a.VehiculoId == alquiler.VehiculoId))
            {
                throw new AlquilerException("El vehiculo ya está en uso");
            }
            Alquiler alquilerDb = new();
            alquilerDb.Cliente = cliente;
            alquilerDb.Vehiculo = vehiculo;
            alquilerDb.FechaSalida = DateTime.Now;

            // _context.Alquileres.FirstOrDefault(a=>)

            //alquiler.FechaSalida = DateTime.Now;
            _context.Alquileres.Add(alquilerDb);
            return alquilerDb;
        }

        public RespuestaAlquilerDto EntregarVehiculo(Alquiler alquiler)
        {
            //Alquiler alquilerDb = _context.Alquileres.Find(alquiler.Id);
            RespuestaAlquilerDto respuesta = new();
            Alquiler? alquilerDb = null;
            string mensaje;
            if (!_context.Alquileres.Any(a => a.Id == alquiler.Id))
            {
                respuesta.Mensaje = "No existe ese alquiler";
                return respuesta;

            }
            else if (_context.Alquileres.Any(a => a.Id == alquiler.Id && a.Devuelto))
            {

                alquilerDb = _context.Alquileres
                                .Where(w => w.Devuelto && w.Id == alquiler.Id)
                                .Include(w => w.Cliente)
                                .Include(w => w.Vehiculo).FirstOrDefault();

                mensaje = "El vehiculo ya habia sido entregado";
            }

            else
            {
                mensaje = "Vehiculo entregado OK";
                alquilerDb = _context.Alquileres
                                .Where(w => !w.Devuelto && w.Id == alquiler.Id)
                                .Include(w => w.Cliente)
                                .Include(w => w.Vehiculo).FirstOrDefault();

                alquilerDb.Devuelto = true;
                alquilerDb.FechaEntrada = DateTime.Now;
                _context.SaveChanges();
            }

            respuesta = _mapper.Map<RespuestaAlquilerDto>(alquilerDb);
            respuesta.Mensaje = mensaje;
            return respuesta;
        }

        public Alquiler GetAlquilerById(int id)
        {
            return _context.Alquileres.FirstOrDefault(p => p.Id == id);
        }
        public IEnumerable<Alquiler> GetAlquileres()
        {
            //return _context.Alquileres.ToList();

            return _context.Alquileres
                                
                                .Include(w => w.Cliente)
                                .Include(w => w.Vehiculo).ToList();
        }

        public IEnumerable<Vehiculo> GetVehiculosDisponibles()
        {
            //https://www.entityframeworktutorial.net/eager-loading-in-entity-framework.aspx
            // https://learn.microsoft.com/es-es/ef/ef6/querying/related-data
            //https://learn.microsoft.com/es-es/ef/ef6/querying/



            var noDevueltos = _context.Alquileres.Where(a => !a.Devuelto);

            //_context.Entry(noDevueltos)            .Collection(a => a.)


            //var aux2 = salida.ToList();

            return _context.Vehiculos.ToList();


        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}