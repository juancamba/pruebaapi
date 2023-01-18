using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace gtMotive.Dto
{
    public class ClienteDto
    {
        public int Id { get; set; }

        public string Dni { get; set; }=string.Empty;


        public string Nombres { get; set; }=string.Empty;



        public string Apellidos { get; set; }=string.Empty;


        public DateTime FechaNacimiento { get; set; }
    }
}