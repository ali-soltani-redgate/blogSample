using System.Net.Mime;
using BlogSample.ApplicationService;
using BlogSample.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogSample.API
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator) =>
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
         public async Task<IActionResult> AddApplicant([FromBody] AddBlogCommand addBlogCommand)
        {
            var blogId = await _mediator.Send(addBlogCommand);
            return CreatedAtRoute(nameof(GetBlog), new { id = blogId }, new { blogId });
        }

        [HttpGet("{id:int}", Name = nameof(GetBlog))]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Blog))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            var blog = await _mediator.Send(new GetBlogQuery() { BlogId = id });
            if (blog == null)
                return NotFound(new { Message = $"Blog with id {id} not found." });
            return Ok();
        }


        [HttpPost("addPost")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPost([FromBody] AddPostCommand addPostCommand)
        {
            var blogId = await _mediator.Send(addPostCommand);
            //return CreatedAtRoute(nameof(GetBlog), new { id = blogId }, new { blogId });
            return Ok();
        }

    }
}