using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gtMotive.Dto
{
    public class VehiculoDto
    {
        public int Id { get; set; }
        public string Matricula { get; set; }=string.Empty;
        public string Marca { get; set; }=string.Empty;
        public string Modelo { get; set; }=string.Empty;
        public DateTime FechaFabricacion { get; set; }


    }
}