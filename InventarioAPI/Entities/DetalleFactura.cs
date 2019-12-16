<<<<<<< HEAD
﻿using System;
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
=======
﻿using System;
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
>>>>>>> 29338d71b197ae945ea06c6e121c117effba2864
