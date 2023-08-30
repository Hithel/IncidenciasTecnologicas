
namespace Dominio.Entities;
    public class Persona : BaseEntity
    {
        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public int IdGeneroFK { get; set; } 
        public Genero Genero { get; set; }
        public int IdCuidadFK { get; set; }
        public Ciudad Ciudad { get; set; }
        public int IdTipoPersonaFK { get; set; }
        public TipoPersona TipoPersona { get; set; }
        public ICollection<Matricula> Matriculas{ get; set; }
        public ICollection<TrainerSalon> TrainerSalones { get; set; }
    }
