using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
{
    public void Configure(EntityTypeBuilder<Genero> builder)
    {
        builder.ToTable("genero");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
        .HasMaxLength(3);

        builder.Property(g => g.Descripcion)
        .IsRequired()
        .HasMaxLength(50);
    }
}