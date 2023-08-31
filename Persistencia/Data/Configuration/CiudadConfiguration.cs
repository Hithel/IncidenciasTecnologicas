using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistencia.Data.Configuration;
    public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            builder.ToTable("Ciudad");

            builder.HasKey(p => p.Id);

            builder.Property(c => c.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasMaxLength(3);

            builder.Property(c => c.NommbreCuidad)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasOne(c => c.Departamento)
            .WithMany(c => c.Ciudades)
            .HasForeignKey(c => c.IdDepartamentoFk);


        }
    }
