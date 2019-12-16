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
    public class TelefonoProveedorController : ControllerBase
    {

        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;

        public TelefonoProveedorController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TelefonoProveedorDTO>>> Get()
        {
            var telefonoProveedor = await contexto.TelefonoProveedores.ToListAsync();
            var telefonoProveedorDTO = mapper.Map<List<TelefonoProveedorDTO>>(telefonoProveedor);
            return telefonoProveedorDTO;
        }

        [HttpGet("{id}", Name = "GetTelefonoProveedor")]
        public async Task<ActionResult<TelefonoProveedorDTO>> Get(int id)
        {
            var telefonoProveedor = await contexto.TelefonoProveedores.FirstOrDefaultAsync(x => x.CodigoTelefono == id);
            if (telefonoProveedor == null)
            {
                return NotFound();
            }
            var telefonoProveedorDTO = mapper.Map<TelefonoProveedorDTO>(telefonoProveedor);
            return telefonoProveedorDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TelefonoProveedorCreacionDTO telefonoProveedorCreacion)
        {
            var telefonoProveedor = mapper.Map<TelefonoProveedor>(telefonoProveedorCreacion);
            contexto.Add(telefonoProveedor);
            await contexto.SaveChangesAsync();
            var ctelefonoProveedorDTO = mapper.Map<TelefonoProveedorDTO>(telefonoProveedor);
            return new CreatedAtRouteResult("GetTelefonoProveedor", new { id = telefonoProveedor.CodigoTelefono },
                ctelefonoProveedorDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TelefonoProveedorCreacionDTO telefonoProveedorActualizacion)
        {
            var telefonoProveedor = mapper.Map<TelefonoProveedor>(telefonoProveedorActualizacion);
            telefonoProveedor.CodigoTelefono = id;
            contexto.Entry(telefonoProveedor).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TelefonoProveedorDTO>> Delete(int id)
        {
            var codigoTelefono = await contexto.TelefonoProveedores.Select(x => x.CodigoTelefono)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoTelefono == default(int))
            {
                return NotFound();
            }

            contexto.Remove(new TelefonoProveedor { CodigoTelefono = id });
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
    public class TelefonoProveedorController : ControllerBase
    {

        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;

        public TelefonoProveedorController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TelefonoProveedorDTO>>> Get()
        {
            var telefonoProveedor = await contexto.TelefonoProveedores.ToListAsync();
            var telefonoProveedorDTO = mapper.Map<List<TelefonoProveedorDTO>>(telefonoProveedor);
            return telefonoProveedorDTO;
        }

        [HttpGet("{id}", Name = "GetTelefonoProveedor")]
        public async Task<ActionResult<TelefonoProveedorDTO>> Get(int id)
        {
            var telefonoProveedor = await contexto.TelefonoProveedores.FirstOrDefaultAsync(x => x.CodigoTelefono == id);
            if (telefonoProveedor == null)
            {
                return NotFound();
            }
            var telefonoProveedorDTO = mapper.Map<TelefonoProveedorDTO>(telefonoProveedor);
            return telefonoProveedorDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TelefonoProveedorCreacionDTO telefonoProveedorCreacion)
        {
            var telefonoProveedor = mapper.Map<TelefonoProveedor>(telefonoProveedorCreacion);
            contexto.Add(telefonoProveedor);
            await contexto.SaveChangesAsync();
            var ctelefonoProveedorDTO = mapper.Map<TelefonoProveedorDTO>(telefonoProveedor);
            return new CreatedAtRouteResult("GetTelefonoProveedor", new { id = telefonoProveedor.CodigoTelefono },
                ctelefonoProveedorDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TelefonoProveedorCreacionDTO telefonoProveedorActualizacion)
        {
            var telefonoProveedor = mapper.Map<TelefonoProveedor>(telefonoProveedorActualizacion);
            telefonoProveedor.CodigoTelefono = id;
            contexto.Entry(telefonoProveedor).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TelefonoProveedorDTO>> Delete(int id)
        {
            var codigoTelefono = await contexto.TelefonoProveedores.Select(x => x.CodigoTelefono)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoTelefono == default(int))
            {
                return NotFound();
            }

            contexto.Remove(new TelefonoProveedor { CodigoTelefono = id });
            await contexto.SaveChangesAsync();
            return NoContent();
        }

    }
}
>>>>>>> 29338d71b197ae945ea06c6e121c117effba2864
