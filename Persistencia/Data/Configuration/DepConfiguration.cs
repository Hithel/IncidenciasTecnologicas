using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class DepConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Departamento");

            builder.HasKey(p => p.Id);

            builder.Property(d => d.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasMaxLength(3);

            builder.Property(d => d.NombreDepa)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasOne(d => d.Pais)
            .WithMany(d => d.Departamentos)
            .HasForeignKey(d => d.IdPaisFK);
        }
    }
