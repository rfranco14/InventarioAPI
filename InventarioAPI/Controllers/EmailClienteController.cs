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
    public class EmailClienteController : ControllerBase
    {

        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;

        public EmailClienteController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailClienteDTO>>> Get()
        {
            var emailCliente = await contexto.EmailClientes.ToListAsync();
            var emailClienteDTO = mapper.Map<List<EmailClienteDTO>>(emailCliente);
            return emailClienteDTO;
        }

        [HttpGet("{numeroDePagina}", Name = "GetEmailClientePage")]
        [Route("page/{numeroDePagina}")]
        public async Task<ActionResult<EmailClientePaginacionDTO>> GetEmailClientePage(int numeroDePagina = 0)
        {
            int cantidadDeRegistros = 5;
            var emailClientePaginacionDTO = new EmailClientePaginacionDTO();
            var query = contexto.EmailClientes.AsQueryable();
            int totalDeRegistros = query.Count();
            int totalPaginas = (int)Math.Ceiling((Double)totalDeRegistros / cantidadDeRegistros);
            emailClientePaginacionDTO.Number = numeroDePagina;

            var emailcliente = await query
                .Skip(cantidadDeRegistros * (emailClientePaginacionDTO.Number))
                .Take(cantidadDeRegistros)
                .ToListAsync();

            emailClientePaginacionDTO.TotalPages = totalPaginas;
            emailClientePaginacionDTO.Content = mapper.Map<List<EmailClienteDTO>>(emailcliente);

            if (numeroDePagina == 0)
            {
                emailClientePaginacionDTO.First = true;
            }
            else if (numeroDePagina == totalPaginas)
            {
                emailClientePaginacionDTO.Last = true;
            }
            return emailClientePaginacionDTO;
        }

        [HttpGet("{id}", Name = "GetEmailCliente")]
        public async Task<ActionResult<EmailClienteDTO>> Get(int id)
        {
            var emailCliente = await contexto.EmailClientes.FirstOrDefaultAsync(x => x.CodigoEmail == id);
            if (emailCliente == null)
            {
                return NotFound();
            }
            var emailClienteDTO = mapper.Map<EmailClienteDTO>(emailCliente);
            return emailClienteDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmailClienteCreacionDTO emailClienteCreacion)
        {
            var emailCliente = mapper.Map<EmailCliente>(emailClienteCreacion);
            contexto.Add(emailCliente);
            await contexto.SaveChangesAsync();
            var emailClienteDTO = mapper.Map<EmailClienteDTO>(emailCliente);
            return new CreatedAtRouteResult("GetEmailCliente", new { id = emailCliente.CodigoEmail },
                emailClienteDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmailClienteCreacionDTO emailClienteActualizacion)
        {
            var emailCliente = mapper.Map<EmailCliente>(emailClienteActualizacion);
            emailCliente.CodigoEmail = id;
            contexto.Entry(emailCliente).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmailClienteDTO>> Delete(int id)
        {
            var codigoEmail = await contexto.EmailClientes.Select(x => x.CodigoEmail)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoEmail == default(int))
            {
                return NotFound();
            }

            contexto.Remove(new EmailCliente { CodigoEmail = id });
            await contexto.SaveChangesAsync();
            return NoContent();
        }

    }
}
