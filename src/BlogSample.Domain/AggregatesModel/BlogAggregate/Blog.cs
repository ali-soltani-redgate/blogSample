namespace BlogSample.Domain
{
    public class Blog : Entity, IAggregateRoot
    {

        public int Id { get; set; }
        public string Name { get; }
        public string Description { get; }
        private readonly List<Post> _posts;
        public IReadOnlyCollection<Post> Posts => _posts;

        public Blog(string name, string description)
        {
            Name = name;
            Description = description;

            _posts = new List<Post>();
        }

        public Blog()
        {
            _posts = new List<Post>();
        }

        public static Blog Add(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name should not be null or empty");
            }
            return new Blog(name, description);
        }

        public void AddPost(string content, DateTime createDate)
        {
            Post post = Post.AddPost(content, createDate);
            _posts.Add(post);
        }
    }
}