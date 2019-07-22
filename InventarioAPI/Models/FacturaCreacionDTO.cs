using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    public class FacturaCreacionDTO
    {
        [Required]
        public string Nit { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
    }
}
