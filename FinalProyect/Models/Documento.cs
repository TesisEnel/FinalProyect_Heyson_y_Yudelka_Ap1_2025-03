using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace FinalProyect.Models;

public class Documento
{
    public int Id { get; set; }
    public string TipoDocumento { get; set; } = String.Empty;
    [Required(ErrorMessage = "This field is required to continue.")]
    [MaxLength(50, ErrorMessage = "The Name must not exceed 50 characters.")]
    public string NumeroDocumento { get; set; } = String.Empty;
    [MaxLength(50, ErrorMessage = "The Name must not exceed 50 characters.")]
    public DateTime FechaSubida { get; set; }
    public ICollection<ReciboIngreso>? RecibosIngresos { get; set; }

}
