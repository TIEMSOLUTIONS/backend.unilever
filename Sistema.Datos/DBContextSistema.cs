using Microsoft.EntityFrameworkCore;
using Sistema.Datos.Mapping.Almacen;
using Sistema.Datos.Mapping.Pamco;
using Sistema.Datos.Mapping.Imagen;
using Sistema.Datos.Mapping.Usuarios;
using Sistema.Datos.Mapping.Ventas;
using Sistema.Datos.Mapping.Wcm;
using Sistema.Datos.Mapping.Wcm._1_N;
using Sistema.Entidades.Almacen;
using Sistema.Entidades.Pamco;
using Sistema.Entidades.Imagen;
using Sistema.Entidades.Usuarios;
using Sistema.Entidades.Ventas;
using Sistema.Entidades.Wcm;
using Sistema.Entidades.Wcm._1_N;

namespace Sistema.Datos
{
    public class DbContextSistema : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; }
        public DbSet<DetalleIngreso> DetallesIngresos { get; set; }
        /////////////////////////////////////////////////////////////////////////////////// PAMCO
        public DbSet<Categoria_perdida> Categoria_perdida { get; set; }
        public DbSet<Registro_pamco> Registro_Pamcos { get; set; }

        /////////////////////////////////////////////////////////////////////////////////// imagen
        public DbSet<Imagenes> Imagenes { get; set; }

        // dbSET WCM
        public DbSet<Area> Areas { get; set; }
        public DbSet<Anomalia> Anomalias { get; set; }

        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Falla> Fallas { get; set; }
        public DbSet<CondicionInsegura> CondicionesInseguras { get; set; }
        public DbSet<Suceso> Sucesos { get; set; }
        public DbSet<Maquina> Maquinas { get; set; }

        public DbSet<RegistroAnomalia> Registrosanomalias { get; set; }

        public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ArticuloMap());
            modelBuilder.ApplyConfiguration(new RolMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PersonaMap());
            modelBuilder.ApplyConfiguration(new IngresoMap());
            modelBuilder.ApplyConfiguration(new DetalleIngresoMap());

            //Modelos WCM
            modelBuilder.ApplyConfiguration(new AreaMap());
            modelBuilder.ApplyConfiguration(new AnomaliaMap());
            modelBuilder.ApplyConfiguration(new TarjetaMap());
            modelBuilder.ApplyConfiguration(new FallaMap());
            modelBuilder.ApplyConfiguration(new CondicioneInseguraMap());
            modelBuilder.ApplyConfiguration(new SucesoMap());
            modelBuilder.ApplyConfiguration(new MaquinaMap());
            modelBuilder.ApplyConfiguration(new RegistroAnomaliaMap());

            ///////////////////////////////////////////////////////////// PAMCO
            modelBuilder.ApplyConfiguration(new CategoriaPerdidaMap());
            modelBuilder.ApplyConfiguration(new RegistroPamcoMap());

            ///////////////////////////////////////////////////////////// imagen
            modelBuilder.ApplyConfiguration(new ImagenesMap());
        }

    }
}
