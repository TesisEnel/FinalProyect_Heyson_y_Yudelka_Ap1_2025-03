using FinalProyect.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProyect.Models;

public class Historial
{
    public int Id { get; set; }
    [Required(ErrorMessage = "This field is required to continue.")]
    public int ReciboIngresoId { get; set; }
    public ReciboIngreso? ReciboIngreso { get; set; }
    public string UsuarioId { get; set; } = String.Empty;
    [Required(ErrorMessage = "This field is required to continue.")]
    public ApplicationUser? Usuario { get; set; }
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
    public string? Descripcion { get; set; } = String.Empty;
}
