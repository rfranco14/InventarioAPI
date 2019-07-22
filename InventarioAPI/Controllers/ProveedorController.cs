using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using InventarioAPI.Context;
using InventarioAPI.Entities;
using InventarioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class ProveedorController : ControllerBase
    {
        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;

        public ProveedorController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProveedorDTO>>> Get()
        {
            var proveedores = await contexto.Proveedores.ToListAsync();
            var proveedoresDTO = mapper.Map<List<ProveedorDTO>>(proveedores);
            return proveedoresDTO;
        }

        [HttpGet("{id}", Name = "GetProveedor")]
        public async Task<ActionResult<ProveedorDTO>> Get(int id)
        {
            var proveedor = await contexto.Proveedores.FirstOrDefaultAsync(x => x.CodigoProveedor == id);
            if (proveedor == null)
            {
                return NotFound();
            }

            var proveedorDTO = mapper.Map<ProveedorDTO>(proveedor);
            return proveedorDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProveedorCreacionDTO proveedorCreacion)
        {
            var proveedor = mapper.Map<Proveedor>(proveedorCreacion);
            contexto.Add(proveedor);
            await contexto.SaveChangesAsync();
            var proveedorDTO = mapper.Map<ProveedorDTO>(proveedor);
            return  new CreatedAtRouteResult("GetProveedor", new {id = proveedor.CodigoProveedor},
                proveedorDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProveedorCreacionDTO proveedorActualizacion)
        {
            var proveedor = mapper.Map<Proveedor>(proveedorActualizacion);
            proveedor.CodigoProveedor = id;
            contexto.Entry(proveedor).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProveedorDTO>> Delete(int id)
        {
            var codigoProveedor = await contexto.Proveedores.Select(x => x.CodigoProveedor)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoProveedor == default(int))
            {
                return NotFound();
            }

            contexto.Remove(new Proveedor {CodigoProveedor = id});
            await contexto.SaveChangesAsync();
            return NoContent();
        }

    }
}
