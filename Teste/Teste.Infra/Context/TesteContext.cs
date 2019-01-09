using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Teste.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teste.Domain.Entities;

namespace Teste.Infra.Context
{
    public class TesteContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region modelBuilder

         
            modelBuilder.ApplyConfiguration(new UsuarioMap());
         

            #endregion


            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        public void EnsureSeedData(TesteContext context)
        {

        }
    }

    public static class SqlServerModelBuilderExtensions
    {
        public static PropertyBuilder<decimal?> HasPrecision(this PropertyBuilder<decimal?> builder, int precision,
            int scale)
        {
            return builder.HasColumnType($"decimal({precision},{scale})");
        }

        public static PropertyBuilder<decimal> HasPrecision(this PropertyBuilder<decimal> builder, int precision,
            int scale)
        {
            return builder.HasColumnType($"decimal({precision},{scale})");
        }
    }
}