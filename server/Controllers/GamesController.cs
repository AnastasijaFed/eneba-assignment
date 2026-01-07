using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]

public class GamesController : ControllerBase
{
    private readonly AppDbContext _db;
    public GamesController(AppDbContext db) => _db = db;

    [HttpGet("/list")]
    public async Task<ActionResult<List<Game>>> List([FromQuery] string? search)
    {
        var query = _db.Games.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.Trim().ToLower();
            query = query.Where(game => game.Title.ToLower().Contains(s));
        }
        var games = await query.OrderBy(g => g.Title).ToListAsync();

        return Ok(games);

    }
}