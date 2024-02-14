using BlogPodrozniczy.Web.Models.Domena;

namespace BlogPodrozniczy.Web.Repository
{
    public interface IBlogPostCommentRepository
    {
        Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment);

        Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId);
    }
}
