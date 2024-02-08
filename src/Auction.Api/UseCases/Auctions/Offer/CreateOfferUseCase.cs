using Auction.Api.Communication.Requests;
using Auction.Api.Repositories;
using Auction.Api.Services;

namespace Auction.Api.UseCases.Auctions.Offer
{
    public class CreateOfferUseCase
    {
        private readonly LoggedUser _loggedUser;

        public CreateOfferUseCase(LoggedUser loggedUser) => _loggedUser = loggedUser;

        public int Execute(int itemId, CreateOfferRequestJson request)
        {
            var repository = new AuctionDbContext();
            var user = _loggedUser.User();

            var offer = new Entities.Offer()
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id
            };

            repository.Offers.Add(offer);
            repository.SaveChanges();

            return offer.Id;
        }
    }
}
