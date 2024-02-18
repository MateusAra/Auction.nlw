using Auction.Api.Entities;

namespace Auction.Api.Repositories.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
        bool ExistsUser(string email);
    }
}
