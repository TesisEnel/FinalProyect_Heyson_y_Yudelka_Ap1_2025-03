using FinalProyect.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
namespace FinalProyect.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
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
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>().HasData(
        new IdentityRole
        {
            Id = "1",
            Name = "Admin",
            NormalizedName = "ADMIN",
            ConcurrencyStamp = ""
        },
        new IdentityRole
        {
            Id = "2",
            Name = "Tesorera",
            NormalizedName = "TESORERA",
            ConcurrencyStamp = ""
        }
    );

        var adminUser = new ApplicationUser
        {
            Id = "100",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@gmail.com",
            NormalizedEmail = "ADMIN@GMAIL.COM",
            EmailConfirmed = true,
            SecurityStamp = "",
            ConcurrencyStamp = ""
        };

        adminUser.PasswordHash =
        "AQAAAAIAAYagAAAAEBLjsj0D0GttEMej0zSgKCenZ2DaEuFjLZiPDbUc9In0hqgtIBAV4OJVc96y4lMmoA==";

        builder.Entity<ApplicationUser>().HasData(adminUser);

        var tesoreraUser = new ApplicationUser
        {
            Id = "200",
            UserName = "tesorera",
            NormalizedUserName = "TESORERA",
            Email = "tesorera@gmail.com",
            NormalizedEmail = "TESORERA@GMAIL.COM",
            EmailConfirmed = true,
            SecurityStamp = "",
            ConcurrencyStamp = ""
        };

        tesoreraUser.PasswordHash =
            "AQAAAAIAAYagAAAAEDh/ppk82Pqm7B8eH4Id2RuZITvBXW+AwQ2DOeXanbk92D3IblAo/ARFeZEOqAcjPw==";

        builder.Entity<ApplicationUser>().HasData(tesoreraUser);

        builder.Entity<IdentityUserRole<string>>().HasData(
           new IdentityUserRole<string>
           {
               RoleId = "1",
               UserId = "100"
           },
           new IdentityUserRole<string>
           {
               RoleId = "2",
               UserId = "200"
           }
       );

        foreach (var relationship in builder.Model
            .GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}