using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Wcm._1_N.RegistroAnomalia
{
    public class RegistroAnomaliaViewModel
    {
        public int idregistroanomalia { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string emision_ts { get; set; }
        public int idusuario { get; set; }
        public string usuario { get; set; }
        public int paso_ma { get; set; }
        public string criticidad { get; set; }
        public string turno { get; set; }
        public int idarea { get; set; }
        public string area { get; set; }

        public int idmaquina { get; set; }
        public string maquina { get; set; }

        public int idanomalia { get; set; }
        public string anomaliac { get; set; }

        public int idsuceso { get; set; }
        public string relacionado { get; set; }

        public int idtarjeta { get; set; }
        public string tarjeta { get; set; }

        public string descripcion { get; set; }
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
