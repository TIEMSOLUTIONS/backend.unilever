using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Pamco;

namespace Sistema.Datos.Mapping.Pamco
{
    public class CategoriaPerdidaMap : IEntityTypeConfiguration<Categoria_perdida>
    {
        public void Configure(EntityTypeBuilder<Categoria_perdida> builder)
        {
            builder.ToTable("tb_categoria")
                .HasKey(c => c.idcategoria);
        }
    }
}
