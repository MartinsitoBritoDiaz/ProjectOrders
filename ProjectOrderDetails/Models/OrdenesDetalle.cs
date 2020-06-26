using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrderDetails.Models
{
    public class OrdenesDetalle
    {
        [Key]
        public int ordenDetalleId { get; set; }
        public int ordenId { get; set; }
        public int cantidad { get; set; }
        public double costo { get; set; }
        public int productId { get; set; }
        public string producto { get; set; }
    }
}
