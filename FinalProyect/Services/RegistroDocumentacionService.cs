using FinalProyect.Data;
using FinalProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProyect.Services;
public class RegistroDocumentacionService
{
    private readonly ApplicationDbContext _context;

    public RegistroDocumentacionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<RegistroDocumentacion>> ObtenerTodos()
    {
        return await _context.RegistrosDocumentacion
            .Include(r => r.Usuario)
            .Include(r => r.Solicitante)
            .Include(r => r.ReciboIngreso)
            .ToListAsync();
    }

    public async Task<RegistroDocumentacion?> ObtenerPorId(int id)
    {
        return await _context.RegistrosDocumentacion
            .Include(r => r.Usuario)
            .Include(r => r.Solicitante)
            .Include(r => r.Documentos)
            .Include(r => r.ReciboIngreso)
            .ThenInclude(r => r.Documentos)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<int> Crear(RegistroDocumentacion registro)
    {
        _context.RegistrosDocumentacion.Add(registro);
        await _context.SaveChangesAsync();
        return registro.Id;
    }

    public async Task<bool> Actualizar(RegistroDocumentacion registro)
    {
        _context.RegistrosDocumentacion.Update(registro);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        var registro = await _context.RegistrosDocumentacion.FindAsync(id);
        if (registro == null) return false;
        _context.RegistrosDocumentacion.Remove(registro);
        return await _context.SaveChangesAsync() > 0;
    }
}
