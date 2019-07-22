using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InventarioAPI.Entities;

namespace InventarioAPI.Models
{
    public class ClienteDTO
    {
        public string Nit { get; set; }
        [Required]
        public string Dpi { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
    }
}
