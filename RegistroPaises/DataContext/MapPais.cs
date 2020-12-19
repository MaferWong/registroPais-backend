using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistroPaises.Models;


namespace RegistroPaises.DataContext
{
    public class MapPais : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("Paises", "dbo");
            builder.HasKey(q => q.id);
            builder.Property(e => e.id).IsRequired().UseIdentityColumn();
            builder.Property(e => e.nombre).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(e => e.codigo).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();

            builder.HasOne(e => e.Departamento)
                .WithMany(e => e.Paises)
                .HasForeignKey(e => e.departamentoId);
        }
    }
}
