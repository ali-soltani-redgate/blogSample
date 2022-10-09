using MediatR;

namespace BlogSample.ApplicationService
{
    public record AddPostCommand: IRequest
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
    }
}