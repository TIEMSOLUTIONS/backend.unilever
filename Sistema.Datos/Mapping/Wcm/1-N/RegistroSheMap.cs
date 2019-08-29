using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Wcm._1_N;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Wcm._1_N
{
    class RegistroSheMap : IEntityTypeConfiguration<RegistroShe>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RegistroShe> builder)
        {
            builder.ToTable("tb_registro_she_ma")
                .HasKey(i => i.idregistroshe);

            builder.HasOne(i => i.usuarioshe)
              .WithMany(p => p.registroshe)
              .HasForeignKey(i => i.idusuario);


            builder.HasOne(u => u.usuariotecnicoshe)
              .WithMany(u => u.registroSheTecnico)
              .HasForeignKey(u => u.idtecnico);

            builder.HasOne(u => u.usuariosupervisorshe)
              .WithMany(u => u.registroSheSupervisor)
              .HasForeignKey(u => u.idsupervisor);

            builder.HasOne(i => i.area)
               .WithMany(p => p.registroShe)
               .HasForeignKey(i => i.idarea);

            builder.HasOne(i => i.maquina)
              .WithMany(p => p.registroShe)
              .HasForeignKey(i => i.idmaquina);

            builder.HasOne(i => i.condicionInsegura)
               .WithMany(p => p.registroShe)
               .HasForeignKey(i => i.idcondicion);

            builder.HasOne(i => i.Falla)
              .WithMany(p => p.registroShe)
              .HasForeignKey(i => i.idfalla);


           

        }
    }
}
