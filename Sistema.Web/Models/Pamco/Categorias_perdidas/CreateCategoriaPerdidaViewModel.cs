using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Pamco.Categorias_perdidas
{
    public class CreateCategoriaPerdidaViewModel
    {
        public string nombre { get; set; }
        public int nivel { get; set; }
        public int cat_padre { get; set; }
        public bool activo { get; set; }
        public bool eliminado { get; set; }

    }
}
