
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class SalonRepository : GenericRepository<Salon>, ISalon
{
    private readonly APIIncidenciasContext _context;
    public SalonRepository(APIIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Salon>> GetAllAsync()
    {
        return await _context.Salones
        .Include(e => e.Personas)
        .Include(e => e.Matriculas)
        .Include(e => e.TrainerSalones)
        .ToListAsync();
    }

    public override async Task<Salon> GetByIdAsync(int id)
    {
        return await _context.Salones
        .Include(e => e.Personas)
        .Include(e => e.Matriculas)
        .Include(e => e.TrainerSalones)
        .FirstOrDefaultAsync(e => e.Id == id);
    }
}
