namespace FinalProyect.Models;

public class RegistroDocumentacion
{
    public int Id { get; set; }

    public string NombreCompleto { get; set; }
    public string Cedula { get; set; }
    public string Telefono { get; set; }

    public string TipoDocumentacion { get; set; }

    public decimal Monto { get; set; }

    public string Comentarios { get; set; }

    public string ReciboNotariosRuta { get; set; }

    public DateTime FechaRegistro { get; set; } = DateTime.Now;
}
