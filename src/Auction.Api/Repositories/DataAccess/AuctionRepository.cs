using Auction.Api.Entities;
using Auction.Api.Repositories.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auction.Api.Repositories.DataAccess
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly AuctionDbContext _context;

        public AuctionRepository(AuctionDbContext context)
        {
            _context = context;
        }

        public List<Entities.Auction> GetCurrentAuction()
        {
            return _context
                        .Auctions
                        .Include(auction => auction.Items)
                        .Where(x => x.Starts <= DateTime.Now).ToList();
        }
    }
}
