using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace FinalProyect.Models;

public class Solicitante
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre completo es obligatorio.")]
    [MaxLength(150, ErrorMessage = "El nombre no puede exceder los 150 caracteres.")]
    public string NombreCompleto { get; set; }
    [Required(ErrorMessage = "La cédula es obligatoria.")]
    [RegularExpression(@"^[0-9]{3}[- ]?[0-9]{7}[- ]?[0-9]{1}$",
           ErrorMessage = "La cédula no tiene un formato válido.")]
    public string Cedula { get; set; }
    [Required(ErrorMessage = "El teléfono es obligatorio.")]
    [RegularExpression(@"^[0-9()\-\s]{10,20}$",
        ErrorMessage = "El teléfono no tiene un formato válido.")]
    public string? Telefono { get; set; }
    public ICollection<Historial>? Historiales { get; set; }
    public ICollection<ReciboIngreso>? RecibosIngresos { get; set; }

}
