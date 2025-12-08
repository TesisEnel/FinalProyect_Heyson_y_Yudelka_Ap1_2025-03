using FinalProyect.Data;
using System.ComponentModel.DataAnnotations;

namespace FinalProyect.Models;

public class ExpedicionCertificacion
{
    public int Id { get; set; }

    public ProcessType TipoProceso { get; set; } = ProcessType.ExpedicionCertificacion;

    [Required(ErrorMessage = "El nombre del solicitante es obligatorio.")]
    public string NombreSolicitante { get; set; }

    [Required(ErrorMessage = "La cédula es obligatoria.")]
    [RegularExpression(@"^[0-9]{3}[- ]?[0-9]{7}[- ]?[0-9]{1}$")]
    public string Cedula { get; set; }

    [Required(ErrorMessage = "El teléfono es obligatorio.")]
    [RegularExpression(@"^[0-9()\-\s]{10,20}$",
        ErrorMessage = "El teléfono no es válido.")]
    public string Telefono { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un tipo de certificación.")]
    public string TipoCertificacion { get; set; }

    [Required(ErrorMessage = "El contenido es obligatorio.")]
    [MaxLength(500)]
    public string Contenido { get; set; }

    public decimal Monto { get; set; }

    public string Estado { get; set; } = "Pendiente";

    public DateTime FechaSolicitud { get; set; } = DateTime.Now;
    public DateTime? FechaEmision { get; set; }

    public string UsuarioId { get; set; } = string.Empty; 
    public ApplicationUser? Usuario { get; set; }

    [Required]
    public int SolicitanteId { get; set; }
    public Solicitante? Solicitante { get; set; }

    public int? ReciboIngresoId { get; set; }
    public ReciboIngreso? ReciboIngreso { get; set; }

    public ICollection<Documento>? Documentos { get; set; }

    public static string GetConcepto() => "Expedición de certificación";
}


