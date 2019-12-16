<<<<<<< HEAD
﻿using AutoMapper;
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
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DetalleFacturaController : ControllerBase
    {
        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;

        public DetalleFacturaController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleFacturaDTO>>> Get()
        {
            var detalleFacturas = await contexto.DetalleFacturas.ToListAsync();
            var detalleFacturaDTO = mapper.Map<List<DetalleFacturaDTO>>(detalleFacturas);
            return detalleFacturaDTO;
        }

        [HttpGet("{id}", Name = "GetDetalleFactura")]
        public async Task<ActionResult<DetalleFacturaDTO>> Get(int id)
        {
            var detalleFactura = await contexto.DetalleFacturas.FirstOrDefaultAsync(x => x.CodigoDetalle == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }
            var detalleFacturaDTO = mapper.Map<DetalleFacturaDTO>(detalleFactura);
            return detalleFacturaDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DetalleFacturaCreacionDTO detalleFacturaCreacion)
        {
            var detalleFactura = mapper.Map<DetalleFactura>(detalleFacturaCreacion);
            contexto.Add(detalleFactura);
            await contexto.SaveChangesAsync();
            var detalleFacturaDTO = mapper.Map<DetalleFacturaDTO>(detalleFactura);
            return new CreatedAtRouteResult("GetDetalleFactura", new { id = detalleFactura.CodigoDetalle },
                detalleFacturaDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DetalleFacturaCreacionDTO detalleFacturaActualizacion)
        {
            var detalleFactura = mapper.Map<DetalleFactura>(detalleFacturaActualizacion);
            detalleFactura.CodigoDetalle = id;
            contexto.Entry(detalleFactura).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DetalleFacturaDTO>> Delete(int id)
        {
            var codigoDetalle = await contexto.DetalleFacturas.Select(x => x.CodigoDetalle)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoDetalle == default(int))
            {
                return NotFound();
            }

            contexto.Remove(new DetalleFactura { CodigoDetalle = id });
            await contexto.SaveChangesAsync();
            return NoContent();
        }

    }
}
=======
﻿using AutoMapper;
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
    public class DetalleFacturaController : ControllerBase
    {
        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;

        public DetalleFacturaController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleFacturaDTO>>> Get()
        {
            var detalleFacturas = await contexto.DetalleFacturas.ToListAsync();
            var detalleFacturaDTO = mapper.Map<List<DetalleFacturaDTO>>(detalleFacturas);
            return detalleFacturaDTO;
        }

        [HttpGet("{id}", Name = "GetDetalleFactura")]
        public async Task<ActionResult<DetalleFacturaDTO>> Get(int id)
        {
            var detalleFactura = await contexto.DetalleFacturas.FirstOrDefaultAsync(x => x.CodigoDetalle == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }
            var detalleFacturaDTO = mapper.Map<DetalleFacturaDTO>(detalleFactura);
            return detalleFacturaDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DetalleFacturaCreacionDTO detalleFacturaCreacion)
        {
            var detalleFactura = mapper.Map<DetalleFactura>(detalleFacturaCreacion);
            contexto.Add(detalleFactura);
            await contexto.SaveChangesAsync();
            var detalleFacturaDTO = mapper.Map<DetalleFacturaDTO>(detalleFactura);
            return new CreatedAtRouteResult("GetDetalleFactura", new { id = detalleFactura.CodigoDetalle },
                detalleFacturaDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DetalleFacturaCreacionDTO detalleFacturaActualizacion)
        {
            var detalleFactura = mapper.Map<DetalleFactura>(detalleFacturaActualizacion);
            detalleFactura.CodigoDetalle = id;
            contexto.Entry(detalleFactura).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DetalleFacturaDTO>> Delete(int id)
        {
            var codigoDetalle = await contexto.DetalleFacturas.Select(x => x.CodigoDetalle)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoDetalle == default(int))
            {
                return NotFound();
            }

            contexto.Remove(new DetalleFactura { CodigoDetalle = id });
            await contexto.SaveChangesAsync();
            return NoContent();
        }

    }
}
>>>>>>> 29338d71b197ae945ea06c6e121c117effba2864
