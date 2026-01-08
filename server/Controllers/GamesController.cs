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
        var now = DateTime.UtcNow;
        var baseQuery =
            from listing in _db.GameListings.AsNoTracking()
            join game in _db.Games.AsNoTracking()
                on listing.GameId equals game.Id
            select new { listing, game };

        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.Trim().ToLower();
            baseQuery = baseQuery.Where(g => g.game.Title.ToLower().Contains(s));
        }
        var query =
            from x in baseQuery
            join d in _db.Discounts.AsNoTracking().Where(d => d.EndsAt > now)
                on x.listing.Id equals d.GameListingId into discounts
            let activeDiscount = discounts.OrderBy(d => d.EndsAt).FirstOrDefault()
            select new
            {
                id = x.listing.Id,
                gameId = x.game.Id,
                title = x.game.Title,
                platform = x.listing.Platform,
                region = x.listing.Region,
                price = x.listing.Price,
                cashbackPercent = x.listing.CashbackPercent,
                imgUrl = x.listing.ImgUrl,
                likes = x.listing.Likes,

                discount = activeDiscount == null ? null : new
                {
                    id = activeDiscount.Id,
                    amount = activeDiscount.Amount,
                    type = activeDiscount.Type,
                    endsAt = activeDiscount.EndsAt
                }
            };
        var games = await query.ToListAsync();

        return Ok(games);

    }
}