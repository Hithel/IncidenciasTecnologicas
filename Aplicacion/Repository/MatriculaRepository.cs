
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class MatriculaRepository : GenericRepository<Matricula>, IMatricula
{
    private readonly APIIncidenciasContext _context;
    public MatriculaRepository(APIIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Matricula>> GetAllAsync()
    {
        return await _context.Matriculas
        .ToListAsync();
    }

    public override async Task<Matricula> GetByIdAsync(int id)
    {
        return await _context.Matriculas
        .FirstOrDefaultAsync(e => e.Id == id);
    }
}
