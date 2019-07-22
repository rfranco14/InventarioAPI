using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Entities
{
    public class Factura
    {
        public int NumeroFactura { get; set; }
        [Required]
        public string Nit { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public List<DetalleFactura> DetalleFacturas { get; set; } 
        public Cliente Cliente { get; set; }
    }
}
