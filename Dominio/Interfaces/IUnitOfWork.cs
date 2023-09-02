

namespace Dominio.Interfaces;
    public interface IUnitOfWork
    {
        IPais Paises { get; }
        IDepartamento Departamentos { get; }
        ICiudad Cuidades { get; }
        IPersona Personas { get; }
        ITipoPersona TipoPersonas { get; }
        IGenero Generos { get; }
        ISalon Salones{ get; }
        IMatricula Matriculas { get; }
        
        Task<int> SaveAsync();
    }