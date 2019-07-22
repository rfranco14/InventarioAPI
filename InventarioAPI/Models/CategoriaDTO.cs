using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    public class CategoriaDTO
    {
        public int CodigoCategoria { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}
