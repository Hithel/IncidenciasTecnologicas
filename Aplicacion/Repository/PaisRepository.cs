

using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;
public class PaisRepository : GenericRepository<Pais>, IPais
{
    private readonly APIIncidenciasContext _context;

    public PaisRepository(APIIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Pais>> GetAllAsync()
        {
            return await _context.Paises
            .Include(p => p.Departamentos)
            .ToListAsync();
        }

        public override async Task<Pais> GetByIdAsync(int id)
        {
            return await _context.Paises
            .Include(p => p.Departamentos)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

}
