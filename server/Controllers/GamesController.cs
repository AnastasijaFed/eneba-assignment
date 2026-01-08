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
        var query = _db.GameListings.AsNoTracking().Join(
            _db.Games.AsNoTracking(),
                listing => listing.GameId,
                game => game.Id,
                (listing, game) => new
                {
                    id = listing.Id,
                    gameId = game.Id,
                    title = game.Title,
                    platform = listing.Platform,
                    region = listing.Region,
                    price = listing.Price,
                    cashbackPercent = listing.CashbackPercent,
                    imgUrl = listing.ImgUrl,
                    likes = listing.Likes
                }
        );

        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.Trim().ToLower();
            query = query.Where(x => x.title.ToLower().Contains(s));
        }
        var games = await query.ToListAsync();

        return Ok(games);

    }
}