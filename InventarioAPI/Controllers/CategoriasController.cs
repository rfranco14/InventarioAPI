<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InventarioAPI.Context;
using InventarioAPI.Entities;
using InventarioAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriasController : ControllerBase
    {

        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;

        public CategoriasController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var categorias = await this.contexto.Categorias.ToListAsync();
            var categoriaDTO = this.mapper.Map<List<CategoriaDTO>>(categorias);
            return categoriaDTO;
        }


        [HttpGet("{numeroDePagina}", Name = "GetCategoriasPage")]
        [Route("page/{numeroDePagina}")]
            public async Task<ActionResult<CategoriaPaginacionDTO>> GetCategoriasPage(int numeroDePagina = 0)
            {
            int cantidadDeRegistros = 5;
            var categoriaPaginacionDTO = new CategoriaPaginacionDTO();
            var query = contexto.Categorias.AsQueryable();
            int totalDeRegistros = query.Count();
            int totalPaginas = (int)Math.Ceiling((Double) totalDeRegistros / cantidadDeRegistros);
            categoriaPaginacionDTO.Number = numeroDePagina;

            var categorias = await query
                .Skip(cantidadDeRegistros * (categoriaPaginacionDTO.Number))
                .Take(cantidadDeRegistros)
                .ToListAsync();

            categoriaPaginacionDTO.TotalPages = totalPaginas;
            categoriaPaginacionDTO.Content = mapper.Map<List<CategoriaDTO>>(categorias);

            if (numeroDePagina == 0)
            {
                categoriaPaginacionDTO.First = true;
            }
            else if (numeroDePagina == totalPaginas)
            {
                categoriaPaginacionDTO.Last = true;
            }

            return categoriaPaginacionDTO;
        }

        [HttpGet ("{id}", Name = "GetCategoria")]
        public async Task<ActionResult<CategoriaDTO>> Get(int id)
        {
            var categoria = await contexto.Categorias.FirstOrDefaultAsync(x => x.CodigoCategoria == id);
            if (categoria == null)
            {
                return NotFound();
            }
            var categoriaDTO = mapper.Map<CategoriaDTO>(categoria);
            return categoriaDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post ([FromBody] CategoriaCreacionDTO categoriaCreacion)
        {
            var categoria = mapper.Map<Categoria>(categoriaCreacion);
            contexto.Add(categoria);
            await contexto.SaveChangesAsync();
            var categoriaDTO = mapper.Map<CategoriaDTO>(categoria);
            return new CreatedAtRouteResult("GetCategoria", new { id = categoria.CodigoCategoria }, 
                categoriaDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaCreacionDTO categoriaActualizacion)
        {
            var categoria = mapper.Map<Categoria>(categoriaActualizacion);
            categoria.CodigoCategoria = id;
            contexto.Entry(categoria).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int id)
        {
            var codigoCategoria = await contexto.Categorias.Select(x => x.CodigoCategoria)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoCategoria == default(int))
            {
                return NotFound();
            }

            contexto.Remove(new Categoria {CodigoCategoria = id});
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
    public class CategoriasController : ControllerBase
    {
 
            private readonly InventarioDBContext contexto;
            private readonly IMapper mapper;

            public CategoriasController(InventarioDBContext contexto, IMapper mapper)
            {
                this.contexto = contexto;
                this.mapper = mapper;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
            {
            var categorias = await contexto.Categorias.ToListAsync();
            var categoriasDTO = mapper.Map<List<CategoriaDTO>>(categorias);
            return categoriasDTO;
            }

        [HttpGet ("{id}", Name = "GetCategoria")]
        public async Task<ActionResult<CategoriaDTO>> Get(int id)
        {
            var categoria = await contexto.Categorias.FirstOrDefaultAsync(x => x.CodigoCategoria == id);
            if (categoria == null)
            {
                return NotFound();
            }
            var categoriaDTO = mapper.Map<CategoriaDTO>(categoria);
            return categoriaDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post ([FromBody] CategoriaCreacionDTO categoriaCreacion)
        {
            var categoria = mapper.Map<Categoria>(categoriaCreacion);
            contexto.Add(categoria);
            await contexto.SaveChangesAsync();
            var categoriaDTO = mapper.Map<CategoriaDTO>(categoria);
            return new CreatedAtRouteResult("GetCategoria", new { id = categoria.CodigoCategoria }, 
                categoriaDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaCreacionDTO categoriaActualizacion)
        {
            var categoria = mapper.Map<Categoria>(categoriaActualizacion);
            categoria.CodigoCategoria = id;
            contexto.Entry(categoria).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int id)
        {
            var codigoCategoria = await contexto.Categorias.Select(x => x.CodigoCategoria)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoCategoria == default(int))
            {
                return NotFound();
            }

            contexto.Remove(new Categoria {CodigoCategoria = id});
            await contexto.SaveChangesAsync();
            return NoContent();
        }

    }
}
>>>>>>> 29338d71b197ae945ea06c6e121c117effba2864
