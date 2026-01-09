using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using FuzzySharp;
using Microsoft.Extensions.Caching.Memory;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]

public class GamesController : ControllerBase
{
    private readonly AppDbContext _db;
    public GamesController(AppDbContext db)
    {
        _db = db;

    }  

    [HttpGet("/list")]
    public async Task<ActionResult<List<Game>>> List([FromQuery] string? search)
    {
        var now = DateTime.UtcNow;
        
         var candidates = await (
        from listing in _db.GameListings.AsNoTracking()
        join game in _db.Games.AsNoTracking()
            on listing.GameId equals game.Id
        select new
        {
            ListingId = listing.Id,
            Title = game.Title,
            Platform = listing.Platform,
            Region = listing.Region,
            Price = listing.Price,
            CashbackPercent = listing.CashbackPercent,
            ImgUrl = listing.ImgUrl,
            Likes = listing.Likes
        }
    ).ToListAsync();
            

         if (!string.IsNullOrWhiteSpace(search))
    {
        var q = search.Trim();

        var threshold = q.Length switch
        {
            <= 2 => 100,
            <= 4 => 70,
            <= 8 => 75,
            _ => 80
        };

        candidates = candidates
            .Select(c => new { c, score = Fuzz.PartialRatio(q.ToLower(), c.Title.ToLower()) })
            .Where(x => x.score >= threshold)
            .OrderByDescending(x => x.score)
            .ThenBy(x => x.c.Title)
            .Take(200)
            .Select(x => x.c)
            .ToList();
    }
       var listingIds = candidates.Select(c => c.ListingId).ToList();

    var activeDiscounts = await _db.Discounts.AsNoTracking()
        .Where(d => listingIds.Contains(d.GameListingId) && d.EndsAt > now)
        .GroupBy(d => d.GameListingId)
        .Select(g => g.OrderBy(d => d.EndsAt).First())
        .ToListAsync();

    var discountMap = activeDiscounts.ToDictionary(d => d.GameListingId);

    var result = candidates.Select(c => new
    {
        id = c.ListingId,
        title = c.Title,
        platform = c.Platform,
        region = c.Region,
        price = c.Price,
        cashbackPercent = c.CashbackPercent,
        imgUrl = c.ImgUrl,
        likes = c.Likes,
        discount = discountMap.TryGetValue(c.ListingId, out var d) ? new
        {
            id = d.Id,
            amount = d.Amount,
            type = d.Type,
            endsAt = d.EndsAt
        } : null
    });

    return Ok(result);

    }

    private sealed class Candidate
    {
        public int ListingId { get; set; }
        public int GameId { get; set; }
        public string Title { get; set; } = "";
        public string Platform { get; set; } = "";
        public string Region { get; set; } = "";
        public decimal Price { get; set; }
        public int CashbackPercent { get; set; }
        public string ImgUrl { get; set; } = "";
        public int Likes { get; set; }
    }
}