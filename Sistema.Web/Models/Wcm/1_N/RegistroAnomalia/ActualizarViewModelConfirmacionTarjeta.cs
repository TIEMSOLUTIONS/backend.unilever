using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Wcm._1_N.RegistroAnomalia
{
    public class ActualizarViewModelConfirmacionTarjeta
    {

        public int idregistroanomalia { get; set; }
        [Required]
        public int idsupervisor { get; set; }
        public string observaciones { get; set; }


    }
}
