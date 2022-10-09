using BlogSample.Domain;
using MediatR;

namespace BlogSample.ApplicationService
{
    public class AddBlogCommandHandler : IRequestHandler<AddBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;

        public AddBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<int> Handle(AddBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = Blog.Add(request.Name, request.Description);
            await _blogRepository.Add(blog);
            await _blogRepository.UnitOfWork.SaveEntitiesAsync();
            return blog.Id;
        }
    }
}