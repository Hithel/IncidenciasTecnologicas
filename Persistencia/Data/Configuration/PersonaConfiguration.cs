
using Microsoft.EntityFrameworkCore;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("Persona");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasMaxLength(3);

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Apellido)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(p => p.Genero)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.IdGeneroFK);

        builder.HasOne(p => p.Ciudad)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.IdCiudadFK);
        
        builder.HasOne(p => p.TipoPersona)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.IdTipoPersonaFK);

         builder
            .HasMany(p => p.Salones)
            .WithMany(p => p.Personas)
            .UsingEntity<TrainerSalon>(
                j => j
                    .HasOne(pt => pt.Salon)
                    .WithMany(t => t.TrainerSalones)
                    .HasForeignKey(pt => pt.IdSalonFK),
                j => j
                    .HasOne(pt => pt.Persona)
                    .WithMany(t => t.TrainerSalones)
                    .HasForeignKey(pt => pt.IdPersonaFK),
                j =>
                {
                    j.HasKey(t => new { t.IdPersonaFK, t.IdSalonFK});
                }
            );

    }
}
