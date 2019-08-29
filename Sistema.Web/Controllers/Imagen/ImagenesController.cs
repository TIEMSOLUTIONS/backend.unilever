using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Imagen;
using Sistema.Web.Models.Imagen;

namespace Sistema.Web.Controllers.Imagen
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ImagenesController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Imagenes/listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ImagenViewModel>> listar()
        {
            var imagen = await _context.Imagenes.ToListAsync();
            return imagen.Select(c => new ImagenViewModel
            {
                idimagen = c.idimagen,
                nombre = c.nombre,
                imagen = c.imagen
            });
        }

        // GET: api/Categoria_perdida/SelectEspecifico/1
        [HttpGet("[action]/{idimagen}")]
        public async Task<IEnumerable<SeleccionarImagenViewModel>> SelectEspecifico(int idimagen)
        {
            var imagen = await _context.Imagenes.Where(c => c.idimagen == idimagen).ToListAsync();

            return imagen.Select(c => new SeleccionarImagenViewModel
            {
                idimagen = c.idimagen,
                nombre = c.nombre,
                imagen = c.imagen
            });

        }

        // GET: api/Imagenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Imagenes>> GetImagenes(int id)
        {
            var imagenes = await _context.Imagenes.FindAsync(id);

            if (imagenes == null)
            {
                return NotFound();
            }

            return imagenes;
        }

        // PUT: api/Imagenes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImagenes(int id, Imagenes imagenes)
        {
            if (id != imagenes.idimagen)
            {
                return BadRequest();
            }

            _context.Entry(imagenes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagenesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Imagenes/crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] ImagenViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Imagenes imagen = new Imagenes
            {
                nombre = model.nombre,
                imagen = model.imagen
            };

            _context.Imagenes.Add(imagen);
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

        // DELETE: api/Imagenes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Imagenes>> DeleteImagenes(int id)
        {
            var imagenes = await _context.Imagenes.FindAsync(id);
            if (imagenes == null)
            {
                return NotFound();
            }

            _context.Imagenes.Remove(imagenes);
            await _context.SaveChangesAsync();

            return imagenes;
        }

        private bool ImagenesExists(int id)
        {
            return _context.Imagenes.Any(e => e.idimagen == id);
        }
    }
}
