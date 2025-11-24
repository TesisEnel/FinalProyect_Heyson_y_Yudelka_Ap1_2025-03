using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace FinalProyect.Models;

public class Solicitante
{
    [Key]
    public int Id { get; set; }
    public string NombreCompleto { get; set; }
    [MaxLength(50, ErrorMessage = "The Name must not exceed 50 characters.")]
    public string Cedula { get; set; }
    [MaxLength(11, ErrorMessage = "The Name must not exceed 11 characters.")]
    [Required(ErrorMessage = "This field is required to continue.")]
    public string? Sexo { get; set; }
    public string? Telefono { get; set; }
    public ICollection<Historial>? Historiales { get; set; }
    public ICollection<ReciboIngreso>? RecibosIngresos { get; set; }

}
