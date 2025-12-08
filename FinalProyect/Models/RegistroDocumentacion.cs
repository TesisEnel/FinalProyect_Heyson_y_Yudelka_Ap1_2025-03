using FinalProyect.Data;
using System.ComponentModel.DataAnnotations;

namespace FinalProyect.Models;

public class RegistroDocumentacion
{
    public int Id { get; set; }

    public ProcessType TipoProceso { get; set; } = ProcessType.RegistroDocumentacion;

    [Required(ErrorMessage = "El nombre completo es obligatorio.")]
    [MaxLength(150)]
    public string NombreCompleto { get; set; }

    [Required(ErrorMessage = "La cédula es obligatoria.")]
    [RegularExpression(@"^[0-9]{3}[- ]?[0-9]{7}[- ]?[0-9]{1}$",
        ErrorMessage = "La cédula no es válida.")]
    public string Cedula { get; set; }

    [Required(ErrorMessage = "El teléfono es obligatorio.")]
    [RegularExpression(@"^[0-9()\-\s]{10,20}$",
        ErrorMessage = "El teléfono no es válido.")]
    public string Telefono { get; set; }

    [Required(ErrorMessage = "Debe especificar el tipo de documentación.")]
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

    public const string Concepto = "Registro de documentación";
}
