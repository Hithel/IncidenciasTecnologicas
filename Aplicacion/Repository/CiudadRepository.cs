
using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;
public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
{
    private readonly APIIncidenciasContext _context; 
    public CiudadRepository(APIIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Ciudad>> GetAllAsync()
    {
        return await _context.Ciudades
        .Include(e => e.Personas)
        .ToListAsync();
    }

    public override async Task<Ciudad> GetByIdAsync(int id)
    {
        return await _context.Ciudades
            .Include(e => e.Personas)
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}
