<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    public class CompraDTO
    {
        public int IdCompra { get; set; }
        [Required]
        public int NumeroDocumento { get; set; }
        public int CodigoProveedor { get; set; }
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
    public class CompraDTO
    {
        public int IdCompra { get; set; }
        [Required]
        public int NumeroDocumento { get; set; }
        public int CodigoProveedor { get; set; }
    }
}
>>>>>>> 29338d71b197ae945ea06c6e121c117effba2864
