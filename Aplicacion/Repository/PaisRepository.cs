

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

        public override async Task<(int totalRegistros, IEnumerable<Pais> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
        {
            var query = _context.Paises as IQueryable<Pais>;

            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.NombrePais.ToLower().Contains(search));
            }

            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query 
                .Include(u => u.Departamentos)
                .Skip((pageIndez - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (totalRegistros, registros);
        }
}
