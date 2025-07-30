using Microsoft.EntityFrameworkCore;
using MicroserviceSongV5.Models;

namespace MicroserviceSongV5.Data;

public class SongDbContext : DbContext
{
    public SongDbContext(DbContextOptions<SongDbContext> options) : base(options) {}

    public DbSet<Song> Songs => Set<Song>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Song>().ToTable("TBL_SONG");
        modelBuilder.Entity<Song>().HasKey(s => s.Id_Song);
    }
}