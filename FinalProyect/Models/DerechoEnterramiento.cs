using FinalProyect.Data;
using System.ComponentModel.DataAnnotations;

namespace FinalProyect.Models;

public class DerechoEnterramiento
{
    public int Id { get; set; }

    public ProcessType TipoProceso { get; set; } = ProcessType.DerechoEnterramiento;
    public string UsuarioId { get; set; } = string.Empty;
    public ApplicationUser Usuario { get; set; }

    public int SolicitanteId { get; set; }
    public Solicitante Solicitante { get; set; }

    [Required(ErrorMessage = "El nombre del fallecido es obligatorio.")]
    [MaxLength(150)]
    public string NombreFallecido { get; set; } = string.Empty;

    [Required(ErrorMessage = "La cédula del fallecido es obligatoria.")]
    [RegularExpression(@"^[0-9]{3}[- ]?[0-9]{7}[- ]?[0-9]{1}$",
        ErrorMessage = "La cédula no es válida.")]
    public string CedulaFallecido { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha es obligatoria.")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "La hora es obligatoria.")]
    public TimeSpan Hora { get; set; }

    public int? ReciboIngresoId { get; set; }
    public ReciboIngreso? ReciboIngreso { get; set; }

    public ICollection<Documento>? Documentos { get; set; }

    public static string GetConcepto() => "Derecho a enterramiento";
    public static int GetMetros() => 0;
}