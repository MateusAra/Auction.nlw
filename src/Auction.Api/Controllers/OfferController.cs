using Auction.Api.Communication.Requests;
using Auction.Api.Filters;
using Auction.Api.UseCases.Auctions.Offer.CreateOffer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Api.Controllers
{

    [ServiceFilter(typeof(AuthenticateUserAttribute))]
    public class OfferController : AuctionBaseController
    {
        [HttpPost]
        [Route("{itemId}")]
        public IActionResult CreateOffer([FromRoute] int itemId, 
                                            [FromBody] CreateOfferRequestJson request,
                                                [FromServices] CreateOfferUseCase useCase)
        {
            var id = useCase.Execute(itemId, request);

            var response = new { Message = "Oferta criada!", Id = id };

            return Created(string.Empty, response);
        }
    }
}
