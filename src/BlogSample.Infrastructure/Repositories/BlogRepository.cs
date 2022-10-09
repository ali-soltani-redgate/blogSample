using BlogSample.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogSample.Infrastructure
{
    public class BlogRepository : DbContext, IBlogRepository
    {
        private readonly BloggingContext _bloggingContext;

        public BlogRepository(BloggingContext context)
        {
            _bloggingContext = context;
        }

        public IUnitOfWork UnitOfWork => _bloggingContext;

        public async Task<Blog> Add(Blog blog)
        {
           return  (await _bloggingContext.Blogs.AddAsync(blog)).Entity;
        }
    }
}