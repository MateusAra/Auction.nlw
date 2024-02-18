using Auction.Api.Entities;
using Auction.Api.Repositories;
using Auction.Api.Repositories.DataAccess.Interfaces;

namespace Auction.Api.Services
{
    public class LoggedUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        public LoggedUser(IHttpContextAccessor httpContext, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContext;
            _userRepository = userRepository;
        }

        public User User()
        {
            var token = TokenOnRequest();
            var email = FromBase64String(token);

            return _userRepository.GetUserByEmail(email);
        }

        private string TokenOnRequest()
        {
            var authorization = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

            return authorization["Bearer ".Length..];
        }

        private string FromBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);

            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}
