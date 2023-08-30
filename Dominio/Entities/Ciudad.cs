
namespace Dominio.Entities;
    public class Ciudad : BaseEntity
    {
        public string NommbreCuidad { get; set; }
        public int IdDepartamentoFk { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<Persona> Personas { get; set; }
    }
