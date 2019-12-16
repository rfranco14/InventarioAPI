<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Entities
{
    public class DetalleCompra
    {
        public int IdDetalle { get; set; }
        [Required]
        public int IdCompra { get; set; }
        public int CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public Producto Producto { get; set; } 
        public Compra Compra { get; set; }
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
    public class DetalleCompra
    {
        public int IdDetalle { get; set; }
        [Required]
        public int IdCompra { get; set; }
        public int CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public Producto Producto { get; set; } 
        public Compra Compra { get; set; }
    }
}
>>>>>>> 29338d71b197ae945ea06c6e121c117effba2864
