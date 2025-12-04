using FinalProyect.Data;
using System.ComponentModel.DataAnnotations;

namespace FinalProyect.Models;

public class ArrendamientoTerreno : ISolicitable
{
    public int Id { get; set; }
    public ProcessType TipoProceso { get; set; } = ProcessType.ArrendamientoTerreno;

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
    public int MetrosCuadrados { get; set; }
    public string Ubicacion { get; set; } = "";

    public bool NotificarVencimiento { get; set; }

    public int? ReciboIngresoId { get; set; }
    public ReciboIngreso? ReciboIngreso { get; set; }
    public ICollection<Documento>? Documentos { get; set; }
    public string GetConcepto() => "Arrendamiento de terreno en el cementerio";
    public int GetMetros() => MetrosCuadrados;
}
