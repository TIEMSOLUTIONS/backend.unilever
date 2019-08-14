using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Pamco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Pamco
{
    class CategoriapMap : IEntityTypeConfiguration<CategoriaP>
    {
        

        public void Configure(EntityTypeBuilder<CategoriaP> builder)
        {
            builder.ToTable("tb_categoria")
               .HasKey(c => c.idcategoria);
        }
    }
}
