using Auction.Api.UseCases.Auctions.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Api.Controllers;

[Route("/[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    [HttpGet]
    public IActionResult GetCurrentAuction()
    {
        var useCase = new GetCurrentAuctionUseCase();

        var result = useCase.Execute();

        return Ok(result);
    }
}
