using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data 
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext db)
        {
            // Ensure DB + schema exist (especially useful for SQLite during dev)
            db.Database.Migrate();

            // Seed only if empty
            if (db.Games.Any())
                return;

            var games = new List<Game>
            {
                // ===================== FIFA 23 (6+) =====================
                new Game
                {
                    Title = "FIFA 23",
                    Platform = "PC",
                    Region = "Global",
                    Price = "€19.99",
                    CashbackPercent = 5,
                    ImgUrl = PlaceholderUrl("FIFA 23", "PC Global"),
                    Likes = 1240
                },
                new Game
                {
                    Title = "FIFA 23",
                    Platform = "PC",
                    Region = "EU",
                    Price = "€17.99",
                    CashbackPercent = 7,
                    ImgUrl = PlaceholderUrl("FIFA 23", "PC EU"),
                    Likes = 980
                },
                new Game
                {
                    Title = "FIFA 23",
                    Platform = "PlayStation",
                    Region = "EU",
                    Price = "€24.99",
                    CashbackPercent = 6,
                    ImgUrl = PlaceholderUrl("FIFA 23", "PS EU"),
                    Likes = 1415
                },
                new Game
                {
                    Title = "FIFA 23",
                    Platform = "PlayStation",
                    Region = "US",
                    Price = "$24.99",
                    CashbackPercent = 4,
                    ImgUrl = PlaceholderUrl("FIFA 23", "PS US"),
                    Likes = 1330
                },
                new Game
                {
                    Title = "FIFA 23",
                    Platform = "Xbox",
                    Region = "UK",
                    Price = "£19.99",
                    CashbackPercent = 5,
                    ImgUrl = PlaceholderUrl("FIFA 23", "Xbox UK"),
                    Likes = 860
                },
                new Game
                {
                    Title = "FIFA 23",
                    Platform = "Switch",
                    Region = "EU",
                    Price = "€29.99",
                    CashbackPercent = 3,
                    ImgUrl = PlaceholderUrl("FIFA 23", "Switch EU"),
                    Likes = 640
                },
                new Game
                {
                    Title = "FIFA 23",
                    Platform = "Xbox",
                    Region = "Global",
                    Price = "€22.99",
                    CashbackPercent = 6,
                    ImgUrl = PlaceholderUrl("FIFA 23", "Xbox Global"),
                    Likes = 905
                },

                // ===================== Red Dead Redemption 2 (6+) =====================
                new Game
                {
                    Title = "Red Dead Redemption 2",
                    Platform = "PC",
                    Region = "Global",
                    Price = "€14.99",
                    CashbackPercent = 8,
                    ImgUrl = PlaceholderUrl("Red Dead Redemption 2", "PC Global"),
                    Likes = 3520
                },
                new Game
                {
                    Title = "Red Dead Redemption 2",
                    Platform = "PC",
                    Region = "EU",
                    Price = "€13.49",
                    CashbackPercent = 10,
                    ImgUrl = PlaceholderUrl("Red Dead Redemption 2", "PC EU"),
                    Likes = 2890
                },
                new Game
                {
                    Title = "Red Dead Redemption 2",
                    Platform = "PlayStation",
                    Region = "US",
                    Price = "$16.99",
                    CashbackPercent = 7,
                    ImgUrl = PlaceholderUrl("Red Dead Redemption 2", "PS US"),
                    Likes = 4010
                },
                new Game
                {
                    Title = "Red Dead Redemption 2",
                    Platform = "PlayStation",
                    Region = "UK",
                    Price = "£14.49",
                    CashbackPercent = 6,
                    ImgUrl = PlaceholderUrl("Red Dead Redemption 2", "PS UK"),
                    Likes = 3180
                },
                new Game
                {
                    Title = "Red Dead Redemption 2",
                    Platform = "Xbox",
                    Region = "EU",
                    Price = "€15.99",
                    CashbackPercent = 7,
                    ImgUrl = PlaceholderUrl("Red Dead Redemption 2", "Xbox EU"),
                    Likes = 2765
                },
                new Game
                {
                    Title = "Red Dead Redemption 2",
                    Platform = "Xbox",
                    Region = "US",
                    Price = "$15.99",
                    CashbackPercent = 5,
                    ImgUrl = PlaceholderUrl("Red Dead Redemption 2", "Xbox US"),
                    Likes = 2640
                },
                new Game
                {
                    Title = "Red Dead Redemption 2",
                    Platform = "PC",
                    Region = "UK",
                    Price = "£12.99",
                    CashbackPercent = 9,
                    ImgUrl = PlaceholderUrl("Red Dead Redemption 2", "PC UK"),
                    Likes = 2410
                },

                // ===================== Split Fiction (6+) =====================
                new Game
                {
                    Title = "Split Fiction",
                    Platform = "PC",
                    Region = "Global",
                    Price = "€9.99",
                    CashbackPercent = 12,
                    ImgUrl = PlaceholderUrl("Split Fiction", "PC Global"),
                    Likes = 410
                },
                new Game
                {
                    Title = "Split Fiction",
                    Platform = "PC",
                    Region = "EU",
                    Price = "€8.99",
                    CashbackPercent = 15,
                    ImgUrl = PlaceholderUrl("Split Fiction", "PC EU"),
                    Likes = 365
                },
                new Game
                {
                    Title = "Split Fiction",
                    Platform = "PlayStation",
                    Region = "EU",
                    Price = "€12.99",
                    CashbackPercent = 10,
                    ImgUrl = PlaceholderUrl("Split Fiction", "PS EU"),
                    Likes = 520
                },
                new Game
                {
                    Title = "Split Fiction",
                    Platform = "PlayStation",
                    Region = "US",
                    Price = "$12.99",
                    CashbackPercent = 9,
                    ImgUrl = PlaceholderUrl("Split Fiction", "PS US"),
                    Likes = 475
                },
                new Game
                {
                    Title = "Split Fiction",
                    Platform = "Xbox",
                    Region = "UK",
                    Price = "£9.49",
                    CashbackPercent = 11,
                    ImgUrl = PlaceholderUrl("Split Fiction", "Xbox UK"),
                    Likes = 330
                },
                new Game
                {
                    Title = "Split Fiction",
                    Platform = "Xbox",
                    Region = "EU",
                    Price = "€11.49",
                    CashbackPercent = 10,
                    ImgUrl = PlaceholderUrl("Split Fiction", "Xbox EU"),
                    Likes = 340
                },
                new Game
                {
                    Title = "Split Fiction",
                    Platform = "Switch",
                    Region = "Global",
                    Price = "€14.99",
                    CashbackPercent = 8,
                    ImgUrl = PlaceholderUrl("Split Fiction", "Switch Global"),
                    Likes = 290
                },
            };

            db.Games.AddRange(games);
            db.SaveChanges();
        }

        private static string PlaceholderUrl(string title, string subtitle)
        {
            // via.placeholder.com supports text=...; keep it simple & URL-encode
            var text = Uri.EscapeDataString($"{title} - {subtitle}");
            return $"https://via.placeholder.com/400x560?text={text}";
        }
    }
}
