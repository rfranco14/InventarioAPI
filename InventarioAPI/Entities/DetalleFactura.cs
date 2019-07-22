using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Entities
{
    public class DetalleFactura
    {
        public int CodigoDetalle { get; set; }
        [Required]
        public int NumeroFactura { get; set; }
        public int CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Descuento { get; set; }
        public Producto Producto { get; set; } 
        public Factura Factura { get; set; }
    }
}
