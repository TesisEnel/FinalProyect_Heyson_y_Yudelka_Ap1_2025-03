using FinalProyect.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
namespace FinalProyect.Data;

public class ApplicationDbContext 
    : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public ApplicationDbContext()
    {
    }

    public DbSet<ReciboIngreso> ReciboIngreso { get; set; }
    public DbSet<Solicitante> Solicitantes { get; set; }
    public DbSet<ArrendamientoTerreno> ArrendamientoTerreno { get; set; }
    public DbSet<Documento> Documentos { get; set; }
    public DbSet<Historial> Historiales { get; set; }
    public DbSet<ConsultaIngresos> ConsultasIngresos { get; set; }
    public DbSet<DerechoConstruccion> DerechoConstruccion { get; set; }
    public DbSet<ExpedicionCertificacion> ExpedicionesCertificaciones { get; set; }
    public DbSet<DerechoEnterramiento> DerechoEnterramiento { get; set; }
    public DbSet<RegistroDocumentacion> RegistrosDocumentacion { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var dbPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Data",
                "FinalProyect.db"
            );

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        foreach (var relationship in builder.Model
            .GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}