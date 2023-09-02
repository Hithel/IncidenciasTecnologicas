
using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly APIIncidenciasContext context;
        
        private PaisRepository _paises;
        private DepaRepository _departamentos;
        private CiudadRepository _cuidades;
        private PersonaRepository _personas;
        private TipoPersonaRepository _tipoPersona;
        private GeneroRepository _generos;
        private SalonRepository _salones;
        private MatriculaRepository _matricula;

        public UnitOfWork (APIIncidenciasContext _context)
        {
            context = _context;
        }

        public IPais Paises
        {
            get{
                if(_paises == null)
                {
                    _paises = new PaisRepository(context);
                }
                return _paises;
                }
        }
        public IDepartamento Departamentos
        {
            get{
                if(_departamentos == null)
                {
                    _departamentos = new DepaRepository(context);
                }
                return _departamentos;
                }
        }

        public ICiudad Cuidades
        {
            get{
                if(_cuidades == null)
                {
                    _cuidades = new CiudadRepository(context);
                }
                return _cuidades;
                }
        }

        public IPersona Personas
        {
            get{
                if(_personas == null)
                {
                    _personas = new PersonaRepository(context);
                }
                return _personas;
                }
        }

        public ITipoPersona TipoPersonas
        {
            get{
                if(_tipoPersona == null)
                {
                    _tipoPersona = new TipoPersonaRepository(context);
                }
                return _tipoPersona;
                }
        }

        public IGenero Generos
        {
            get{
                if(_generos == null)
                {
                    _generos = new GeneroRepository(context);
                }
                return _generos;
                }
        }

        public ISalon Salones
        {
            get{
                if(_salones == null)
                {
                    _salones = new SalonRepository(context);
                }
                return _salones;
                }
        }

        public IMatricula Matriculas
        {
            get{
                if(_matricula == null)
                {
                    _matricula = new MatriculaRepository(context);
                }
                return _matricula;
                }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

    }
