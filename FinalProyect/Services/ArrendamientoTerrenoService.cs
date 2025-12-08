using FinalProyect.Data;
using FinalProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProyect.Services;
public class ArrendamientoTerrenoService
{
    private readonly ApplicationDbContext _context;

    public ArrendamientoTerrenoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ArrendamientoTerreno>> ObtenerTodos()
    {
        return await _context.ArrendamientoTerreno
            .Include(a => a.Usuario)
            .Include(a => a.Solicitante)
            .Include(a => a.ReciboIngreso)
            .ToListAsync();
    }

    public async Task<ArrendamientoTerreno?> ObtenerPorId(int id)
    {
        return await _context.ArrendamientoTerreno
            .Include(a => a.Usuario)
            .Include(a => a.Solicitante)
            .Include(a => a.ReciboIngreso)
            .ThenInclude(r => r.Documentos)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<int> Crear(ArrendamientoTerreno arrendamiento)
    {
        _context.ArrendamientoTerreno.Add(arrendamiento);
         await _context.SaveChangesAsync();
         return arrendamiento.Id;
    }

    public async Task<bool> Actualizar(ArrendamientoTerreno arrendamiento)
    {
        _context.ArrendamientoTerreno.Update(arrendamiento);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        var arrendamiento = await _context.ArrendamientoTerreno.FindAsync(id);
        if (arrendamiento == null) return false;
        _context.ArrendamientoTerreno.Remove(arrendamiento);
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<List<ArrendamientoTerreno>> ObtenerVencimientos(int diasAviso = 5)
    {
        var hoy = DateTime.Today;
        var avisoLimite = hoy.AddDays(diasAviso);

        return await _context.ArrendamientoTerreno
            .Include(a => a.Solicitante)
            .Where(a => a.FechaFin <= avisoLimite)
            .OrderBy(a => a.FechaFin)
            .ToListAsync();
    }
}
