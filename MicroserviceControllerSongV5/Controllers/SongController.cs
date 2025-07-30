using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicroserviceControllerSongV5.Data;
using MicroserviceControllerSongV5.Models;

namespace MicroserviceControllerSongV5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SongsController : ControllerBase
{
    private readonly SongDbContext _context;

    public SongsController(SongDbContext context)
    {
        _context = context;
    }

    // GET: api/songs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
    {
        return await _context.TBL_SONG.ToListAsync();
    }

    // GET: api/songs/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Song>> GetSong(int id)
    {
        var song = await _context.TBL_SONG.FindAsync(id);
        if (song == null)
        {
            return NotFound();
        }

        return song;
    }

    // POST: api/songs
    [HttpPost]
    public async Task<ActionResult<Song>> CreateSong(Song song)
    {
        _context.TBL_SONG.Add(song);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSong), new { id = song.ID_SONG }, song);
    }

    // PUT: api/songs/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSong(int id, Song song)
    {
        if (id != song.ID_SONG)
        {
            return BadRequest();
        }

        _context.Entry(song).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SongExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // DELETE: api/songs/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSong(int id)
    {
        var song = await _context.TBL_SONG.FindAsync(id);
        if (song == null)
        {
            return NotFound();
        }

        _context.TBL_SONG.Remove(song);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool SongExists(int id) =>
        _context.TBL_SONG.Any(e => e.ID_SONG == id);
}
