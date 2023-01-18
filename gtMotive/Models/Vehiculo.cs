using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace gtMotive.Models
{
    
    public class Vehiculo
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        
        public string Matricula { get; set; }=string.Empty;
        [Required]
        public string Marca { get; set; }=string.Empty;
        [Required]
        public string Modelo { get; set; }=string.Empty;
        [Required]
        public DateTime FechaFabricacion { get; set; }
        public virtual Alquiler? Alquiler {get;set;}

    }
}