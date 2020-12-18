using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;

namespace api.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {

            services
                .AddControllers(options =>
                {
                    // options.Filters.Add<ValidationFilter>();
                })
                    .ConfigureApiBehaviorOptions(options =>
                    {
                        options.SuppressConsumesConstraintForFormFileParameters = true;
                        options.SuppressInferBindingSourcesForParameters = true;
                        options.SuppressModelStateInvalidFilter = true;
                        options.SuppressMapClientErrors = true;
                        options.ClientErrorMapping[404].Link =
                            "https://httpstatuses.com/404";
                        options.InvalidModelStateResponseFactory = context =>
                        {
                            var result = new BadRequestObjectResult(context.ModelState);

                            // TODO: add `using System.Net.Mime;` to resolve MediaTypeNames
                            result.ContentTypes.Add(MediaTypeNames.Application.Json);
                            result.ContentTypes.Add(MediaTypeNames.Application.Xml);

                            return result;
                        };
                    });

        }
    }
}