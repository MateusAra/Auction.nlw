using Auction.Api.Communication.Requests;
using Auction.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Api.Controllers
{

    [ServiceFilter(typeof(AuthenticateUserAttribute))]
    public class OfferController : AuctionBaseController
    {
        [HttpPost]
        [Route("{itemId}")]
        public IActionResult CreateOffer([FromRoute] int itemId, [FromBody] CreateOfferRequestJson request)
        {
            return Ok();
        }
    }
}
