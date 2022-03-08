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
            _posts = TempPostData.Posts;
        }
        public async Task<List<Post>> Handle(PostsQuery request, CancellationToken cancellationToken)
        {
            return _posts.ToList();
        }
    }
}
