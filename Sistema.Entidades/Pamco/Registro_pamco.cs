using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Sistema.Entidades.Pamco

{
    public class Registro_pamco
    {
        public int idpamco { get; set; }
        public int idcategoria { get; set; }
        public int idusuario { get; set; }
        public int idmaquina { get; set; }
        public string evento { get; set; }
        public DateTime ts { get; set; }
        public string turno { get; set; }
        public string hora_inicio { get; set; }
        public string hora_final { get; set; }
        public string tiempo_total { get; set; }
        public bool eliminado { get; set; }

    }
}
