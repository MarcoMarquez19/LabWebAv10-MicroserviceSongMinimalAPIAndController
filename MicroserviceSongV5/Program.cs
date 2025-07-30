using Microsoft.EntityFrameworkCore;
using MicroserviceSongV5.Data;
using MicroserviceSongV5.Models;

var builder = WebApplication.CreateBuilder(args);

// Añadir el servicio de swagger para pruebas
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configurar cadena de conexión a SQL Server
var connectionString = "Server=localhost,1433;Database=BDD_PoliMusic_Song;User Id=Admin_song;Password=Admin1_song_p@ssword;Encrypt=False;";
builder.Services.AddDbContext<SongDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Endpoints minimalistas

// Listamos todas las canciones
app.MapGet("/songs", async (SongDbContext db) =>
    await db.Songs.ToListAsync());

// Obtenemos una canción por id
app.MapGet("/songs/{id}", async (int id, SongDbContext db) =>
    await db.Songs.FindAsync(id) is Song song
        ? Results.Ok(song)
        : Results.NotFound());

// Crear una nueva canción
app.MapPost("/songs", async (Song song, SongDbContext db) =>
{
    db.Songs.Add(song);
    await db.SaveChangesAsync();
    return Results.Created($"/songs/{song.Id_Song}", song);
});

// Editamos una canción
app.MapPut("/songs/{id}", async (int id, Song inputSong, SongDbContext db) =>
{
    var song = await db.Songs.FindAsync(id);
    if (song is null) return Results.NotFound();

    song.Song_Name = inputSong.Song_Name;
    song.Song_Path = inputSong.Song_Path;
    song.Plays = inputSong.Plays;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Borramos una cancion a traves del id
app.MapDelete("/songs/{id}", async (int id, SongDbContext db) =>
{
    var song = await db.Songs.FindAsync(id);
    if (song is null) return Results.NotFound();

    db.Songs.Remove(song);
    await db.SaveChangesAsync();
    return Results.Ok(song);
});

//app.UseHttpsRedirection();
app.Run();