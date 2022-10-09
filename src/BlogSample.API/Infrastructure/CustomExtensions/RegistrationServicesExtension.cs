using BlogSample.Domain;
using BlogSample.Infrastructure;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RegistrationServicesExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<BloggingContext>(options => options.UseInMemoryDatabase(databaseName: "test"), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
            services.AddTransient<IBlogRepository, BlogRepository>();
            return services;
        }

        
    }

    public class Services
    {
    }
}