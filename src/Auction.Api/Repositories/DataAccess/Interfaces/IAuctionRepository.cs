using Auction.Api.Entities;

namespace Auction.Api.Repositories.DataAccess.Interfaces
{
    public interface IAuctionRepository
    {
        List<Entities.Auction> GetCurrentAuction();
    }
}
