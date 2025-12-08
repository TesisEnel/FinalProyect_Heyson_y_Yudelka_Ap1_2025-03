using FinalProyect.Data;
using System;
using System.ComponentModel.DataAnnotations;
namespace FinalProyect.Models;

public class ConsultaIngresos
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = String.Empty;
    public string TipoIngreso { get; set; } = String.Empty;

    public decimal MontoAcumulado { get; set; }
    public decimal Valor { get; set; }

    public DateTime FechaIngreso { get; set; }

    public int ReciboIngresoId { get; set; }      
    public ReciboIngreso? ReciboIngreso { get; set; }
}
