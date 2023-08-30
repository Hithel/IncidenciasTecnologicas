
namespace Dominio.Entities;
    public class Matricula : BaseEntity
    {
        public int IdPersonaFK { get; set; }
        public Persona Persona { get; set; }
        public int IdSalonFK { get; set; }
        public Salon Salon { get; set; }
    }
