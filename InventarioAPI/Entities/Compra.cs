<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Entities
{
    public class Compra
    {
        public int IdCompra { get; set; }
        [Required]
        public int NumeroDocumento { get; set; }
        public int CodigoProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public List<DetalleCompra> DetalleCompras { get; set; } 
        public Proveedor Proveedor { get; set; }
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
    public class Compra
    {
        public int IdCompra { get; set; }
        [Required]
        public int NumeroDocumento { get; set; }
        public int CodigoProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public List<DetalleCompra> DetalleCompras { get; set; } 
        public Proveedor Proveedor { get; set; }
    }
}
>>>>>>> 29338d71b197ae945ea06c6e121c117effba2864
