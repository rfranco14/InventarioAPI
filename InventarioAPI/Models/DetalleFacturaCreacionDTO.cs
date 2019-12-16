<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    public class DetalleFacturaCreacionDTO
    {
        [Required]
        public int NumeroFactura { get; set; }
        public int CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Descuento { get; set; }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    public class DetalleFacturaCreacionDTO
    {
        [Required]
        public int NumeroFactura { get; set; }
        public int CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Descuento { get; set; }
    }
}
>>>>>>> 29338d71b197ae945ea06c6e121c117effba2864
