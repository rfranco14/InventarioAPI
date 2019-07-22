using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    public class DetalleFacturaDTO
    {
        public int CodigoDetalle { get; set; }
        [Required]
        public int NumeroFactura { get; set; }
        public int CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Descuento { get; set; }
    }
}
