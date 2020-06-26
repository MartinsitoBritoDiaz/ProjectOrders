using ProjectOrderDetails.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrderDetails.Models
{
    public class Ordenes
    {
        [Key]
        public int ordenId { get; set; }

        [Required(ErrorMessage = "Debe introducir la fecha")]
        public DateTime fecha { get; set; }

        [Range(minimum:1,100,ErrorMessage = "Debe seleccionar el suplidor")]
        public int suplidorId { get; set; }

        [Required(ErrorMessage = "Debe ingresar un producto al detalle para poder calcular el monto")]
        public double monto { get; set; }

        [ForeignKey("ordenId")]
        public virtual List<OrdenesDetalle> OrdenesDetalles { get; set; } = new List<OrdenesDetalle>();
    }
}
