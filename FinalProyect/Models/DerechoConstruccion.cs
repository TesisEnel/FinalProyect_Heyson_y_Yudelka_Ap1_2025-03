using FinalProyect.Data;
using FinalProyect.Models;
using System.ComponentModel.DataAnnotations;
namespace FinalProyect.Models;

public class DerechoConstruccion
{
    public int Id { get; set; }

    public ProcessType TipoProceso { get; set; } = ProcessType.DerechoConstruccion;

    public string UsuarioId { get; set; } = string.Empty;
    public ApplicationUser Usuario { get; set; }

    public int SolicitanteId { get; set; }
    public Solicitante Solicitante { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria.")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "La hora es obligatoria.")]
    public TimeSpan Hora { get; set; }

    public decimal Monto { get; set; }

    public string? ReciboInspectorPath { get; set; }

    public int? ReciboIngresoId { get; set; }
    public ReciboIngreso? ReciboIngreso { get; set; }

    public static string GetConcepto() => "Derecho de construcción";
    public static int GetMetros() => 0;

    public ICollection<Documento>? Documentos { get; set; }
}