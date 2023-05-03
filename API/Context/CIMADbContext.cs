using Microsoft.EntityFrameworkCore;
using CIMA.Models;

namespace CIMA.Context;

public class CIMADbContext : DbContext
{
    public CIMADbContext(DbContextOptions options) : base(options) 
    {

    }

    public DbSet<Asistente> Asistentes { get; set; } = null!;
    public DbSet<Sesion> Sesiones { get; set; } = null!;
    public DbSet<AsistentesPorSesion> AsistentesPorSesion { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsistentesPorSesion>()
            .HasKey(c => new { c.Id_Sesion, c.Id_Asistente });
    }

}