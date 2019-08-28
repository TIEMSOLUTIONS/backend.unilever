using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Pamco;

namespace Sistema.Datos.Mapping.Pamco
{
    public class RegistroPamcoMap : IEntityTypeConfiguration<Registro_pamco>
    {
        public void Configure(EntityTypeBuilder<Registro_pamco> builder)
        {
            builder.ToTable("tb_registro_pamco")
                .HasKey(c => c.idpamco);
        }
    }
}
