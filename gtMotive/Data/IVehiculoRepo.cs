using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gtMotive.Models;

namespace gtMotive.Data
{
    public interface IVehiculoRepo
    {
        bool SaveChanges();

        IEnumerable<Vehiculo> GetAllVehiculos();

        Vehiculo GetVehiculoById(int id);
        void Create(Vehiculo vehiculo);
    }
}