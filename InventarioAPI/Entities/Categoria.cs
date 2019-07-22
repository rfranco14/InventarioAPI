using System;
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
