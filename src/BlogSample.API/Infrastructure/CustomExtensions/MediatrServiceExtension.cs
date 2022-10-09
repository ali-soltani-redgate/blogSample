
using BlogSample.ApplicationService;
using MediatR;

namespace BlogSample.API
{
    public static class MediatrServiceExtension
    {
        public static IServiceCollection AddCustomMediatr(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AddBlogCommandHandler));         

            return services;
        }
    }
}