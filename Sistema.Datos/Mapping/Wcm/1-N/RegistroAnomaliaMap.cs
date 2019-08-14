using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Wcm._1_N;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Wcm._1_N
{
    class RegistroAnomaliaMap : IEntityTypeConfiguration<RegistroAnomalia>
    {
        public void Configure(EntityTypeBuilder<RegistroAnomalia> builder)
        {
            builder.ToTable("tb_registro_anomalia")
                  .HasKey(i => i.idregistroanomalia);

            builder.HasOne(i => i.usuario)
              .WithMany(p => p.registroAnomalia)
              .HasForeignKey(i => i.idusuario);


            builder.HasOne(u => u.usuariotecnico)
              .WithMany(u => u.registroAnomaliaTecnico)
              .HasForeignKey(u =>u.idtecnico );

            builder.HasOne(u => u.usuariosupervisor)
              .WithMany(u => u.registroAnomaliaSupervisor)
              .HasForeignKey(u => u.idsupervisor);

            builder.HasOne(i => i.area)
               .WithMany(p => p.registroAnomalia)
               .HasForeignKey(i => i.idarea);

            builder.HasOne(i => i.maquina)
              .WithMany(p => p.registroAnomalia)
              .HasForeignKey(i => i.idmaquina);

            builder.HasOne(i => i.anomalia)
               .WithMany(p => p.registroAnomalia)
               .HasForeignKey(i => i.idanomalia);

            builder.HasOne(i => i.suceso)
              .WithMany(p => p.registroAnomalia)
              .HasForeignKey(i => i.idsuceso);


            builder.HasOne(i => i.tarjeta)
              .WithMany(p => p.registroAnomalia)
              .HasForeignKey(i => i.idtarjeta);

           



            





        }

    }
}
