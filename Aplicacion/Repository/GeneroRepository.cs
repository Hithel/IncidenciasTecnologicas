
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class GeneroRepository : GenericRepository<Genero>, IGenero
{
    private readonly APIIncidenciasContext _context;
    public GeneroRepository(APIIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Genero>> GetAllAsync()
    {
        return await _context.Generos
        .Include(e => e.Personas)
        .ToListAsync();
    }

    public override async Task<Genero> GetByIdAsync(int id)
    {
        return await _context.Generos
        .Include(e => e.Personas)
        .FirstOrDefaultAsync(e => e.Id == id);
    }
}
