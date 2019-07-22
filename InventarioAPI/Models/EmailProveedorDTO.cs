using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    public class EmailProveedorDTO
    {
        [Required]
        public string Email { get; set; }
        public int CodigoProveedor { get; set; }
    }
}
