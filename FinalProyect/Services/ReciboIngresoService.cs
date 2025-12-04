using FinalProyect.Data;
using FinalProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProyect.Services;

public class ReciboIngresoService
{
    private readonly ApplicationDbContext _context;

    public ReciboIngresoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ReciboIngreso>> ObtenerTodos()
    {
        return await _context.ReciboIngreso
            .Include(r => r.Solicitante)
            .Include(r => r.Documentos)
            .ToListAsync();
    }

    public async Task<ReciboIngreso?> ObtenerPorId(int id)
    {
        return await _context.ReciboIngreso
            .Include(r => r.Solicitante)
            .Include(r => r.Documentos)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<int> Crear(ReciboIngreso recibo)
    {
        _context.ReciboIngreso.Add(recibo);
        await _context.SaveChangesAsync();
        return recibo.Id;
    }

    public async Task<bool> Actualizar(ReciboIngreso recibo)
    {
        _context.ReciboIngreso.Update(recibo);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> ConfirmarRecibo(int reciboId, int documentoId)
    {
        var recibo = await _context.ReciboIngreso
            .Include(r => r.Documentos)
            .FirstOrDefaultAsync(r => r.Id == reciboId);

        if (recibo == null)
            return false;

        var documento = await _context.Documentos.FindAsync(documentoId);
        if (documento == null)
            return false;

        recibo.Documentos ??= new List<Documento>();
        recibo.Documentos.Add(documento);

        recibo.FechaConfirmacion = DateTime.Now;

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Anular(int id)
    {
        var recibo = await _context.ReciboIngreso.FindAsync(id);
        if (recibo == null) return false;

        recibo.Estado = "Anulado";
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<ReciboIngreso?> ObtenerPorIdConDocumentos(int id)
    {
        return await _context.ReciboIngreso
            .Include(r => r.Documentos)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

}
