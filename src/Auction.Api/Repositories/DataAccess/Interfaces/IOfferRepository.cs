using Auction.Api.Entities;

namespace Auction.Api.Repositories.DataAccess.Interfaces
{
    public interface IOfferRepository
    {
        int CreateOffer(Offer offer);
    }
}
