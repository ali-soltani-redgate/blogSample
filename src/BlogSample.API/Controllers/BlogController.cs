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
            return CreatedAtRoute(nameof(GetApplicant), new { id = blogId }, new { blogId });
        }

        [HttpGet("{id:int}", Name = nameof(GetApplicant))]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Blog))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Blog>> GetApplicant(int id)
        {
            // var applicant = await _mediator.Send(new GetApplicantQuery() { ApplicantId = id });
            // if (applicant == null)
            //     return NotFound(new { Message = $"Applicant with id {id} not found." });
            return Ok();
        }

    }
}