using Microsoft.EntityFrameworkCore;
using MicroserviceControllerSongV5.Data;

var builder = WebApplication.CreateBuilder(args);

// Cadena de conexión a SQL Server
var connectionString = "Server=localhost,1433;Database=BDD_PoliMusic_Song;User Id=Admin_song;Password=Admin1_song_p@ssword;Encrypt=False;";

// Registrar AppDbContext
builder.Services.AddDbContext<SongDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Activar Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();