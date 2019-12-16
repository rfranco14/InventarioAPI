<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    public class ProveedorDTO
    {
        public int CodigoProveedor { get; set; }
        [Required]
        public string Nit { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string PaginaWeb { get; set; }
        public string ContactoPrincipal { get; set; }
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
    public class ProveedorDTO
    {
        public int CodigoProveedor { get; set; }
        [Required]
        public string Nit { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string PaginaWeb { get; set; }
        public string ContactoPrincipal { get; set; }
    }
}
>>>>>>> 29338d71b197ae945ea06c6e121c117effba2864
