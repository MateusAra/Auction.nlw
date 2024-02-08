﻿using Auction.Api.Communication.Requests;
using Auction.Api.Filters;
using Auction.Api.UseCases.Auctions.Offer;
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

            return Created(string.Empty, id);
        }
    }
}
