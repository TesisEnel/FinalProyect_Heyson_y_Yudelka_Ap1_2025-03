using FinalProyect.Data;
using System.ComponentModel.DataAnnotations;

namespace FinalProyect.Models;

public class ExpedicionCertificacion
{
    public int Id { get; set; }

    public ProcessType TipoProceso { get; set; } = ProcessType.ExpedicionCertificacion;

    public string NombreSolicitante { get; set; }
    public string Cedula { get; set; }
    public string Telefono { get; set; }

    public string TipoCertificacion { get; set; }

    public string Contenido { get; set; }

    public decimal Monto { get; set; }

    public string Estado { get; set; } = "Pendiente";

    public DateTime FechaSolicitud { get; set; } = DateTime.Now;
    public DateTime? FechaEmision { get; set; }

    public string UsuarioId { get; set; } = string.Empty; 
    public ApplicationUser? Usuario { get; set; }

    [Required]
    public int SolicitanteId { get; set; }
    public Solicitante? Solicitante { get; set; }

    public int? ReciboIngresoId { get; set; }
    public ReciboIngreso? ReciboIngreso { get; set; }

    public ICollection<Documento>? Documentos { get; set; }

    public string GetConcepto() => "Expedición de certificación";
}


