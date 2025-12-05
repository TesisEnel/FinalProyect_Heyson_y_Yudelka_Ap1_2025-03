using FinalProyect.Data;
using System.ComponentModel.DataAnnotations;

namespace FinalProyect.Models;

public class RegistroDocumentacion
{
    public int Id { get; set; }

    public ProcessType TipoProceso { get; set; } = ProcessType.RegistroDocumentacion;
    public string NombreCompleto { get; set; }
    public string Cedula { get; set; }
    public string Telefono { get; set; }

    public string TipoDocumentacion { get; set; }

    public decimal Monto { get; set; }

    public string? Comentarios { get; set; } = "";

    public string? ReciboNotariosRuta { get; set; } = null;

    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    public string UsuarioId { get; set; } = string.Empty; 
    public ApplicationUser? Usuario { get; set; }

    [Required]
    public int SolicitanteId { get; set; }
    public Solicitante? Solicitante { get; set; }

    public int? ReciboIngresoId { get; set; } 
    public ReciboIngreso? ReciboIngreso { get; set; }

    public ICollection<Documento>? Documentos { get; set; }

    public string GetConcepto() => "Registro de documentación";
}
