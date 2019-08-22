using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Pamco;
using Sistema.Web.Models.Pamco.Categorias_perdidas;

namespace Sistema.Web.Controllers.Pamco
{
    [Route("api/[controller]")]
    [ApiController]
    public class Categoria_perdidaController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public Categoria_perdidaController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Categoria_perdida/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<Categoria_perdidaViewModel>> Listar()
        {
            var categoria_perdida = await _context.Categoria_perdida.Where(c => c.activo == true && c.eliminado == false).ToListAsync();
            return categoria_perdida.Select(c => new Categoria_perdidaViewModel
            {
                idcategoria = c.idcategoria,
                nombre = c.nombre,
                nivel = c.nivel,
                cat_padre = c.cat_padre,
                activo = c.activo,
                eliminado = c.eliminado
            });
        }
        // GET: api/Categoria_perdida/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectCategoriaPerdidaViewModel>> Select()
        {
            var categoriaPerdida = await _context.Categoria_perdida.Where(c => c.activo == true && c.eliminado == false).ToListAsync();

            return categoriaPerdida.Select(c => new SelectCategoriaPerdidaViewModel
            {
                idcategoria = c.idcategoria,
                nombre = c.nombre,
                nivel = c.nivel,
                cat_padre = c.cat_padre,
                activo = c.activo,
                eliminado = c.eliminado
            });

        }

        // GET: api/Categoria_perdida/mostrar/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Categoria_perdida>> mostrar(int id)
        {
            var categoria_perdida = await _context.Categoria_perdida.FindAsync(id);

            if (categoria_perdida == null)
            {
                return NotFound();
            }

            return Ok(new Categoria_perdidaViewModel {
                idcategoria = categoria_perdida.idcategoria,
                nombre = categoria_perdida.nombre,
                nivel = categoria_perdida.nivel,
                cat_padre = categoria_perdida.cat_padre,
                activo = categoria_perdida.activo,
                eliminado = categoria_perdida.eliminado
            });
        }

        // PUT: api/Categoria_perdida/actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarCategoriaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idcategoria <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.Categoria_perdida.FirstOrDefaultAsync(c => c.idcategoria == model.idcategoria);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.nombre = model.nombre;
            categoria.nivel = model.nivel;
            categoria.cat_padre = model.cat_padre;
            categoria.activo = model.activo;
            categoria.eliminado = model.eliminado;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Categoria_perdida/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearCategoria([FromBody] CreateCategoriaPerdidaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Categoria_perdida categoria = new Categoria_perdida
            {
                nombre = model.nombre,
                nivel = model.nivel,
                cat_padre = model.cat_padre,
                activo = true,
                eliminado = false
            };

            _context.Categoria_perdida.Add(categoria);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }

        // DELETE: api/Categoria_perdida/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = await _context.Categoria_perdida.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categoria_perdida.Remove(categoria);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok(categoria);
        }

        // PUT: api/Categoria_perdida/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.Categoria_perdida.FirstOrDefaultAsync(c => c.idcategoria == id);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.activo = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Categoria_perdida/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.Categoria_perdida.FirstOrDefaultAsync(c => c.idcategoria == id);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.activo = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest();
            }

            return Ok();
        }

        private bool Categoria_perdidaExists(int id)
        {
            return _context.Categoria_perdida.Any(e => e.idcategoria == id);
        }
    }
}
