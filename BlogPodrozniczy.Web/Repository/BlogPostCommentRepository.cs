using BlogPodrozniczy.Web.Data;
using BlogPodrozniczy.Web.Models.Domena;
using Microsoft.EntityFrameworkCore;

namespace BlogPodrozniczy.Web.Repository
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly BlogDB blogDB;

        public BlogPostCommentRepository(BlogDB blogDB)
        {
            this.blogDB = blogDB;
        }
        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
            await blogDB.BlogPostComment.AddAsync(blogPostComment);
            await blogDB.SaveChangesAsync();
            return blogPostComment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId)
        {
            return await blogDB.BlogPostComment.Where(x => x.BlogPostId == blogPostId)
                .ToListAsync();
        }
    }
}
