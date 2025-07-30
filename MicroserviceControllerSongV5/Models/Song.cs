namespace MicroserviceControllerSongV5.Models;

/// <summary>
/// Representa la entidad de una canción en la base de datos.
/// </summary>
public class Song
{
    public int ID_SONG { get; set; }
    public string SONG_NAME { get; set; } = string.Empty;
    public string SONG_PATH { get; set; } = string.Empty;
    public int? PLAYS { get; set; }
}
