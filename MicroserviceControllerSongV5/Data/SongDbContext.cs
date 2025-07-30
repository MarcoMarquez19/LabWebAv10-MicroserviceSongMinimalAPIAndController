using Microsoft.EntityFrameworkCore;
using MicroserviceControllerSongV5.Models;

namespace MicroserviceControllerSongV5.Data;

/// <summary>
/// DbContext que gestiona la conexión con SQL Server y las entidades.
/// </summary>
public class SongDbContext : DbContext
{
    public SongDbContext(DbContextOptions<SongDbContext> options) : base(options) { }

    public DbSet<Song> TBL_SONG => Set<Song>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Song>().ToTable("TBL_SONG");
        modelBuilder.Entity<Song>().HasKey(s => s.ID_SONG);
    }
}
