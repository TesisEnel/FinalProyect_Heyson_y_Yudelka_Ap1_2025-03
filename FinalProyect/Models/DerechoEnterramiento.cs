using FinalProyect.Data;
using System.ComponentModel.DataAnnotations;

namespace FinalProyect.Models;

public class DerechoEnterramiento
{
    public int Id { get; set; }

    [Required]
    public string UsuarioId { get; set; } = string.Empty;
    public ApplicationUser Usuario { get; set; }

    [Required]
    public int SolicitanteId { get; set; }
    public Solicitante Solicitante { get; set; }

    [Required]
    [MaxLength(100)]
    public string NombreFallecido { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string CedulaFallecido { get; set; } = string.Empty;

    [Required]
    public DateTime Fecha { get; set; }

    [Required]
    public TimeSpan Hora { get; set; }

    [Required]
    public int ReciboIngresoId { get; set; }
    public ReciboIngreso ReciboIngreso { get; set; }
}
