using BlogSample.Domain;
using MediatR;

namespace BlogSample.ApplicationService
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, Blog>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Blog> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            return await _blogRepository.Get(request.BlogId);
        }
    }
}