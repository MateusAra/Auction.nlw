using Auction.Api.Repositories;

namespace Auction.Api.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public List<Entities.Auction> Execute()
    {
        var repository = new AuctionDbContext();

        return repository.Auctions.ToList();
    }
}
