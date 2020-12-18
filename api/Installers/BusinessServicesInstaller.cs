using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using api.Helpers;
using api.Services;

namespace api.Installers
{
    public class BusinessServicesInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            /** Common services */
            services.AddScoped<IPaginationHelpers, PaginationHelpers>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IPriceCalculateHelpers, PriceCalculateHelpers>();

            /** Real business services */
            services.AddScoped<IProductsService, ProductsService>();
        }
    }
}