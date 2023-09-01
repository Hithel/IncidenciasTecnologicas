
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class TipoPersonaRepository : GenericRepository<TipoPersona>, ITipoPersona
{
    private readonly APIIncidenciasContext _context;
    public TipoPersonaRepository(APIIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TipoPersona>> GetAllAsync()
    {
        return await _context.TipoPersonas
        .Include(e => e.Personas)
        .ToListAsync();
    }

    public override async Task<TipoPersona> GetByIdAsync(int id)
    {
        return await _context.TipoPersonas
        .Include(e => e.Personas)
        .FirstOrDefaultAsync(e => e.Id == id);
    }
}
