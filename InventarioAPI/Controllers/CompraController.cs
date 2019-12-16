<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CompraController : ControllerBase
    {

        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;

        public CompraController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompraDTO>>> Get()
        {
            var compras = await contexto.Compras.ToListAsync();
            var comprasDTO = mapper.Map<List<CompraDTO>>(compras);
            return comprasDTO;
        }

        [HttpGet("{id}", Name = "GetCompra")]
        public async Task<ActionResult<CompraDTO>> Get(int id)
        {
            var compra = await contexto.Compras.FirstOrDefaultAsync(x => x.IdCompra == id);
            if (compra == null)
            {
                return NotFound();
            }
            var compraDTO = mapper.Map<CompraDTO>(compra);
            return compraDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CompraCreacionDTO compraCreacion)
        {
            var compra = mapper.Map<Compra>(compraCreacion);
            contexto.Add(compra);
            await contexto.SaveChangesAsync();
            var compraDTO = mapper.Map<CompraDTO>(compra);
            return new CreatedAtRouteResult("GetCompra", new { id = compra.IdCompra },
                compraDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CompraCreacionDTO compraActualizacion)
        {
            var compra = mapper.Map<Compra>(compraActualizacion);
            compra.IdCompra = id;
            contexto.Entry(compra).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CompraDTO>> Delete(int id)
        {
            var idCompra = await contexto.Compras.Select(x => x.IdCompra)
                .FirstOrDefaultAsync(x => x == id);
            if (idCompra == default(int))
            {
                return NotFound();
            }

            contexto.Remove(new Compra { IdCompra = id });
            await contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CompraController : ControllerBase
    {

        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;

        public CompraController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompraDTO>>> Get()
        {
            var compras = await contexto.Compras.ToListAsync();
            var comprasDTO = mapper.Map<List<CompraDTO>>(compras);
            return comprasDTO;
        }

        [HttpGet("{id}", Name = "GetCompra")]
        public async Task<ActionResult<CompraDTO>> Get(int id)
        {
            var compra = await contexto.Compras.FirstOrDefaultAsync(x => x.IdCompra == id);
            if (compra == null)
            {
                return NotFound();
            }
            var compraDTO = mapper.Map<CompraDTO>(compra);
            return compraDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CompraCreacionDTO compraCreacion)
        {
            var compra = mapper.Map<Compra>(compraCreacion);
            contexto.Add(compra);
            await contexto.SaveChangesAsync();
            var compraDTO = mapper.Map<CompraDTO>(compra);
            return new CreatedAtRouteResult("GetCompra", new { id = compra.IdCompra },
                compraDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CompraCreacionDTO compraActualizacion)
        {
            var compra = mapper.Map<Compra>(compraActualizacion);
            compra.IdCompra = id;
            contexto.Entry(compra).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CompraDTO>> Delete(int id)
        {
            var idCompra = await contexto.Compras.Select(x => x.IdCompra)
                .FirstOrDefaultAsync(x => x == id);
            if (idCompra == default(int))
            {
                return NotFound();
            }

            contexto.Remove(new Compra { IdCompra = id });
            await contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}
>>>>>>> 29338d71b197ae945ea06c6e121c117effba2864
