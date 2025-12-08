using FinalProyect.Data;
using FinalProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProyect.Services;
public class ConsultaIngresoService
{
    private readonly ApplicationDbContext _context;

    public ConsultaIngresoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ConsultaIngresos>> ObtenerTodos()
    {
        return await _context.ConsultasIngresos
            .Include(c => c.ReciboIngreso)
            .ToListAsync();
    }

    public async Task<ConsultaIngresos?> ObtenerPorId(int id)
    {
        return await _context.ConsultasIngresos
            .Include(c => c.ReciboIngreso)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<bool> Crear(ConsultaIngresos ingreso)
    {
        _context.ConsultasIngresos.Add(ingreso);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Actualizar(ConsultaIngresos ingreso)
    {
        _context.ConsultasIngresos.Update(ingreso);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        var ingreso = await _context.ConsultasIngresos.FindAsync(id);
        if (ingreso == null) return false;
        _context.ConsultasIngresos.Remove(ingreso);
        return await _context.SaveChangesAsync() > 0;
    }
}
