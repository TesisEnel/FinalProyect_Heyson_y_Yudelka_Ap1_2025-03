using FinalProyect.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace FinalProyect.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string NombreCompleto { get; set; }
    [Required(ErrorMessage = "This field is required to continue.")]
    [MaxLength(50, ErrorMessage = "The Name must not exceed 50 characters.")]
    public string Cedula { get; set; }
    [Required(ErrorMessage = "This field is required to continue.")]
    [MaxLength(11, ErrorMessage = "The Address must not exceed 11 characters.")]

    public string? Sexo { get; set; }
    [MaxLength(10, ErrorMessage = "The Address must not exceed 10 characters.")]

    public string Correo { get; set; }
    [Required(ErrorMessage = "This field is required to continue.")]

    public string? Telefono { get; set; }
    [MaxLength(11, ErrorMessage = "The Address must not exceed 11 characters.")]

    public string? Idioma { get; set; }

    public bool EsAdmin { get; set; } = false;
    public ICollection<Historial>? Historiales { get; set; }
}
