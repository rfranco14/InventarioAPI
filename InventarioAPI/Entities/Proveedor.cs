using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Entities
{
    public class Proveedor
    {
        public int CodigoProveedor { get; set; }
        [Required]
        public string Nit { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string PaginaWeb { get; set; }
        public string ContactoPrincipal { get; set; }
        public List<Compra> Compras { get; set; }                         
        public List<EmailProveedor> EmailProveedores { get; set; }  
        public List<TelefonoProveedor> TelefonoProveedores { get; set; }
    }
}
