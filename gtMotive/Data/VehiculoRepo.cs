using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gtMotive.Errors;
using gtMotive.Models;

namespace gtMotive.Data
{
    public class VehiculoRepo : IVehiculoRepo
    {
        
         private readonly AppDbContext _context;

        public VehiculoRepo(AppDbContext context)
        {
            _context = context;
        }
        
        public void Create(Vehiculo vehiculo)
        {
            if (vehiculo == null)
            {
                throw new ArgumentNullException(nameof(vehiculo));
            }
            else if(DateTime.Now.Year - vehiculo.FechaFabricacion.Year> 5 )
            {
                throw new VehiculoException("Vehiculo muy antiguo");
            }
            _context.Vehiculos.Add(vehiculo);
        }

        public IEnumerable<Vehiculo> GetAllVehiculos()
        {
            return _context.Vehiculos.ToList();
        }

        public Vehiculo GetVehiculoById(int id)
        {
            return _context.Vehiculos.FirstOrDefault(v=>v.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}