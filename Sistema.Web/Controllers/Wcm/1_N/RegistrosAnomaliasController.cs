//MODIFICADO 12/08/2019 ff
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Wcm._1_N;
using Sistema.Web.Controllers.CalculosAuxliares;
using Sistema.Web.Models.Wcm._1_N.RegistroAnomalia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Controllers.Wcm._1_N
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosAnomaliasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public RegistrosAnomaliasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/RegistrosAnomalias/Listar
        // [Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<RegistroAnomaliaViewModel>> Listar()
        {
            List<RegistroAnomalia> anomalia = await _context.Registrosanomalias
                .Include(i => i.usuario)
                .Include(i => i.usuariotecnico)
                .Include(i => i.usuariosupervisor)
                .Include(i => i.area)
                .Include(i => i.maquina)
                .Include(i => i.anomalia)
                .Include(i => i.suceso)
                .Include(i => i.tarjeta)
                .OrderByDescending(i => i.idregistroanomalia)
                .Take(100)
                .ToListAsync();

            return anomalia.Select(i => new RegistroAnomaliaViewModel
            {
                idregistroanomalia = i.idregistroanomalia,
                //idproveedor = i.idproveedor,
                //proveedor = i.persona.nombre,
                codigo = i.codigo,
                nombre = i.nombre,
                emision_ts = i.emision_ts.ToString("dd/MM/yyyy hh:mm:ss tt"),
                idusuario = i.idusuario,
                usuario = i.usuario.nombre,
                paso_ma = i.paso_ma,
                criticidad = i.criticidad,
                turno = i.turno,
                idarea = i.idarea,
                area = i.area.nombre,
                idmaquina = i.idmaquina,
                maquina = i.maquina.nombre,
                idanomalia = i.idanomalia,
                anomaliac = i.anomalia.nombre,
                idsuceso = i.idsuceso,
                relacionado = i.suceso.nombre,
                idtarjeta = i.idtarjeta,
                tarjeta = i.tarjeta.nombre,
                descripcion = i.descripcion,
                sol_implementada = i.sol_implementada,
                ejecucion_ts = i.ejecucion_ts,
                idtecnico = i.idtecnico,
                usuariotecnico = i.usuariotecnico.nombre,
                confirmacion_tec = i.confirmacion_tec,
                idsupervisor = i.idsupervisor,
                usuariosupervisor = i.usuariosupervisor.nombre,
                confirmacion_super = i.confirmacion_super,
                cierre_ts = i.cierre_ts,
                observaciones = i.observaciones,
                prog = i.prog,
                foto = i.foto
            });


        }
        // GET: api/RegistrosAnomalias/ListarTipoTarjeta   por id
        // [Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<RegistroAnomaliaViewModel>> ListarTipoTarjeta([FromRoute] int id)
        {
            List<RegistroAnomalia> anomalia = await _context.Registrosanomalias
                .Include(i => i.usuario)
                .Include(i => i.usuariotecnico)
                .Include(i => i.usuariosupervisor)
                .Include(i => i.area)
                .Include(i => i.maquina)
                .Include(i => i.anomalia)
                .Include(i => i.suceso)
                .Include(i => i.tarjeta)
                .Where(i => i.idtarjeta == id)
                .Where(i => i.confirmacion_tec == false)
                .Where(i => i.confirmacion_super == false)
                .OrderByDescending(i => i.idregistroanomalia)
                .Take(100)
                .ToListAsync();

            return anomalia.Select(i => new RegistroAnomaliaViewModel
            {
                idregistroanomalia = i.idregistroanomalia,
                //idproveedor = i.idproveedor,
                //proveedor = i.persona.nombre,
                codigo = i.codigo,
                nombre = i.nombre,
                emision_ts = i.emision_ts.ToString("dd/MM/yyyy hh:mm:ss tt"),
                idusuario = i.idusuario,
                usuario = i.usuario.nombre,
                paso_ma = i.paso_ma,
                criticidad = i.criticidad,
                turno = i.turno,
                idarea = i.idarea,
                area = i.area.nombre,
                idmaquina = i.idmaquina,
                maquina = i.maquina.nombre,
                idanomalia = i.idanomalia,
                anomaliac = i.anomalia.nombre,
                idsuceso = i.idsuceso,
                relacionado = i.suceso.nombre,
                idtarjeta = i.idtarjeta,
                tarjeta = i.tarjeta.nombre,
                descripcion = i.descripcion,
                sol_implementada = i.sol_implementada,
                ejecucion_ts = i.ejecucion_ts,
                idtecnico = i.idtecnico,
                usuariotecnico = i.usuariotecnico.nombre,
                confirmacion_tec = i.confirmacion_tec,
                idsupervisor = i.idsupervisor,
                usuariosupervisor = i.usuariosupervisor.nombre,
                confirmacion_super = i.confirmacion_super,
                cierre_ts = i.cierre_ts,
                observaciones = i.observaciones,
                prog = i.prog,
                foto = i.foto
            });


        }
        // GET: api/RegistrosAnomalias/ListarTecnico
        // [Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<RegistroAnomaliaViewModel>> ListarTecnico()
        {
            List<RegistroAnomalia> anomalia = await _context.Registrosanomalias
                .Include(i => i.usuario)
                .Include(i => i.usuariotecnico)
                .Include(i => i.usuariosupervisor)
                .Include(i => i.area)
                .Include(i => i.maquina)
                .Include(i => i.anomalia)
                .Include(i => i.suceso)
                .Include(i => i.tarjeta)
                .Where(i => i.confirmacion_tec == false)
                 .Where(i => i.idtecnico == 2)
                .OrderByDescending(i => i.idregistroanomalia)
                .Take(100)
                .ToListAsync();

            return anomalia.Select(i => new RegistroAnomaliaViewModel
            {
                idregistroanomalia = i.idregistroanomalia,
                //idproveedor = i.idproveedor,
                //proveedor = i.persona.nombre,
                codigo = i.codigo,
                nombre = i.nombre,
                emision_ts = i.emision_ts.ToString("dd/MM/yyyy hh:mm:ss tt"),
                idusuario = i.idusuario,
                usuario = i.usuario.nombre,
                paso_ma = i.paso_ma,
                criticidad = i.criticidad,
                turno = i.turno,
                idarea = i.idarea,
                area = i.area.nombre,
                idmaquina = i.idmaquina,
                maquina = i.maquina.nombre,
                idanomalia = i.idanomalia,
                anomaliac = i.anomalia.nombre,
                idsuceso = i.idsuceso,
                relacionado = i.suceso.nombre,
                idtarjeta = i.idtarjeta,
                tarjeta = i.tarjeta.nombre,
                descripcion = i.descripcion,
                sol_implementada = i.sol_implementada,
                ejecucion_ts = i.ejecucion_ts,
                idtecnico = i.idtecnico,
                usuariotecnico = i.usuariotecnico.nombre,
                confirmacion_tec = i.confirmacion_tec,
                idsupervisor = i.idsupervisor,
                usuariosupervisor = i.usuariosupervisor.nombre,
                confirmacion_super = i.confirmacion_super,
                cierre_ts = i.cierre_ts,
                observaciones = i.observaciones,
                prog = i.prog,
                foto = i.foto
            });


        }
        // POST: api/RegistrosAnomalias/CrearAnomalias
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearAnomalias([FromBody] CrearViewModel model)
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
           
            RegistroAnomalia anomalia = new RegistroAnomalia
            {
                nombre = model.nombre,
                emision_ts = fechaHora,
                idusuario = model.idusuario,
                paso_ma = model.paso_ma,
                criticidad = model.criticidad,
                turno = turnoactual.TurnoActualSystema(),
                idarea = model.idarea,
                idmaquina = model.idmaquina,
                idanomalia = model.idanomalia,
                idsuceso = model.idsuceso,
                idtarjeta = model.idtarjeta,
                descripcion = model.descripcion,
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

            _context.Registrosanomalias.Add(anomalia);
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

        // PUT: api/RegistrosAnomalias/AsignarTecnico
        [HttpPut("[action]")]
        public async Task<IActionResult> AsignarTecnico([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idregistroanomalia <= 0)
            {
                return BadRequest();
            }

            RegistroAnomalia anomalia = await _context.Registrosanomalias.FirstOrDefaultAsync(c => c.idregistroanomalia == model.idregistroanomalia);

            if (anomalia == null)
            {
                return NotFound();
            }

            anomalia.idtecnico = model.idtecnico;

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

        //datos de entrada
        // GET: api/RegistrosAnomalias/SelectListaTecnico
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<SelectViewModel>> SelectListaTecnico([FromRoute] int id)
        {
            List<RegistroAnomalia> anomalia = await _context.Registrosanomalias
                 .Include(i => i.usuario)
                 .Include(i => i.usuariotecnico)
                 .Include(i => i.usuariosupervisor)
                 .Include(i => i.area)
                 .Include(i => i.maquina)
                 .Include(i => i.anomalia)
                 .Include(i => i.suceso)
                 .Include(i => i.tarjeta)
                 .Where(i => i.confirmacion_tec == false)
                 .Where(i => i.idtecnico == id)
                 .OrderByDescending(i => i.idregistroanomalia)
                 .Take(100)
                 .ToListAsync();

            return anomalia.Select(i => new SelectViewModel
            {
                idregistroanomalia = i.idregistroanomalia,
                //idproveedor = i.idproveedor,
                //proveedor = i.persona.nombre,
                codigo = i.codigo,
                nombre = i.nombre,
                emision_ts = i.emision_ts.ToString("dd/MM/yyyy hh:mm:ss tt"),
                idusuario = i.idusuario,
                usuario = i.usuario.nombre,
                paso_ma = i.paso_ma,
                criticidad = i.criticidad,
                turno = i.turno,
                idarea = i.idarea,
                area = i.area.nombre,
                idmaquina = i.idmaquina,
                maquina = i.maquina.nombre,
                idanomalia = i.idanomalia,
                anomaliac = i.anomalia.nombre,
                idsuceso = i.idsuceso,
                relacionado = i.suceso.nombre,
                idtarjeta = i.idtarjeta,
                tarjeta = i.tarjeta.nombre,
                descripcion = i.descripcion,
                sol_implementada = i.sol_implementada,
                ejecucion_ts = i.ejecucion_ts.ToString("dd/MM/yyyy hh:mm:ss tt"),
                idtecnico = i.idtecnico,
                usuariotecnico = i.usuariotecnico.nombre,
                confirmacion_tec = i.confirmacion_tec,
                idsupervisor = i.idsupervisor,
                usuariosupervisor = i.usuariosupervisor.nombre,
                confirmacion_super = i.confirmacion_super,
                cierre_ts = i.cierre_ts.ToString("dd/MM/yyyy hh:mm:ss tt"),
                observaciones = i.observaciones,
                prog = i.prog,
                foto = i.foto

            });
        }

        // GET: api/RegistrosAnomalias/SelectListaTecnicoPropios
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<SelectViewModel>> SelectListaTecnicoPropios([FromRoute] int id)
        {
            List<RegistroAnomalia> anomalia = await _context.Registrosanomalias
                 .Include(i => i.usuario)
                 .Include(i => i.usuariotecnico)
                 .Include(i => i.usuariosupervisor)
                 .Include(i => i.area)
                 .Include(i => i.maquina)
                 .Include(i => i.anomalia)
                 .Include(i => i.suceso)
                 .Include(i => i.tarjeta)
                 .Where(i => i.confirmacion_tec == false)
                 .Where(i => i.idusuario == id || i.idtecnico == id)
                 .OrderByDescending(i => i.idregistroanomalia)
                 .Take(100)
                 .ToListAsync();

            return anomalia.Select(i => new SelectViewModel
            {
                idregistroanomalia = i.idregistroanomalia,
                //idproveedor = i.idproveedor,
                //proveedor = i.persona.nombre,
                codigo = i.codigo,
                nombre = i.nombre,
                emision_ts = i.emision_ts.ToString("dd/MM/yyyy hh:mm:ss tt"),
                idusuario = i.idusuario,
                usuario = i.usuario.nombre,
                paso_ma = i.paso_ma,
                criticidad = i.criticidad,
                turno = i.turno,
                idarea = i.idarea,
                area = i.area.nombre,
                idmaquina = i.idmaquina,
                maquina = i.maquina.nombre,
                idanomalia = i.idanomalia,
                anomaliac = i.anomalia.nombre,
                idsuceso = i.idsuceso,
                relacionado = i.suceso.nombre,
                idtarjeta = i.idtarjeta,
                tarjeta = i.tarjeta.nombre,
                descripcion = i.descripcion,
                sol_implementada = i.sol_implementada,
                ejecucion_ts = i.ejecucion_ts.ToString("dd/MM/yyyy hh:mm:ss tt"),
                idtecnico = i.idtecnico,
                usuariotecnico = i.usuariotecnico.nombre,
                confirmacion_tec = i.confirmacion_tec,
                idsupervisor = i.idsupervisor,
                usuariosupervisor = i.usuariosupervisor.nombre,
                confirmacion_super = i.confirmacion_super,
                cierre_ts = i.cierre_ts.ToString("dd/MM/yyyy hh:mm:ss tt"),
                observaciones = i.observaciones,
                prog = i.prog,
                foto = i.foto

            });
        }
        // GET: api/RegistrosAnomalias/SelectListaSupervisor
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> SelectListaSupervisor()
        {
            List<RegistroAnomalia> anomalia = await _context.Registrosanomalias
                 .Include(i => i.usuario)
                 .Include(i => i.usuariotecnico)
                 .Include(i => i.usuariosupervisor)
                 .Include(i => i.area)
                 .Include(i => i.maquina)
                 .Include(i => i.anomalia)
                 .Include(i => i.suceso)
                 .Include(i => i.tarjeta)
                 .Where(i => i.confirmacion_tec == true)
                 //.Where(i => i.idusuario == id || i.idtecnico == id)
                 .OrderByDescending(i => i.idregistroanomalia)
                 .Take(100)
                 .ToListAsync();

            return anomalia.Select(i => new SelectViewModel
            {
                idregistroanomalia = i.idregistroanomalia,
                //idproveedor = i.idproveedor,
                //proveedor = i.persona.nombre,
                codigo = i.codigo,
                nombre = i.nombre,

                emision_ts = i.emision_ts.ToString("dd/MM/yyyy hh:mm:ss tt"),
                idusuario = i.idusuario,
                usuario = i.usuario.nombre,
                paso_ma = i.paso_ma,
                criticidad = i.criticidad,
                turno = i.turno,
                idarea = i.idarea,
                area = i.area.nombre,
                idmaquina = i.idmaquina,
                maquina = i.maquina.nombre,
                idanomalia = i.idanomalia,
                anomaliac = i.anomalia.nombre,
                idsuceso = i.idsuceso,
                relacionado = i.suceso.nombre,
                idtarjeta = i.idtarjeta,
                tarjeta = i.tarjeta.nombre,
                descripcion = i.descripcion,
                sol_implementada = i.sol_implementada,
                ejecucion_ts = i.ejecucion_ts.ToString("dd/MM/yyyy hh:mm:ss tt"),
                idtecnico = i.idtecnico,
                usuariotecnico = i.usuariotecnico.nombre,
                confirmacion_tec = i.confirmacion_tec,
                idsupervisor = i.idsupervisor,
                usuariosupervisor = i.usuariosupervisor.nombre,
                confirmacion_super = i.confirmacion_super,
                cierre_ts = i.cierre_ts.ToString("dd/MM/yyyy hh:mm:ss tt"),
                observaciones = i.observaciones,
                prog = i.prog,
                foto = i.foto

            });
        }

        // GET: api/RegistrosAnomalias/SelectListaTecnicoPropiosConfirmado
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<SelectViewModel>> SelectListaTecnicoPropiosConfirmado([FromRoute] int id)
        {
            List<RegistroAnomalia> anomalia = await _context.Registrosanomalias
                 .Include(i => i.usuario)
                 .Include(i => i.usuariotecnico)
                 .Include(i => i.usuariosupervisor)
                 .Include(i => i.area)
                 .Include(i => i.maquina)
                 .Include(i => i.anomalia)
                 .Include(i => i.suceso)
                 .Include(i => i.tarjeta)
                 .Where(i => i.confirmacion_tec == true)
                 .Where(i => i.idusuario == id || i.idtecnico == id)
                 .OrderByDescending(i => i.idregistroanomalia)
                 .Take(100)
                 .ToListAsync();

            return anomalia.Select(i => new SelectViewModel
            {
                idregistroanomalia = i.idregistroanomalia,
                //idproveedor = i.idproveedor,
                //proveedor = i.persona.nombre,
                codigo = i.codigo,
                nombre = i.nombre,
                emision_ts = i.emision_ts.ToString("dd/MM/yyyy hh:mm:ss tt"),
                idusuario = i.idusuario,
                usuario = i.usuario.nombre,
                paso_ma = i.paso_ma,
                criticidad = i.criticidad,
                turno = i.turno,
                idarea = i.idarea,
                area = i.area.nombre,
                idmaquina = i.idmaquina,
                maquina = i.maquina.nombre,
                idanomalia = i.idanomalia,
                anomaliac = i.anomalia.nombre,
                idsuceso = i.idsuceso,
                relacionado = i.suceso.nombre,
                idtarjeta = i.idtarjeta,
                tarjeta = i.tarjeta.nombre,
                descripcion = i.descripcion,
                sol_implementada = i.sol_implementada,
                ejecucion_ts = i.ejecucion_ts.ToString("dd/MM/yyyy hh:mm:ss tt"),
                idtecnico = i.idtecnico,
                usuariotecnico = i.usuariotecnico.nombre,
                confirmacion_tec = i.confirmacion_tec,
                idsupervisor = i.idsupervisor,
                usuariosupervisor = i.usuariosupervisor.nombre,
                confirmacion_super = i.confirmacion_super,
                cierre_ts = i.cierre_ts.ToString("dd/MM/yyyy hh:mm:ss tt"),
                observaciones = i.observaciones,
                prog = i.prog,
                foto = i.foto

            });
        }
        // PUT: api/RegistrosAnomalias/AplicarContramedida
        [HttpPut("[action]")]
        public async Task<IActionResult> AplicarContramedida([FromBody] ActualizarViewModelContramedida model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idregistroanomalia <= 0)
            {
                return BadRequest();
            }

            RegistroAnomalia anomalia = await _context.Registrosanomalias.FirstOrDefaultAsync(c => c.idregistroanomalia == model.idregistroanomalia);

            if (anomalia == null)
            {
                return NotFound();
            }
            DateTime fechaHora = DateTime.Now;

            anomalia.sol_implementada = model.sol_implementada;
            anomalia.ejecucion_ts = fechaHora;
            anomalia.idtecnico = model.idtecnico;
            anomalia.confirmacion_tec = true;

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

        // PUT: api/RegistrosAnomalias/ConfirmarSupervisor
        [HttpPut("[action]")]
        public async Task<IActionResult> ConfirmarSupervisor([FromBody] ActualizarViewModelConfirmacionTarjeta model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idregistroanomalia <= 0)
            {
                return BadRequest();
            }

            RegistroAnomalia anomalia = await _context.Registrosanomalias.FirstOrDefaultAsync(c => c.idregistroanomalia == model.idregistroanomalia);

            if (anomalia == null)
            {
                return NotFound();
            }
            DateTime fechaHora = DateTime.Now;

            anomalia.confirmacion_super = true;
            anomalia.idsupervisor = model.idsupervisor;
            anomalia.cierre_ts = fechaHora;
            anomalia.observaciones = model.observaciones;

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




        private bool RegistroAnomaliaExists(int id)
        {
            return _context.Registrosanomalias.Any(e => e.idregistroanomalia == id);
        }
    }
}
