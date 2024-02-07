using Auction.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.Api.Repositories
{
    public class AuctionDbContext : DbContext
    {
        public DbSet<Entities.Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\mateu\\source\\repos\\Auction.nlw\\src\\leilaoDbNLW.db");
        }
    }
}
