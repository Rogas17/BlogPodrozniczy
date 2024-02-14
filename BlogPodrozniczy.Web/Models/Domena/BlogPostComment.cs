namespace BlogPodrozniczy.Web.Models.Domena
{
    public class BlogPostComment
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public Guid BlogPostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
