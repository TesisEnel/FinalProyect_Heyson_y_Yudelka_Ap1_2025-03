using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FinalProyect.Models;
namespace FinalProyect.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<ReciboIngreso> ReciboIngreso { get; set; }
    public DbSet<Solicitante> Solicitantes { get; set; }
    public DbSet<Proceso> Procesos { get; set; }
    public DbSet<Documento> Documentos { get; set; }
    public DbSet<Historial> Historiales { get; set; }
    public DbSet<ConsultaIngresos> ConsultasIngresos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ReciboIngreso>()
               .HasOne(r => r.Solicitante)
               .WithMany(s => s.RecibosIngresos)
               .HasForeignKey(r => r.SolicitanteId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ReciboIngreso>()
               .HasOne(r => r.Documento)
               .WithMany(d => d.RecibosIngresos)
               .HasForeignKey(r => r.DocumentoId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ReciboIngreso>()
               .HasOne(r => r.Proceso)
               .WithMany(p => p.RecibosIngresos)
               .HasForeignKey(r => r.ProcesoId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Historial>()
               .HasOne(h => h.ReciboIngreso)
               .WithMany(r => r.Historiales)
               .HasForeignKey(h => h.ReciboIngresoId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Historial>()
               .HasOne(h => h.Usuario)
               .WithMany(u => u.Historiales)
               .HasForeignKey(h => h.usuarioId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Historial>()
               .HasOne(h => h.Proceso)
               .WithMany(p => p.Historiales)
               .HasForeignKey(h => h.ProcesoId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
