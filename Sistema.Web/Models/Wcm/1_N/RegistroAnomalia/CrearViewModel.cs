using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Wcm._1_N.RegistroAnomalia
{
    public class CrearViewModel
    {

        public string nombre { get; set; }

        ///public DateTime emision_ts { get; set; }

        [Required]
        public int idusuario { get; set; }
        public int paso_ma { get; set; }
        public string criticidad { get; set; }
        public string turno { get; set; }
        [Required]
        public int idarea { get; set; }
        [Required]
        public int idmaquina { get; set; }
        [Required]
        public int idanomalia { get; set; }
        [Required]
        public int idsuceso { get; set; }
        [Required]
        public int idtarjeta { get; set; }
        public string descripcion { get; set; }
        public string sol_implementada { get; set; }
        public DateTime ejecucion_ts { get; set; }
        public DateTime cierre_ts { get; set; }
        [Required]
        public int idtecnico { get; set; }
        [Required]
        public bool confirmacion_tec { get; set; }
        [Required]
        public int idsupervisor { get; set; }
        [Required]
        public bool confirmacion_super { get; set; }
        public string observaciones { get; set; }
        [Required]
        public bool prog { get; set; }
        public string foto { get; set; }
        [Required]
        public bool eliminado { get; set; }
    }
}
