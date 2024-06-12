using MagnaBackendNet.domain.models;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options) : base(options)
  {
  }
    public DbSet<Usuario> Users { get; set; }
    public DbSet<Manga> Mangas { get; set; }
    public DbSet<UsuarioManga> UsuarioMangas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UsuarioManga>()
            .HasKey(userManga => new { userManga.MangaId,userManga.UserId });
        modelBuilder.Entity<UsuarioManga>()
            .HasOne(u => u.Manga)
            .WithMany(um => um.UsuarioManga)
            .HasForeignKey(u => u.MangaId);
        modelBuilder.Entity<UsuarioManga>()
            .HasOne(u => u.Usuario)
            .WithMany(um => um.UsuarioManga)
            .HasForeignKey(u => u.UserId);
    }
}