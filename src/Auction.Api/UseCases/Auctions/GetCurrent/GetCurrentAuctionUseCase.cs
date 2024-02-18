using Auction.Api.Repositories;
using Auction.Api.Repositories.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auction.Api.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    private readonly IAuctionRepository _auctionRepository;

    public GetCurrentAuctionUseCase(IAuctionRepository auctionRepository)
    {
        _auctionRepository = auctionRepository;
    }

    public List<Entities.Auction> Execute()
    {
        return _auctionRepository.GetCurrentAuction();
    }
}
