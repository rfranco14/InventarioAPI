using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    public class TelefonoClienteCreacionDTO
    {
        [Required]
        public string Numero { get; set; }
        public string Descripcion { get; set; }
        public string Nit { get; set; }
    }
}
