using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Wcm._1_N
{
    public class RegistroAnomalia
    {
        public int idregistroanomalia { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string codigo { get; set; }
        public string nombre { get; set; }

        public DateTime emision_ts { get; set; }

        public int idusuario { get; set; }
        public int paso_ma { get; set; }
        public string criticidad { get; set; }
        public string turno { get; set; }
        public int idarea { get; set; }
        public int idmaquina { get; set; }
        public int idanomalia { get; set; }
        public int idsuceso { get; set; }
        public int idtarjeta { get; set; }
        public string descripcion { get; set; }
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

        public Usuario usuario { get; set; }
        public Usuario usuariotecnico { get; set; }
        public Usuario usuariosupervisor { get; set; }

        public Maquina maquina { get; set; }

        public Area area { get; set; }
        public Anomalia anomalia { get; set; }
        public Suceso suceso { get; set; }
        public Tarjeta tarjeta { get; set; }
    }
}
