<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Entities
{
    public class Producto
    {
        public int CodigoProducto { get; set; }
        [Required]
        public int CodigoCategoria { get; set; }
        public int CodigoEmpaque { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioPorDocena { get; set; }
        public decimal PrecioPorMayor { get; set; }
        public int Existencia { get; set; }
        public string Imagen { get; set; }
        public Categoria Categoria { get; set; }
        public TipoEmpaque TipoEmpaque { get; set; }


        //public List<Inventario> Inventarios { get; set; } 
        //public List<DetalleCompra> DetalleCompras { get; set; }
        //public List<DetalleFactura> DetalleFacturas { get; set; }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Entities
{
    public class Producto
    {
        public int CodigoProducto { get; set; }
        [Required]
        public int CodigoCategoria { get; set; }
        public int CodigoEmpaque { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioPorDocena { get; set; }
        public decimal PrecioPorMayor { get; set; }
        public int Existencia { get; set; }
        public string Imagen { get; set; }
        public Categoria Categoria { get; set; }
        public TipoEmpaque TipoEmpaque { get; set; }
        public List<Inventario> Inventarios { get; set; } 
        public List<DetalleCompra> DetalleCompras { get; set; }
        public List<DetalleFactura> DetalleFacturas { get; set; }
    }
}
>>>>>>> 29338d71b197ae945ea06c6e121c117effba2864
