namespace BlogSample.Domain
{
    public interface IBlogRepository: IRepository<Blog>
    {
        Task<Blog> Add(Blog blog);
        Task<Blog> Get(int blogId);
        void Update(Blog blog);
    }
}