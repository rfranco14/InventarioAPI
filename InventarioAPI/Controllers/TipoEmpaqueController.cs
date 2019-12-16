using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using InventarioAPI.Context;
using InventarioAPI.Entities;
using InventarioAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

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
            var tipoempaque = await this.contexto.TipoEmpaques.ToListAsync();
            var TipoEmpaqueDTO = this.mapper.Map<List<TipoEmpaqueDTO>>(tipoempaque);
            return TipoEmpaqueDTO;
        }

        [HttpGet("{numeroDePagina}", Name = "GetTipoEmpaquePage")]
        [Route("page/{numeroDePagina}")]
        public async Task<ActionResult<TipoEmpaquePaginacionDTO>> GetTipoEmpaquePage(int numeroDePagina = 0)
        {
            int cantidadDeRegistros = 5;
            var tipoEmpaquePaginacionDTO = new TipoEmpaquePaginacionDTO();
            var query = contexto.TipoEmpaques.AsQueryable();
            int totalDeRegistros = query.Count();
            int totalPaginas = (int)Math.Ceiling((Double)totalDeRegistros / cantidadDeRegistros);
            tipoEmpaquePaginacionDTO.Number = numeroDePagina;

            var tipoempaque = await query
                .Skip(cantidadDeRegistros * (tipoEmpaquePaginacionDTO.Number))
                .Take(cantidadDeRegistros)
                .ToListAsync();

            tipoEmpaquePaginacionDTO.TotalPages = totalPaginas;
            tipoEmpaquePaginacionDTO.Content = mapper.Map<List<TipoEmpaqueDTO>>(tipoempaque);

            if (numeroDePagina == 0)
            {
                tipoEmpaquePaginacionDTO.First = true;
            }
            else if (numeroDePagina == totalPaginas)
            {
                tipoEmpaquePaginacionDTO.Last = true;
            }
            return tipoEmpaquePaginacionDTO;
        }

        [HttpGet("{id}", Name = "GetTipoEmpaque")]
        public async Task<ActionResult<TipoEmpaqueDTO>> Get(int id)
        {
            var tipoempaque = await contexto.TipoEmpaques.FirstOrDefaultAsync(x => x.CodigoEmpaque == id);
            if (tipoempaque == null)
            {
                return NotFound();
            }
            var tipoEmpaqueDTO = mapper.Map<TipoEmpaqueDTO>(tipoempaque);
            return tipoEmpaqueDTO;

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
