
using Auction.Api.Filters;
using Auction.Api.Repositories;
using Auction.Api.Repositories.DataAccess;
using Auction.Api.Repositories.DataAccess.Interfaces;
using Auction.Api.Services;
using Auction.Api.UseCases.Auctions.GetCurrent;
using Auction.Api.UseCases.Auctions.Offer.CreateOffer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Auction.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT authorization header using bearer scheme.
                                    Enter 'Bearer' [space] and then your token in the text input below.
                                      Example: 'Bearer QkFTRSA2NA=='",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            builder.Services.AddScoped<AuthenticateUserAttribute>();

            builder.Services.AddScoped<ILoggedUser, LoggedUser>();

            builder.Services.AddScoped<CreateOfferUseCase>();
            builder.Services.AddScoped<GetCurrentAuctionUseCase>();

            builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
            builder.Services.AddScoped<IOfferRepository, OfferRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddDbContext<AuctionDbContext>(options => 
            {
                options.UseSqlite("Data Source=C:\\Users\\mateu\\source\\repos\\Auction.nlw\\src\\leilaoDbNLW.db");
            });


            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}