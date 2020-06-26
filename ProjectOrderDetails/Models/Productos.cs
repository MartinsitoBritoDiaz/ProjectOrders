using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrderDetails.Models
{
    public class Productos
    {
        [Key]
        public int productoId { get; set; }
        
        [Required(ErrorMessage = "Debe de introducir la descripción")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "Debe de introducir el costo")]
        public double costo { get; set; }

        [Required(ErrorMessage = "Debe de introducir el inventario")]
        public int inventario { get; set; }
    }
}
