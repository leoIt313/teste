using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Domain.Entities;
using Teste.Infra.Context;

namespace Teste.Infra.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario> 
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario", "dbo");
            builder.HasKey(x => x.IdUsuario);
            builder.Property(x => x.IdUsuario).HasColumnName(@"IdUsuario").HasColumnType("bigint").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.NomeCompleto).HasColumnName(@"NomeCompleto").HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Email).HasColumnName(@"Email").HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnName(@"Telefone").HasColumnType("varchar(9)").IsRequired();
        }
    }
}
