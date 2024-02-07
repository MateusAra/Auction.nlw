using Auction.Api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Auction.Api.Filters
{
    public class AuthenticateUserAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var token = TokenOnRequest(context.HttpContext);

                var repository = new AuctionDbContext();

                var email = FromBase64String(token);

                var exist = repository.Users.Any(x => x.Email.Equals(email));

                if (exist is false)
                {
                    context.Result = new UnauthorizedObjectResult("Email is not valid.");
                }
            }
            catch (Exception ex)
            {
                context.Result = new UnauthorizedObjectResult(ex.Message);
            }
        }

        private string TokenOnRequest(HttpContext context)
        {
            var authorization = context.Request.Headers.Authorization.ToString();

            if(string.IsNullOrEmpty(authorization))
            {
                throw new Exception("Token is missing.");
            }

            return authorization["Bearer ".Length..];
        }

        private string FromBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);

            return System.Text.Encoding.UTF8.GetString(data);   
        }
    }
}
