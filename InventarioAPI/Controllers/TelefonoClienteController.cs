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
    public class TelefonoClienteController : ControllerBase
    {

        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;

        public TelefonoClienteController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TelefonoClienteDTO>>> Get()
        {
            var telefonoCliente = await contexto.TelefonoClientes.ToListAsync();
            var telefonoClienteDTO = mapper.Map<List<TelefonoClienteDTO>>(telefonoCliente);
            return telefonoClienteDTO;
        }

        [HttpGet("{id}", Name = "GetTelefonoCliente")]
        public async Task<ActionResult<TelefonoClienteDTO>> Get(int id)
        {
            var telefonoCliente = await contexto.TelefonoClientes.FirstOrDefaultAsync(x => x.CodigoTelefono == id);
            if (telefonoCliente == null)
            {
                return NotFound();
            }
            var telefonoClienteDTO = mapper.Map<TelefonoClienteDTO>(telefonoCliente);
            return telefonoClienteDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TelefonoClienteDTO telefonoClienteCreacion)
        {
            var telefonoCliente = mapper.Map<TelefonoCliente>(telefonoClienteCreacion);
            contexto.Add(telefonoCliente);
            await contexto.SaveChangesAsync();
            var telefonoClienteDTO = mapper.Map<TelefonoClienteDTO>(telefonoCliente);
            return new CreatedAtRouteResult("GetTelefonoCliente", new { id = telefonoCliente.CodigoTelefono },
                telefonoClienteDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TelefonoClienteCreacionDTO telefonoClienteActualizacion)
        {
            var telefonoCliente = mapper.Map<TelefonoCliente>(telefonoClienteActualizacion);
            telefonoCliente.CodigoTelefono = id;
            contexto.Entry(telefonoCliente).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TelefonoClienteDTO>> Delete(int id)
        {
            var codigoTelefono = await contexto.TelefonoClientes.Select(x => x.CodigoTelefono)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoTelefono == default(int))
            {
                return NotFound();
            }

            contexto.Remove(new TelefonoCliente { CodigoTelefono = id });
            await contexto.SaveChangesAsync();
            return NoContent();
        }

    }
}
