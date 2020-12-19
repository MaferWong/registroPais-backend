﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroPaises.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RegistroPaises.DataContext
{
    public class MapUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios", "dbo");
            builder.HasKey(q => q.UsuarioId);
            builder.Property(e => e.UsuarioId).IsRequired();
            builder.Property(e => e.Contrasena).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(e => e.EstaActivo);
        }
    }
}
