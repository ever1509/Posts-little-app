using MediatR;
using Microsoft.AspNetCore.Mvc;
using Posts.API.Application.Posts.Queries.Posts;
using Posts.API.Domain;

namespace Posts.API.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> Get()
        {
            return await _mediator.Send(new PostsQuery());
        }
    }
}
