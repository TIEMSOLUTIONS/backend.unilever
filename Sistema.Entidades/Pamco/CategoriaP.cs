using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Pamco
{
   public  class CategoriaP
    {

        public int idcategoria { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string nombre { get; set; }
        [StringLength(256)]
        public int cat_padre { get; set; }
        public bool activo { get; set; }
        public bool eliminado { get; set; }
        //public ICollection<Equipo> equipos { get; set; }
    }
}
