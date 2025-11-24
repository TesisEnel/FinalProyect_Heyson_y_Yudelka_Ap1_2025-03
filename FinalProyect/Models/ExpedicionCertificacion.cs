namespace FinalProyect.Models;

public class ExpedicionCertificacion
{
    public int Id { get; set; }

    public string NombreSolicitante { get; set; }
    public string Cedula { get; set; }
    public string Telefono { get; set; }

    public string TipoCertificacion { get; set; }

    public string Contenido { get; set; }

    public decimal Monto { get; set; }

    public string Estado { get; set; }

    public DateTime FechaSolicitud { get; set; } = DateTime.Now;
    public DateTime? FechaEmision { get; set; }
}


