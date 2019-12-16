<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    public class InventarioDTO
    {
        public int CodigoInventario { get; set; }
        [Required]
        public int CodigoProducto { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoRegistro { get; set; }
        public double Precio { get; set; }
        public int Entradas { get; set; }
        public int Salidas { get; set; }
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
    public class InventarioDTO
    {
        public int CodigoInventario { get; set; }
        [Required]
        public int CodigoProducto { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoRegistro { get; set; }
        public double Precio { get; set; }
        public int Entradas { get; set; }
        public int Salidas { get; set; }
    }
}
>>>>>>> 29338d71b197ae945ea06c6e121c117effba2864
