using Auction.Api.Communication.Requests;
using Auction.Api.Repositories;
using Auction.Api.Repositories.DataAccess.Interfaces;
using Auction.Api.Services;

namespace Auction.Api.UseCases.Auctions.Offer.CreateOffer
{
    public class CreateOfferUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IOfferRepository _offerRepository;

        public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository offerRepository)
        {
            _loggedUser = loggedUser;
            _offerRepository = offerRepository;
        }

        public int Execute(int itemId, CreateOfferRequestJson request)
        {
            var user = _loggedUser.User();

            var offer = new Entities.Offer()
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id
            };

            _offerRepository.CreateOffer(offer);

            return offer.Id;
        }
    }
}
