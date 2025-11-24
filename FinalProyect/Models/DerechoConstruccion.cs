using FinalProyect.Data;
using FinalProyect.Models;
using System.ComponentModel.DataAnnotations;
namespace FinalProyect.Models;

public class DerechoConstruccion
{
    public int Id { get; set; }

    [Required]
    public string UsuarioId { get; set; } = string.Empty;
    public ApplicationUser Usuario { get; set; }

    [Required]
    public int SolicitanteId { get; set; }
    public Solicitante Solicitante { get; set; }

    [Required]
    public DateTime Fecha { get; set; }

    [Required]
    public TimeSpan Hora { get; set; }

    public string? ReciboInspectorPath { get; set; }

    [Required]
    public int ReciboIngresoId { get; set; }
    public ReciboIngreso ReciboIngreso { get; set; }
}