<<<<<<< HEAD
﻿using System;
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
=======
﻿using System;
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
>>>>>>> 29338d71b197ae945ea06c6e121c117effba2864
