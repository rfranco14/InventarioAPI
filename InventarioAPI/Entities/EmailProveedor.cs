<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Entities
{
    public class EmailProveedor
    {
        public int CodigoEmail { get; set; }
        [Required]
        public string Email { get; set; }
        public int CodigoProveedor { get; set; }
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
    public class EmailProveedor
    {
        public int CodigoEmail { get; set; }
        [Required]
        public string Email { get; set; }
        public int CodigoProveedor { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
>>>>>>> 29338d71b197ae945ea06c6e121c117effba2864
