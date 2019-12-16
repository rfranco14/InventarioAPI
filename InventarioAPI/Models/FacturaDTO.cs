<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    public class FacturaDTO
    {
        [Required]
        public string Nit { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
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
    public class FacturaDTO
    {
        [Required]
        public string Nit { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
    }
}
>>>>>>> 29338d71b197ae945ea06c6e121c117effba2864
