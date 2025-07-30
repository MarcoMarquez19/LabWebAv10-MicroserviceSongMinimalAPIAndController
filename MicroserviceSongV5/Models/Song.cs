namespace MicroserviceSongV5.Models;

public class Song
{
    public int Id_Song { get; set; }
    public string Song_Name { get; set; } = string.Empty;
    public string Song_Path { get; set; } = string.Empty;
    public int? Plays { get; set; }
}