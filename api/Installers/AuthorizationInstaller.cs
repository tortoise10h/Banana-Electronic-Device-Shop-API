using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace api.Installers
{
    public class AuthorizationInstaller : IInstaller
    {
        public void InstallServices(
            IConfiguration configuration,
            IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
            });
        }
    }
}