using AutoMapper;
using InventarioAPI.Context;
using InventarioAPI.Entities;
using InventarioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;

        public ProductoController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> Get()
        {
            var productos = await contexto.Productos.ToListAsync();
            var productosDTO = mapper.Map<List<ProductoDTO>>(productos);
            return productosDTO;
        }

        [HttpGet("{id}", Name = "GetProducto")]
        public async Task<ActionResult<ProductoDTO>> Get(int id)
        {
            var producto = await contexto.Productos.FirstOrDefaultAsync(x => x.CodigoProducto == id);
            if (producto == null)
            {
                return NotFound();
            }
            var productoDTO = mapper.Map<ProductoDTO>(producto);
            return productoDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductoCreacionDTO productoCreacion)
        {
            var producto = mapper.Map<Producto>(productoCreacion);
            contexto.Add(producto);
            await contexto.SaveChangesAsync();
            var productoDTO = mapper.Map<ProductoDTO>(producto);
            return new CreatedAtRouteResult("GetProducto", new { id = producto.CodigoProducto },
                productoDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductoCreacionDTO productoActualizacion)
        {
            var producto = mapper.Map<Producto>(productoActualizacion);
            producto.CodigoProducto = id;
            contexto.Entry(producto).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductoDTO>> Delete(int id)
        {
            var codigoProducto = await contexto.Productos.Select(x => x.CodigoProducto)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoProducto == default(int))
            {
                return NotFound();
            }

            contexto.Remove(new Producto { CodigoProducto = id });
            await contexto.SaveChangesAsync();
            return NoContent();
        }

    }
}
