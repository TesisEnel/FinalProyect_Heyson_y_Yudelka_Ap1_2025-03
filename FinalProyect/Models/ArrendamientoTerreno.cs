using FinalProyect.Data;
using System.ComponentModel.DataAnnotations;

namespace FinalProyect.Models;

public class ArrendamientoTerreno : ISolicitable
{
    public int Id { get; set; }
    public ProcessType TipoProceso { get; set; } = ProcessType.ArrendamientoTerreno;

    public string UsuarioId { get; set; } = string.Empty;
    public ApplicationUser Usuario { get; set; }

    [Required(ErrorMessage = "El solicitante es obligatorio.")]
    public int SolicitanteId { get; set; }
    public Solicitante Solicitante { get; set; }

    [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
    public DateTime FechaInicio { get; set; }

    [Required(ErrorMessage = "La fecha de finalización es obligatoria.")]
    public DateTime FechaFin { get; set; }

    [Required(ErrorMessage = "Debe especificar los metros cuadrados.")]
    [Range(1, int.MaxValue, ErrorMessage = "Los metros cuadrados deben ser mayores a 0.")]
    public int MetrosCuadrados { get; set; }

    [Required(ErrorMessage = "Debe indicar la ubicación del terreno.")]
    [MaxLength(150, ErrorMessage = "La ubicación no puede exceder los 150 caracteres.")]
    public string Ubicacion { get; set; } = "";

    public bool NotificarVencimiento { get; set; }

    public int? ReciboIngresoId { get; set; }
    public ReciboIngreso? ReciboIngreso { get; set; }
    public ICollection<Documento>? Documentos { get; set; }
    public string GetConcepto() => "Arrendamiento de terreno en el cementerio";
    public int GetMetros() => MetrosCuadrados;
}
