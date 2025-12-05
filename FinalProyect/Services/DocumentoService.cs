using FinalProyect.Data;
using FinalProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProyect.Services;

public class DocumentoService
{
    private readonly ApplicationDbContext _context;
    private readonly BlobStorageService _blob;

    public DocumentoService(ApplicationDbContext context, BlobStorageService blob)
    {
        _context = context;
        _blob = blob;
    }
    public async Task<Documento> SubirDocumentoAsync(
        Stream archivo,
        string nombreArchivo,
        DocumentType tipo,
        int? enterramientoId = null,
        int? construccionId = null,
        int? certificacionId = null,
        int? registroId = null,
        int? reciboId = null)
    {
        var url = await _blob.UploadFileAsync(archivo, nombreArchivo);

        var doc = new Documento
        {
            NombreArchivo = nombreArchivo,
            BlobUrl = url,
            Extension = Path.GetExtension(nombreArchivo),
            FechaSubida = DateTime.Now,
            TipoDocumento = tipo,
            DerechoEnterramientoId = enterramientoId,
            DerechoConstruccionId = construccionId,
            ExpedicionCertificacionId = certificacionId,
            RegistroDocumentacionId = registroId,
            ReciboIngresoId = reciboId
        };

        _context.Documentos.Add(doc);
        await _context.SaveChangesAsync();

        return doc;
    }
    public async Task<List<Documento>> ObtenerTodos()
    {
        return await _context.Documentos.ToListAsync();
    }

    public async Task<Documento?> ObtenerPorId(int id)
    {
        return await _context.Documentos.FindAsync(id);
    }

    public async Task<bool> Crear(Documento documento)
    {
        _context.Documentos.Add(documento);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Actualizar(Documento documento)
    {
        _context.Documentos.Update(documento);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        var documento = await _context.Documentos.FindAsync(id);
        if (documento == null) return false;
        _context.Documentos.Remove(documento);
        return await _context.SaveChangesAsync() > 0;
    }
}
