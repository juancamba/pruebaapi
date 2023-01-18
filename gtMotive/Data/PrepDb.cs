using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gtMotive.Models;

namespace gtMotive.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Vehiculos.Any())
            {
                Console.WriteLine("seeding data");
                context.Vehiculos.AddRange(
                    new Vehiculo() { Matricula = "2345mhg", Marca = "Dodge", Modelo = "Charger" , FechaFabricacion = new DateTime(1970, 12, 31) },
                       new Vehiculo() { Matricula = "1111fas", Marca = "BMW", Modelo = "M3" , FechaFabricacion = new DateTime(2020, 12, 31) },
                          new Vehiculo() { Matricula = "3331gas", Marca = "Volkswagen", Modelo = "Golf GTI" , FechaFabricacion = new DateTime(2015, 12, 31) }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Tenemos datos");
            }

            if(!context.Clientes.Any())
            {
                context.Clientes.AddRange(
                    new Cliente(){Dni = "32123456A", Nombres="Juan Carlos",Apellidos="Ferreiro",FechaNacimiento=new DateTime(1970,12,20),},
                    new Cliente(){Dni = "12111123B", Nombres="Lionel",Apellidos="Messi",FechaNacimiento=new DateTime(1985,2,26),},
                    new Cliente(){Dni = "45611111C", Nombres="Cristiano",Apellidos="Ronaldo",FechaNacimiento=new DateTime(1983,4,29),}
                );
                context.SaveChanges();
            }
            if(!context.Alquileres.Any())
            {
                context.Alquileres.AddRange(
                    new Alquiler(){    FechaSalida=DateTime.Now,ClienteId=1,VehiculoId=1         }
                );
                context.SaveChanges();
            }

            
            


        }
    }
}