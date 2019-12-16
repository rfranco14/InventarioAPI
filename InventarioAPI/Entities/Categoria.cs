<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Entities
{
    public class Categoria
    {
         public int CodigoCategoria { get; set; }
        [Required]
        public string Descripcion { get; set;  }
        public List<Producto> Productos { get; set; }
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
    public class Categoria
    {
         public int CodigoCategoria { get; set; }
        [Required]
        public string Descripcion { get; set;  }
        public List<Producto> Productos { get; set; }
    }
}
>>>>>>> 29338d71b197ae945ea06c6e121c117effba2864
