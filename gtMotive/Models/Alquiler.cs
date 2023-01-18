using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gtMotive.Models
{
    public class Alquiler
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public DateTime FechaSalida { get; set; }
        public DateTime? FechaEntrada { get; set; }

        public bool Devuelto { get; set; } = false;

        public int ClienteId { get; set; }
        public int VehiculoId { get; set; }
        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
        [ForeignKey("VehiculoId")]
        public virtual Vehiculo Vehiculo { get; set; }


    }
}