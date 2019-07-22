using System;
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

    public class TipoEmpaqueController : ControllerBase
    {
        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;

        public TipoEmpaqueController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoEmpaqueDTO>>> Get()
        {
            var tipoempaque = await contexto.TipoEmpaques.ToListAsync();
            var TipoEmpaqueDTO = mapper.Map<List<TipoEmpaqueDTO>>(tipoempaque);
            return TipoEmpaqueDTO;
        }

        [HttpGet("{id}", Name="GetTipoEmpaque")]

        public async Task<ActionResult<TipoEmpaqueDTO>> Get(int id)
        {
            var tipoempaque = await contexto.TipoEmpaques.FirstOrDefaultAsync(x => x.CodigoEmpaque == id);
            if (tipoempaque == null)
            {
                return NotFound();
            }

            var TipoEmpaqueDTO = mapper.Map<TipoEmpaqueDTO>(tipoempaque);
            return TipoEmpaqueDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoEmpaqueCreacionDTO tipoempaqueCreacion)
        {
            var tipoempaque = mapper.Map<TipoEmpaque>(tipoempaqueCreacion);
            contexto.Add(tipoempaque);
            await contexto.SaveChangesAsync();
            var TipoEmpaqueDTO = mapper.Map<TipoEmpaqueDTO>(tipoempaque);
            return new CreatedAtRouteResult("GetTipoEmpaque", new {id = tipoempaque.CodigoEmpaque}, TipoEmpaqueDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TipoEmpaqueCreacionDTO tipoEmpaqueActualizacion)
        {
            var tipoempaque = mapper.Map<TipoEmpaque>(tipoEmpaqueActualizacion);
            tipoempaque.CodigoEmpaque = id;
            contexto.Entry(tipoempaque).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoEmpaqueDTO>> Delete(int id)
        {
            var codigoTipoEmpaque = await contexto.TipoEmpaques.Select(x => x.CodigoEmpaque)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoTipoEmpaque == default(int))
            {
                return NotFound();
            }

            contexto.Remove(new TipoEmpaque {CodigoEmpaque = id});
            await contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}
