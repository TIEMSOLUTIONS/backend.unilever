using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Imagen;

namespace Sistema.Datos.Mapping.Imagen
{
    public class ImagenesMap : IEntityTypeConfiguration<Imagenes>
    {
        public void Configure(EntityTypeBuilder<Imagenes> builder)
        {
            builder.ToTable("tb_imagen")
                .HasKey(c => c.idimagen);
        }
    }
}
