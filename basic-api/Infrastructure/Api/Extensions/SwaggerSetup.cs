using Microsoft.OpenApi.Models;

namespace basic_api.Infrastructure.Api.Extensions
{
    public static class SwaggerSetup
    {
            public static void AddSwagger(this IServiceCollection services)
            {
                services.AddSwaggerGen();
            }

    }
}
