using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gtMotive.Dto
{
    public class RespuestaAlquilerDto : AlquilerDto
    {
        /*
        
        public int Id { get; set; }

        public DateTime FechaSalida { get; set; }
        public DateTime FechaEntrada { get; set; }
        public bool Devuelto { get; set; } */
        public string Mensaje {get;set;}=string.Empty;
        /*public virtual ClienteDto? Cliente { get; set; }
        
        public virtual VehiculoDto? Vehiculo { get; set; }*/
    }
}