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

    public class ClienteController :ControllerBase
    {
        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;

        public ClienteController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
            var clientes = await contexto.Clientes.ToListAsync();
            var ClienteDTO = mapper.Map<List<ClienteDTO>>(clientes);
            return ClienteDTO;
        }

        [HttpGet("{id}", Name = "GetCliente")]
        public async Task<ActionResult<ClienteDTO>> Get(string id)
        {
            var cliente = await contexto.Clientes.FirstOrDefaultAsync(x => x.Nit == id);
            if (cliente == null)
            {
                return NotFound();
            }

            var ClienteDTO = mapper.Map<ClienteDTO>(cliente);
            return ClienteDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteCreacionDTO clienteCreacion)
        {
            var cliente = mapper.Map<Cliente>(clienteCreacion);
            contexto.Add(cliente);
            await contexto.SaveChangesAsync();
            var ClienteDTO = mapper.Map<ClienteDTO>(cliente);
            return  new CreatedAtRouteResult("GetCliente", new{id = cliente.Nit},
                ClienteDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] ClienteCreacionDTO clienteActualizacion)
        {
            var cliente = mapper.Map<Cliente>(clienteActualizacion);
            cliente.Nit = id;
            contexto.Entry(cliente).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteDTO>> Delete(string id)
        {
            var Nit = await contexto.Clientes.Select(x => x.Nit)
                .FirstOrDefaultAsync(x => x == id);
            if (Nit == default(string))
            {
                return NotFound();
            }

            contexto.Remove(new Cliente {Nit = id});
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

    public class ClienteController :ControllerBase
    {
        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;

        public ClienteController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
            var clientes = await contexto.Clientes.ToListAsync();
            var ClienteDTO = mapper.Map<List<ClienteDTO>>(clientes);
            return ClienteDTO;
        }

        [HttpGet("{id}", Name = "GetCliente")]
        public async Task<ActionResult<ClienteDTO>> Get(string id)
        {
            var cliente = await contexto.Clientes.FirstOrDefaultAsync(x => x.Nit == id);
            if (cliente == null)
            {
                return NotFound();
            }

            var ClienteDTO = mapper.Map<ClienteDTO>(cliente);
            return ClienteDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteCreacionDTO clienteCreacion)
        {
            var cliente = mapper.Map<Cliente>(clienteCreacion);
            contexto.Add(cliente);
            await contexto.SaveChangesAsync();
            var ClienteDTO = mapper.Map<ClienteDTO>(cliente);
            return  new CreatedAtRouteResult("GetCliente", new{id = cliente.Nit},
                ClienteDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] ClienteCreacionDTO clienteActualizacion)
        {
            var cliente = mapper.Map<Cliente>(clienteActualizacion);
            cliente.Nit = id;
            contexto.Entry(cliente).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteDTO>> Delete(string id)
        {
            var Nit = await contexto.Clientes.Select(x => x.Nit)
                .FirstOrDefaultAsync(x => x == id);
            if (Nit == default(string))
            {
                return NotFound();
            }

            contexto.Remove(new Cliente {Nit = id});
            await contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}
>>>>>>> 29338d71b197ae945ea06c6e121c117effba2864
