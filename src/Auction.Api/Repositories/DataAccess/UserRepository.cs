using Auction.Api.Entities;
using Auction.Api.Repositories.DataAccess.Interfaces;

namespace Auction.Api.Repositories.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly AuctionDbContext _context;

        public UserRepository(AuctionDbContext context)
        {
            _context = context;
        }

        public bool ExistsUser(string email)
        {
            return _context.Users.Any(x => x.Email.Equals(email));
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.First(x => x.Email.Equals(email));
        }
    }
}
