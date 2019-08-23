using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Wcm._1_N
{
    public class RegistroShe
    {
        public int idregistroshe { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string codigo { get; set; }
        public string nombre { get; set; }
        public DateTime emision_ts { get; set; }
        public int idusuario { get; set; }
        public string prioridad { get; set; }
        public string turno { get; set; }
        public DateTime hora_reporte { get; set; }

        public int idarea { get; set; }
        public int idmaquina { get; set; }
        public string she_ma { get; set; }
        public bool paro_equipo { get; set; }
        public int idfalla { get; set; }
        public int idcondicion { get; set; }
        public string descripcion { get; set; }
        public string ope_mtto { get; set; }
        public string sol_implementada { get; set; }
        public DateTime ejecucion_ts { get; set; }
        public int idtecnico { get; set; }
        public bool confirmacion_tec { get; set; }
        public int idsupervisor { get; set; }
        public bool confirmacion_super { get; set; }
        public DateTime cierre_ts { get; set; }
        public string observaciones { get; set; }
        public bool prog { get; set; }
        public string foto { get; set; }
        public bool eliminado { get; set; }

        public Usuario usuarioshe { get; set; }
        public Usuario usuariotecnicoshe { get; set; }
        public Usuario usuariosupervisorshe { get; set; }

        public Maquina maquina { get; set; }

        public Area area { get; set; }
        public Falla Falla { get; set; }
        public CondicionInsegura condicionInsegura { get; set; }

    }
}
