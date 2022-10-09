using BlogSample.Domain;
using MediatR;

namespace BlogSample.ApplicationService
{
   
    public class AddPostCommandHandler : IRequestHandler<AddPostCommand>
    {
        private readonly IBlogRepository _blogRepository;

        public AddPostCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Unit> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            Blog blog = await _blogRepository.Get(request.BlogId);
            blog.AddPost(request.Name, DateTime.Now);
            _blogRepository.Update(blog); // TODO It should change to the following code
            // _postRepository.Add(request.blogId, request.name, request.description)
            await _blogRepository.UnitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }

    }
}