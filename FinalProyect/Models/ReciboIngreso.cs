using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace FinalProyect.Models;

public class ReciboIngreso
{
    public int Id { get; set; }
    public int SolicitanteId { get; set; }
    [Required (ErrorMessage = "This field is required to continue.")]
    public Solicitante? Solicitante { get; set; }
    public Documento? Documento { get; set; }
    [Required (ErrorMessage = "This field is required to continue.")]
    public string NumeroRecibo { get; set; } = String.Empty;
    public decimal Monto { get; set; }
    [Required (ErrorMessage = "This field is required to continue.")]
    public DateTime FechaEmision { get; set; } = DateTime.Now;
    [Required (ErrorMessage = "This field is required to continue.")]
    public string BlobUrl { get; set; } = String.Empty;
    [Required (ErrorMessage = "This field is required to continue.")]

    public string BlobFileName { get; set; } = String.Empty;
    [Required (ErrorMessage = "This field is required to continue.")]
    public int DocumentoId { get; set; }
    public ICollection<Historial>? Historiales { get; set; }
}
