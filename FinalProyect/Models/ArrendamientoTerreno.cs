using FinalProyect.Data;
using System.ComponentModel.DataAnnotations;

namespace FinalProyect.Models;

public class ArrendamientoTerreno
{
    public int Id { get; set; }

    [Required]
    public string UsuarioId { get; set; } = string.Empty;
    public ApplicationUser Usuario { get; set; }

    [Required]
    public int SolicitanteId { get; set; }
    public Solicitante Solicitante { get; set; }

    [Required]
    public DateTime FechaInicio { get; set; }

    [Required]
    public DateTime FechaFin { get; set; }

    [Required]
    public decimal MetrosCuadrados { get; set; }

    public bool NotificarVencimiento { get; set; }

    [Required]
    public int ReciboIngresoId { get; set; }
    public ReciboIngreso ReciboIngreso { get; set; }
}
