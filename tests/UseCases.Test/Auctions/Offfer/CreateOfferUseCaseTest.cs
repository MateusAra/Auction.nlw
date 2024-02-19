using Auction.Api.Communication.Requests;
using Auction.Api.Entities;
using Auction.Api.Enums;
using Auction.Api.Repositories.DataAccess.Interfaces;
using Auction.Api.Services;
using Auction.Api.UseCases.Auctions.Offer;
using Auction.Api.UseCases.Auctions.Offer.CreateOffer;
using Bogus;
using FluentAssertions;
using Moq;

namespace UseCases.Test.Auctions.Offfer
{
    public class CreateOfferUseCaseTest
    {
        [Theory]
        [InlineData(13)]
        [InlineData(12)]
        [InlineData(11)]
        [InlineData(10)]
        public void Success(int itemId)
        {
            //Arrage
            var user = new Faker<User>()
                .RuleFor(u => u.Id, f => f.Random.Number(1, 50))
                .RuleFor(u => u.Name, f => f.Name.FirstName())
                .RuleFor(u => u.Email, f => f.Internet.Email()).Generate();
            var createOffer = new CreateOfferRequestJson
            {
                Price = new Faker().Random.Decimal(1, 50)
            };

            var offerMock = new Mock<IOfferRepository>();
            var loggedUserMock = new Mock<ILoggedUser>();
            loggedUserMock.Setup(x => x.User()).Returns(user);
            var useCase = new CreateOfferUseCase(loggedUserMock.Object, offerMock.Object);

            //Act
            var act = () => useCase.Execute(itemId, createOffer);

            //Assert
            act.Should().NotThrow();
        }
    }
}
