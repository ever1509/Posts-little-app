using MediatR;
using Posts.API.Domain;

namespace Posts.API.Application.Posts.Queries.Posts
{
    public class PostsQuery : IRequest<List<Post>>
    {
    }

    public class PostsQueryHandler : IRequestHandler<PostsQuery, List<Post>>
    {
        private List<Post> _posts;
        public PostsQueryHandler()
        {
            _posts = new List<Post>()
            {
                new Post(){ Id = Guid.NewGuid(), Title="First server-side post", Content="This is coming from the server"},
                new Post(){ Id = Guid.NewGuid(), Title="Second server-side post", Content="This is coming from the server"},
            };
        }
        public async Task<List<Post>> Handle(PostsQuery request, CancellationToken cancellationToken)
        {
            return _posts.ToList();
        }
    }
}
