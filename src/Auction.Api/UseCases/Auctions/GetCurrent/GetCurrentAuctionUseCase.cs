using Auction.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Auction.Api.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public List<Entities.Auction> Execute()
    {
        var repository = new AuctionDbContext();

        var today = DateTime.Now;

        return repository
                .Auctions
                .Include(auction => auction.Items)
                .Where(x => x.Starts <= today).ToList();
    }
}
