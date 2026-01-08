using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data // change if needed
{
    public static class DbSeeder
    {
         public static void SeedDiscounts(AppDbContext db)
{
    if (db.Discounts.Any())
        return;

    var now = DateTime.UtcNow;


    var listingData = (
        from l in db.GameListings.AsNoTracking()
        join g in db.Games.AsNoTracking() on l.GameId equals g.Id
        select new { ListingId = l.Id, Title = g.Title }
    ).ToList();

    if (listingData.Count == 0)
        return;


    var onePerGame = listingData
        .OrderBy(x => x.ListingId)
        .GroupBy(x => x.Title)
        .Select(grp => grp.First())
        .ToList();


    Discount Percent(int listingId, int percent, int days) => new Discount
    {
        GameListingId = listingId,
        Amount = percent,
        Type = "percent",
        EndsAt = now.AddDays(days)
    };

    var discounts = new List<Discount>();


    foreach (var x in onePerGame)
    {
        if (x.Title == "FIFA 23")
            discounts.Add(Percent(x.ListingId, 20, 30));
        else if (x.Title == "Red Dead Redemption 2")
            discounts.Add(Percent(x.ListingId, 15, 20));
        else if (x.Title == "Split Fiction")
            discounts.Add(Percent(x.ListingId, 10, 25));
    }

    var already = discounts.Select(d => d.GameListingId).ToHashSet();
    var extras = listingData
        .Where(x => !already.Contains(x.ListingId))
        .OrderByDescending(x => x.ListingId) 
        .Take(2)
        .ToList();

    foreach (var e in extras)
        discounts.Add(Percent(e.ListingId, 5, 15));

    db.Discounts.AddRange(discounts);
    db.SaveChanges();
}

        public static void Seed(AppDbContext db)
        {
            db.Database.Migrate();

            if (!db.Games.Any())
            {
                db.Games.AddRange(
                    new Game { Title = "FIFA 23" },
                    new Game { Title = "Red Dead Redemption 2" },
                    new Game { Title = "Split Fiction" }
                );
                db.SaveChanges();
            }


            if (db.GameListings.Any())
                return;


            var fifa  = db.Games.AsNoTracking().Single(g => g.Title == "FIFA 23");
            var rdr2  = db.Games.AsNoTracking().Single(g => g.Title == "Red Dead Redemption 2");
            var split = db.Games.AsNoTracking().Single(g => g.Title == "Split Fiction");


            const string fifaImg  = "/games/fifa23.jpg";
            const string rdr2Img  = "/games/rdr2.jpg";
            const string splitImg = "/games/splitfiction.jpg";

            var listings = new List<GameListing>
            {
                // ===================== FIFA 23 listings =====================
                new GameListing { GameId = fifa.Id,  Platform="PC",          Region="Global", Price=19.99m, CashbackPercent=5,  ImgUrl=fifaImg,  Likes=1240 },
                new GameListing { GameId = fifa.Id,  Platform="PC",          Region="EU",     Price=17.99m, CashbackPercent=7,  ImgUrl=fifaImg,  Likes=980  },
                new GameListing { GameId = fifa.Id,  Platform="PC",          Region="US",     Price=18.99m, CashbackPercent=6,  ImgUrl=fifaImg,  Likes=905  },
                new GameListing { GameId = fifa.Id,  Platform="PlayStation", Region="EU",     Price=24.99m, CashbackPercent=6,  ImgUrl=fifaImg,  Likes=1415 },
                new GameListing { GameId = fifa.Id,  Platform="PlayStation", Region="UK",     Price=21.99m, CashbackPercent=5,  ImgUrl=fifaImg,  Likes=1105 },
                new GameListing { GameId = fifa.Id,  Platform="Xbox",        Region="Global", Price=22.99m, CashbackPercent=6,  ImgUrl=fifaImg,  Likes=905  },
                new GameListing { GameId = fifa.Id,  Platform="Xbox",        Region="UK",     Price=19.99m, CashbackPercent=5,  ImgUrl=fifaImg,  Likes=860  },
                new GameListing { GameId = fifa.Id,  Platform="Switch",      Region="EU",     Price=29.99m, CashbackPercent=3,  ImgUrl=fifaImg,  Likes=640  },

                // ===================== Red Dead Redemption 2 listings =====================
                new GameListing { GameId = rdr2.Id,  Platform="PC",          Region="Global", Price=14.99m, CashbackPercent=8,  ImgUrl=rdr2Img,  Likes=3520 },
                new GameListing { GameId = rdr2.Id,  Platform="PC",          Region="EU",     Price=13.49m, CashbackPercent=10, ImgUrl=rdr2Img,  Likes=2890 },
                new GameListing { GameId = rdr2.Id,  Platform="PC",          Region="UK",     Price=12.99m, CashbackPercent=9,  ImgUrl=rdr2Img,  Likes=2410 },
                new GameListing { GameId = rdr2.Id,  Platform="PlayStation", Region="US",     Price=16.99m, CashbackPercent=7,  ImgUrl=rdr2Img,  Likes=4010 },
                new GameListing { GameId = rdr2.Id,  Platform="PlayStation", Region="EU",     Price=15.99m, CashbackPercent=6,  ImgUrl=rdr2Img,  Likes=3180 },
                new GameListing { GameId = rdr2.Id,  Platform="Xbox",        Region="US",     Price=15.99m, CashbackPercent=5,  ImgUrl=rdr2Img,  Likes=2640 },
                new GameListing { GameId = rdr2.Id,  Platform="Xbox",        Region="EU",     Price=15.49m, CashbackPercent=7,  ImgUrl=rdr2Img,  Likes=2765 },

                // ===================== Split Fiction listings =====================
                new GameListing { GameId = split.Id, Platform="PC",          Region="Global", Price=9.99m,  CashbackPercent=12, ImgUrl=splitImg, Likes=410 },
                new GameListing { GameId = split.Id, Platform="PC",          Region="EU",     Price=8.99m,  CashbackPercent=15, ImgUrl=splitImg, Likes=365 },
                new GameListing { GameId = split.Id, Platform="PC",          Region="US",     Price=9.49m,  CashbackPercent=13, ImgUrl=splitImg, Likes=340 },
                new GameListing { GameId = split.Id, Platform="PlayStation", Region="EU",     Price=12.99m, CashbackPercent=10, ImgUrl=splitImg, Likes=520 },
                new GameListing { GameId = split.Id, Platform="PlayStation", Region="US",     Price=12.99m, CashbackPercent=9,  ImgUrl=splitImg, Likes=475 },
                new GameListing { GameId = split.Id, Platform="Xbox",        Region="UK",     Price=9.49m,  CashbackPercent=11, ImgUrl=splitImg, Likes=330 },
                new GameListing { GameId = split.Id, Platform="Xbox",        Region="EU",     Price=11.49m, CashbackPercent=10, ImgUrl=splitImg, Likes=340 },
                new GameListing { GameId = split.Id, Platform="Switch",      Region="Global", Price=14.99m, CashbackPercent=8,  ImgUrl=splitImg, Likes=290 },
            };

            db.GameListings.AddRange(listings);
            db.SaveChanges();
        }
    }
}
