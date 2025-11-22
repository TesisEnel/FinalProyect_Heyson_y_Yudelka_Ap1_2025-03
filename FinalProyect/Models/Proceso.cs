using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace FinalProyect.Models;

public class Proceso
{
    public int Id { get; set; }
    public string NombreProceso { get; set; } = String.Empty;
    public decimal MontoBase { get; set; }
    [Required(ErrorMessage = "This field is required to continue.")]
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public ICollection<ReciboIngreso>? RecibosIngresos { get; set; }
    public ICollection<Historial>? Historiales { get; set; }
}
