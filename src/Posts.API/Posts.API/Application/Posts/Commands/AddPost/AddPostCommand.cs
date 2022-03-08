using MediatR;
using Posts.API.Domain;

namespace Posts.API.Application.Posts.Commands.AddPost
{
    public class AddPostCommand : IRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class AddPostCommandHandler : IRequestHandler<AddPostCommand>
    {
        public async Task<Unit> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            TempPostData.Posts.Add(new Post { Id = Guid.NewGuid(), Title = request.Title, Content= request.Content });
            return Unit.Value;
        }
    }
}
