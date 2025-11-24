using System;
using System.ComponentModel.DataAnnotations;
namespace FinalProyect.Models;

public class ConsultaIngresos
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = String.Empty;
    [Required(ErrorMessage = "This field is required to continue.")]
    [MaxLength(200, ErrorMessage = "The Name must not exceed 200 characters.")]
    public string TipoIngreso { get; set; } = String.Empty;
    [Required(ErrorMessage = "This field is required to continue.")]
    [MaxLength(100, ErrorMessage = "The Name must not exceed 100 characters.")]
    public decimal MontoAcumulado { get; set; }
    [Required(ErrorMessage = "This field is required to continue.")]
    [MaxLength(8, ErrorMessage = "The Name must not exceed 8 characters.")]
    public decimal Valor { get; set; }
    [Required(ErrorMessage = "This field is required to continue.")]
    [MaxLength(8, ErrorMessage = "The Name must not exceed 8 characters.")]
    public DateTime FechaIngreso { get; set; }

}
