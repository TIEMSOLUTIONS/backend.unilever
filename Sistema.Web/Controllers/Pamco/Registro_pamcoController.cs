using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Pamco;
using Sistema.Web.Models.Pamco.Registro_pamco;

namespace Sistema.Web.Controllers.Pamco
{
    [Route("api/[controller]")]
    [ApiController]
    public class Registro_pamcoController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public Registro_pamcoController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Registro_Pamco/listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<Registro_pamcoViewModel>> listar()
        {
            var registro_pamcos = await _context.Registro_Pamcos.Where(c => c.eliminado == false).ToListAsync();

            return registro_pamcos.Select(c => new Registro_pamcoViewModel
            {
                idpamco = c.idpamco,
                idcategoria = c.idcategoria,
                idusuario = c.idusuario,
                idmaquina = c.idmaquina,
                evento = c.evento,
                ts = c.ts.ToString("dd/MM/yyyy hh:mm:ss tt"),
                turno = c.turno,
                hora_inicio = c.hora_inicio,
                hora_final = c.hora_final,
                tiempo_total = c.tiempo_total,
                eliminado = c.eliminado
            });
        }

        // GET: api/Registro_Pamco/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectRegistroPamcoViewModel>> Select()
        {
            var categoriaPerdida = await _context.Registro_Pamcos.Where(c => c.eliminado == false).ToListAsync();

            return categoriaPerdida.Select(c => new SelectRegistroPamcoViewModel
            {
                idpamco = c.idpamco,
                idcategoria = c.idcategoria,
                idusuario = c.idusuario,
                idmaquina = c.idmaquina,
                evento = c.evento,
                ts = c.ts.ToString("dd/MM/yyyy hh:mm:ss tt"),
                turno = c.turno,
                hora_inicio = c.hora_inicio,
                hora_final = c.hora_final,
                tiempo_total = c.tiempo_total,
                eliminado = c.eliminado
            });

        }

        // GET: api/Registro_pamco/mostrar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Registro_pamco>> mostrar(int id)
        {
            var registro_pamco = await _context.Registro_Pamcos.FindAsync(id);

            if (registro_pamco == null)
            {
                return NotFound();
            }

            return Ok(new Registro_pamcoViewModel
            {
                idpamco = registro_pamco.idpamco,
                idcategoria = registro_pamco.idcategoria,
                idusuario = registro_pamco.idusuario,
                idmaquina = registro_pamco.idmaquina,
                evento = registro_pamco.evento,
                ts = registro_pamco.ts.ToString("dd/MM/yyyy hh:mm:ss tt"),
                turno = registro_pamco.turno,
                hora_inicio = registro_pamco.hora_inicio,
                hora_final = registro_pamco.hora_final,
                tiempo_total = registro_pamco.tiempo_total,
                eliminado = registro_pamco.eliminado
            });
        }

        // PUT: api/Registro_Pamco/actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarRegistroPamcoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idcategoria <= 0)
            {
                return BadRequest();
            }

            var registroPamco = await _context.Registro_Pamcos.FirstOrDefaultAsync(c => c.idpamco == model.idpamco);

            if (registroPamco == null)
            {
                return NotFound();
            }

            registroPamco.idpamco = model.idpamco;
            registroPamco.idcategoria = model.idcategoria;
            registroPamco.idusuario = model.idusuario;
            registroPamco.idmaquina = model.idmaquina;
            registroPamco.evento = model.evento;
            registroPamco.ts = model.ts;
            registroPamco.turno = model.turno;
            registroPamco.hora_inicio = model.hora_inicio;
            registroPamco.hora_final = model.hora_final;
            registroPamco.tiempo_total = model.tiempo_total;
            registroPamco.eliminado = model.eliminado;

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

        // POST: api/Registro_Pamco/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crearpamco([FromBody] CreateRegistroPamcoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechaHora = DateTime.Now;
            string fechaReco = "09/01/2007 10:00";
            DateTime fechaR = new DateTime();
            fechaR = DateTime.Parse(fechaReco);

            Registro_pamco registroPamco = new Registro_pamco
            {
                idcategoria = model.idcategoria,
                idusuario = model.idusuario,
                idmaquina = model.idmaquina,
                evento = model.evento,
                ts = fechaHora,
                turno = model.turno,
                hora_inicio = model.hora_inicio,
                hora_final = model.hora_final,
                tiempo_total = model.tiempo_total,
                eliminado = false
            };

            _context.Registro_Pamcos.Add(registroPamco);
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

        // DELETE: api/Registro_Pamco/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registroPamco = await _context.Registro_Pamcos.FindAsync(id);
            if (registroPamco == null)
            {
                return NotFound();
            }

            _context.Registro_Pamcos.Remove(registroPamco);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok(registroPamco);
        }

        private bool Registro_pamcoExists(int id)
        {
            return _context.Registro_Pamcos.Any(e => e.idpamco == id);
        }
    }
}
