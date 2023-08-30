using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class APIIncidenciasContext : DbContext
    {
        public APIIncidenciasContext(DbContextOptions<APIIncidenciasContext> options) : base(options)
        {

        }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<TipoPersona> TipoPersonas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Salon> Salones { get; set;}
        public DbSet<TrainerSalon> Trainers { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        
    }
}