using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gtMotive.Dto;
using gtMotive.Models;

namespace gtMotive.Data
{
    public interface IAlquilerRepo
    {
        bool SaveChanges();
        IEnumerable<Vehiculo> GetVehiculosDisponibles();
        Alquiler GetAlquilerById(int id);
        Alquiler Create(SolicitudAlquilerDto alquiler); 
        RespuestaAlquilerDto EntregarVehiculo(Alquiler alquiler);
        public IEnumerable<Alquiler> GetAlquileres();
    }
}