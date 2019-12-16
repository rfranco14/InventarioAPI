using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    public class ProductoCreacionDTO
    {
        [Required]
        public int CodigoCategoria { get; set; }
        public int CodigoEmpaque { get; set; }
        public string Descripcion { get; set; }
    }
}
