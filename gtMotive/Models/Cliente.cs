using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gtMotive.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int Id{get;set;}
        [Required]
        public string Dni {get;set;}=string.Empty;

        [Required]
        public string Nombres {get;set;}=string.Empty;


        [Required]
        public string Apellidos {get;set;}=string.Empty;

        [Required]
        public DateTime FechaNacimiento{get;set;}

        public virtual Alquiler? Alquiler {get;set;}
    }
}