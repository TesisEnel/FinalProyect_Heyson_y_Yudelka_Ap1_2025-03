using FinalProyect.Data;
using FinalProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProyect.Services;

public class DerechoConstruccionService
{
    private readonly ApplicationDbContext _context;

    public DerechoConstruccionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<DerechoConstruccion>> ObtenerTodos()
    {
        return await _context.DerechoConstruccion
            .Include(d => d.Usuario)
            .Include(d => d.Solicitante)
            .Include(d => d.Documentos)
            .ToListAsync();
    }

    public async Task<DerechoConstruccion?> ObtenerPorId(int id)
    {
        return await _context.DerechoConstruccion
            .Include(d => d.Usuario)
            .Include(d => d.Solicitante)
            .Include(d => d.Documentos)
            .Include(d => d.ReciboIngreso)
            .ThenInclude(r => r.Documentos)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<int> Crear(DerechoConstruccion derecho)
    {
        _context.DerechoConstruccion.Add(derecho);
        await _context.SaveChangesAsync();
        return derecho.Id;
    }

    public async Task<bool> Actualizar(DerechoConstruccion derecho)
    {
        _context.DerechoConstruccion.Update(derecho);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        var derecho = await _context.DerechoConstruccion.FindAsync(id);
        if (derecho == null) return false;
        _context.DerechoConstruccion.Remove(derecho);
        return await _context.SaveChangesAsync() > 0;
    }
}
