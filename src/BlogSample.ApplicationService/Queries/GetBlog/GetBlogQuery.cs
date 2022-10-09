using BlogSample.Domain;
using MediatR;

namespace BlogSample.ApplicationService
{
    public class GetBlogQuery: IRequest<Blog>
    {
        public int BlogId { get; set; }
    }
}