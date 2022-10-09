namespace BlogSample.Domain
{
    public class Post : Entity
    {
        public int Id { get; set; }
        private string content;
        private DateTime createDate;
        public Post()
        {

        }

        public Post(string content, DateTime createDate)
        {
            this.content = content;
            this.createDate = createDate;
        }


        public static Post AddPost(string content, DateTime createDate)
        {
            return new Post(content, createDate);
        }
    }
}