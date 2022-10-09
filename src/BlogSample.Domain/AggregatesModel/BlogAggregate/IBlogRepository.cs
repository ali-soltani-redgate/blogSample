namespace BlogSample.Domain
{
    public interface IBlogRepository: IRepository<Blog>
    {
        Task<Blog> Add(Blog blog);
    }
}