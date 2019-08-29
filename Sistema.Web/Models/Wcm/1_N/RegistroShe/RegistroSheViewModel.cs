using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Web.Models.Wcm._1_N.RegistroShe
{
    public class RegistroSheViewModel
    {
        public int idregistroshe { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string emision_ts { get; set; }
        public int idusuario { get; set; }
        public string usuario { get; set; }
        public string prioridad { get; set; }
        public string hora_reporte { get; set; }

        public string turno { get; set; }
        public int idarea { get; set; }
        public string area { get; set; }
        public int idmaquina { get; set; }
        public string maquina { get; set; }
        public string she_ma { get; set; }
        public bool paro_equipo { get; set; }
        public int idfalla { get; set; }
        public string falla { get; set; }
        public int idcondicion { get; set; }
        public string condicioinsegura { get; set; }
        public string descripcion { get; set; }
        public string ope_mtto { get; set; }
        public string sol_implementada { get; set; }
        public DateTime ejecucion_ts { get; set; }
        public int idtecnico { get; set; }
        public string usuariotecnico { get; set; }
        public bool confirmacion_tec { get; set; }
        public int idsupervisor { get; set; }
        public string usuariosupervisor { get; set; }
        public bool confirmacion_super { get; set; }
        public DateTime cierre_ts { get; set; }
        public string observaciones { get; set; }
        public bool prog { get; set; }
        public string foto { get; set; }
        public bool eliminado { get; set; }

    }
}
