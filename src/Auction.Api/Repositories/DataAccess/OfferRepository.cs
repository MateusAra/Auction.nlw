using Auction.Api.Entities;
using Auction.Api.Repositories.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auction.Api.Repositories.DataAccess
{
    public class OfferRepository : IOfferRepository
    {
        private readonly AuctionDbContext _context;

        public OfferRepository(AuctionDbContext context)
        {
            _context = context;
        }

        public int CreateOffer(Offer offer)
        {
            _context.Offers.Add(offer);
            _context.SaveChanges();

            return offer.Id;
        }
    }
}
