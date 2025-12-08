using FinalProyect.Data;
using FinalProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProyect.Services;

public class HistorialService
{
    private readonly ApplicationDbContext _context;

    public HistorialService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Historial>> ObtenerTodos()
    {
        return await _context.Historiales
            .Include(h => h.Usuario)
            .Include(h => h.ReciboIngreso)
            .ToListAsync();
    }

    public async Task<Historial?> ObtenerPorId(int id)
    {
        return await _context.Historiales
            .Include(h => h.Usuario)
            .Include(h => h.ReciboIngreso)
            .FirstOrDefaultAsync(h => h.Id == id);
    }

    public async Task<bool> Crear(Historial historial)
    {
        _context.Historiales.Add(historial);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Actualizar(Historial historial)
    {
        _context.Historiales.Update(historial);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        var historial = await _context.Historiales.FindAsync(id);
        if (historial == null) return false;
        _context.Historiales.Remove(historial);
        return await _context.SaveChangesAsync() > 0;
    }
}
