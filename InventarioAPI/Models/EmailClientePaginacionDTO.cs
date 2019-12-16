using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    public class EmailClientePaginacionDTO
    {
        public int Number { get; set; }
        public bool First { get; set; }
        public int TotalPages { get; set; }
        public bool Last { get; set; }
        public List<EmailClienteDTO> Content { get; set; }
    }
}
