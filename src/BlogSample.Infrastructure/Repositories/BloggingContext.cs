using BlogSample.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogSample.Infrastructure
{
    public class BloggingContext : DbContext, IUnitOfWork
    {
        public DbSet<Blog> Blogs { get; set; }
       
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await base.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}