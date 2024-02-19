using Auction.Api.Entities;
using Auction.Api.Enums;
using Auction.Api.Repositories.DataAccess.Interfaces;
using Auction.Api.UseCases.Auctions.GetCurrent;
using Bogus;
using ExpectedObjects;
using FluentAssertions;
using Moq;

namespace UseCases.Test.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCaseTest
    {
        [Fact]
        public void Success()
        {
            //Arrange
            var expectedAuctions = new List<Auction.Api.Entities.Auction> 
            {
                 new Faker<Auction.Api.Entities.Auction>()
                        .RuleFor(a => a.Id, f => f.Random.Number(1, 1000))
                        .RuleFor(a => a.Name, f => f.Lorem.Word())
                        .RuleFor(a => a.Starts, f => f.Date.Past())
                        .RuleFor(a => a.Ends, f => f.Date.Future())
                        .RuleFor(a => a.Items, (f, a) => new List<Item>
                        {
                            new Item
                            {
                                Id = f.Random.Number(1, 1000),
                                Name = f.Lorem.Word(),
                                Brand = f.Commerce.Department(),
                                Condition = f.PickRandom<Condition>(),
                                BasePrice = f.Random.Decimal(50, 300),
                                AuctionId = a.Id
                            }
                        })
            };
            var mock = new Mock<IAuctionRepository>();
            mock.Setup(x => x.GetCurrentAuction()).Returns(expectedAuctions);
            var useCase = new GetCurrentAuctionUseCase(mock.Object);

            //Act
            var auctions = useCase.Execute();

            //Assert
            auctions.Should().NotBeNullOrEmpty();
            auctions.Count.Should().NotBe(0);
        }
    }
}