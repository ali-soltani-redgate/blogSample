using MediatR;

namespace BlogSample.ApplicationService
{
    public record AddBlogCommand: IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}