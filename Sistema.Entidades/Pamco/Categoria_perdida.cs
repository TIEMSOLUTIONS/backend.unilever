namespace Sistema.Entidades.Pamco
{
    public class Categoria_perdida
    {
        public int idcategoria { get; set; }
        public string nombre { get; set; }
        public int nivel { get; set; }
        public int cat_padre { get; set; }
        public bool activo { get; set; }
        public bool eliminado { get; set; }

    }
}
