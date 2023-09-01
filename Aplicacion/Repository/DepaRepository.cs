

using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;


namespace Aplicacion.Repository;
    public class DepaRepository : GenericRepository<Departamento>, IDepartamento
    {
        private readonly APIIncidenciasContext _context;

        public DepaRepository(APIIncidenciasContext context): base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Departamento>> GetAllAsync()
        {
            return await _context.Departamentos
            .Include(e => e.Ciudades)
            .ToListAsync();
        }

        public override async Task<Departamento> GetByIdAsync(int id)
        {
            return await _context.Departamentos
                .Include(e => e.Ciudades)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
