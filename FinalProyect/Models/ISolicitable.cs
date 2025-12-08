namespace FinalProyect.Models;
public interface ISolicitable
{
    int Id { get; }
    int SolicitanteId { get; }
    Solicitante Solicitante { get; }

    string GetConcepto();
    int GetMetros();
    ProcessType TipoProceso { get; }
}
