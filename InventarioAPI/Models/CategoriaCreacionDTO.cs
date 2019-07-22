using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    public class CategoriaCreacionDTO
    {
        [Required]
        public string Descripcion { get; set; }
    }
}
