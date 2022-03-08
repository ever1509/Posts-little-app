namespace Posts.API.Domain
{
    public class TempPostData
    {
        public static List<Post> Posts = new List<Post>()
        {
            new Post(){ Id = Guid.NewGuid(), Title="First server-side post", Content="This is coming from the server"},
            new Post(){ Id = Guid.NewGuid(), Title="Second server-side post", Content="This is coming from the server"},
        };
    }
}
