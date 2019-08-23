using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Wcm._1_N;
using Sistema.Web.Controllers.CalculosAuxliares;
using Sistema.Web.Models.Wcm._1_N.RegistroShe;

namespace Sistema.Web.Controllers.Wcm._1_N
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosShesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public RegistrosShesController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/RegistrosShes/Listar
        // [Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<RegistroSheViewModel>> Listar()
        {
            List<RegistroShe> she = await _context.Registrosshe
                .Include(i => i.usuarioshe)
                .Include(i => i.usuariotecnicoshe)
                .Include(i => i.usuariosupervisorshe)
                .Include(i => i.area)
                .Include(i => i.maquina)
                .Include(i => i.condicionInsegura)
                .Include(i => i.Falla)
                .Where(i => i.confirmacion_tec == false)
                .Where(i => i.idtecnico == 2)
                .OrderByDescending(i => i.idregistroshe)
                .Take(100)
                .ToListAsync();

            return she.Select(i => new RegistroSheViewModel
            {
                idregistroshe = i.idregistroshe,
                //idproveedor = i.idproveedor,
                //proveedor = i.persona.nombre,
                codigo = i.codigo,
                nombre = i.nombre,
                emision_ts = i.emision_ts.ToString("dd/MM/yyyy hh:mm:ss tt"),
                idusuario = i.idusuario,
                usuario = i.usuarioshe.nombre,
                prioridad=i.prioridad,
                turno = i.turno,
                hora_reporte=i.hora_reporte.ToString("hh:mm:ss tt"),
                idarea = i.idarea,
                area = i.area.nombre,
                idmaquina = i.idmaquina,
                maquina = i.maquina.nombre,
                she_ma=i.she_ma,
                paro_equipo = i.paro_equipo,
                idfalla=i.idfalla,
                falla=i.Falla.nombre,
                idcondicion=i.idcondicion,
                condicioinsegura=i.condicionInsegura.nombre,
                descripcion = i.descripcion,
                ope_mtto=i.ope_mtto,
                sol_implementada = i.sol_implementada,
                ejecucion_ts = i.ejecucion_ts,
                idtecnico = i.idtecnico,
                usuariotecnico = i.usuariotecnicoshe.nombre,
                confirmacion_tec = i.confirmacion_tec,
                idsupervisor = i.idsupervisor,
                usuariosupervisor = i.usuariosupervisorshe.nombre,
                confirmacion_super = i.confirmacion_super,
                cierre_ts = i.cierre_ts,
                observaciones = i.observaciones,
                prog = i.prog,
                foto = i.foto
            });


        }
        // POST: api/RegistrosShes/CrearShe
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearShe([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DateTime fechaHora = DateTime.Now;
            string fechaReco = "09/01/2007 10:00";
            DateTime fechaR = new DateTime();
            fechaR = DateTime.Parse(fechaReco);

            TurnoActual turnoactual = new TurnoActual();

            RegistroShe she = new RegistroShe
            {
                nombre = model.nombre,
                emision_ts = fechaHora,
                idusuario = model.idusuario,
                prioridad=model.prioridad,
                turno = turnoactual.TurnoActualSystema(),
                hora_reporte= fechaHora,
                idarea = model.idarea,
                idmaquina = model.idmaquina,
                she_ma=model.she_ma,
                paro_equipo = model.paro_equipo,
                idfalla = model.idfalla,
                idcondicion = model.idcondicion,
                descripcion = model.descripcion,
                ope_mtto=model.ope_mtto,
                sol_implementada = model.sol_implementada,
                ejecucion_ts = fechaR,
                cierre_ts = fechaR,
                idtecnico = model.idtecnico,
                confirmacion_tec = model.confirmacion_tec,
                idsupervisor = model.idsupervisor,
                confirmacion_super = model.confirmacion_super,
                observaciones = model.observaciones,
                prog = model.prog,
                eliminado = false
            };

            _context.Registrosshe.Add(she);
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
        // PUT: api/RegistrosShes/AsignarTecnico
        [HttpPut("[action]")]
        public async Task<IActionResult> AsignarTecnico([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idregistroshe <= 0)
            {
                return BadRequest();
            }

            RegistroShe she = await _context.Registrosshe.FirstOrDefaultAsync(c => c.idregistroshe == model.idregistroshe);

            if (she == null)
            {
                return NotFound();
            }

            she.idtecnico = model.idtecnico;

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

        private bool RegistroSheExists(int id)
        {
            return _context.Registrosshe.Any(e => e.idregistroshe == id);
        }
    }
}
