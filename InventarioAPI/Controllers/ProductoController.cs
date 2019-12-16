using AutoMapper;
using InventarioAPI.Context;
using InventarioAPI.Entities;
using InventarioAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            var productos = await this.contexto.Productos.Include("Categoria").Include("TipoEmpaque").ToListAsync(); //metodo asincrono
            var productosDTO = this.mapper.Map<List<ProductoDTO>>(productos); //mapear la data
            return productosDTO;
        }

        [HttpGet("{id}", Name = "GetProducto")]
        public async Task<ActionResult<ProductoDTO>> Get(int id)
        {
            var producto = await this.contexto.Productos.Include("Categoria").Include("TipoEmpaque")
				.FirstOrDefaultAsync(x => x.CodigoProducto == id);
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
            var producto = this.mapper.Map<Producto>(productoCreacion);
            this.contexto.Add(producto);
            await this.contexto.SaveChangesAsync();
            var productoDTO = this.mapper.Map<ProductoDTO>(producto);
            return new CreatedAtRouteResult("GetProducto", new { id = producto.CodigoProducto },
                productoDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductoCreacionDTO productoActualizacion)
        {
            var producto = this.mapper.Map<Producto>(productoActualizacion);
            producto.CodigoProducto = id;
            this.contexto.Entry(producto).State = EntityState.Modified;
            await this.contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductoDTO>> Delete(int id)
        {
            var codigoProducto = await this.contexto.Productos.Select(x => x.CodigoProducto)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoProducto == default(int))
            {
                return NotFound();
            }

            this.contexto.Remove(new Producto { CodigoProducto = id });
            await this.contexto.SaveChangesAsync();
            return NoContent();
        }

    }
}
