using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProyect.Models
{
    public class ReciboIngreso
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Solicitante es obligatorio.")]
        public int SolicitanteId { get; set; }

        [ForeignKey("SolicitanteId")]
        public Solicitante Solicitante { get; set; } = null!;

        [Required(ErrorMessage = "Número de recibo es requerido.")]
        [StringLength(30)]
        public string NumeroRecibo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Monto es requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "El monto debe ser mayor a cero.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "Monto en letras es obligatorio.")]
        public string MontoEnLetras { get; set; } = string.Empty;

        [Required(ErrorMessage = "Concepto es obligatorio.")]
        [StringLength(200)]
        public string Concepto { get; set; } = string.Empty;

        [Required(ErrorMessage = "Forma de pago es obligatoria.")]
        public string FormaPago { get; set; } = string.Empty;

        public string? FuenteNumero { get; set; }

        [Required(ErrorMessage = "Fecha es obligatoria.")]
        public DateTime FechaEmision { get; set; } = DateTime.Now;

        public DateTime? FechaConfirmacion { get; set; }

        [Required]
        public string Estado { get; set; } = "Activo";

        public ICollection<Historial>? Historiales { get; set; }
        public ICollection<Documento>? Documentos { get; set; }
    }
}