
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    private readonly APIIncidenciasContext _context;
    public PersonaRepository(APIIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Personas
        .Include(e => e.Matriculas)
        .Include(e => e.TrainerSalones)
        .Include(e => e.Salones)
        .ToListAsync();
    }

    public override async Task<Persona> GetByIdAsync(int id)
    {
        return await _context.Personas
        .Include(e => e.Matriculas)
        .Include(e => e.TrainerSalones)
        .Include(e => e.Salones)
        .FirstOrDefaultAsync(e => e.Id == id);
    }
}