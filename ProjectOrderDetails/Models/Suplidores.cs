using ProjectOrderDetails.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrderDetails.Models
{
    public class Suplidores
    {
        [Key]
        public int suplidorId { get; set; }

        [Required(ErrorMessage = "Debe de introducir el nombre")]
        public string Nombre { get; set; }
    }
}
