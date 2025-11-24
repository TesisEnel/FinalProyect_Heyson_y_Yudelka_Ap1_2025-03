using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace FinalProyect.Models;

public class Documento
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string TipoDocumento { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string NombreArchivo { get; set; } = string.Empty;

    [Required]
    public string RutaArchivo { get; set; } = string.Empty;

    [MaxLength(10)]
    public string? Extension { get; set; }

    public DateTime? FechaSubida { get; set; }

    public int? DerechoEnterramientoId { get; set; }
    public DerechoEnterramiento? DerechoEnterramiento { get; set; }

    public int? DerechoConstruccionId { get; set; }
    public DerechoConstruccion? DerechoConstruccion { get; set; }

    public int? ReciboIngresoId { get; set; }
    public ReciboIngreso? ReciboIngreso { get; set; }

    public int? RegistroDocumentacionId { get; set; }
    public RegistroDocumentacion? RegistroDocumentacion { get; set; }

}