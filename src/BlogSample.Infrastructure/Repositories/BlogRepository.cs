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

        public async Task<Blog> Get(int blogId) => await _bloggingContext.Blogs.FirstOrDefaultAsync(b => b.Id == blogId);

         public void Update(Blog blog) => 
            _bloggingContext.Entry(blog).State = EntityState.Modified;

    }
}