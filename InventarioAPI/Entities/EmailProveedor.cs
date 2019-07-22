using System;
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
