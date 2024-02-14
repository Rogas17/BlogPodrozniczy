using BlogPodrozniczy.Web.Data;
using BlogPodrozniczy.Web.Models.Domena;
using Microsoft.EntityFrameworkCore;

namespace BlogPodrozniczy.Web.Repository
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BlogDB blogDB;

        public BlogPostLikeRepository(BlogDB blogDB)
        {
            this.blogDB = blogDB;
        }

        public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
        {
            await blogDB.BlogPostLike.AddAsync(blogPostLike);
            await blogDB.SaveChangesAsync();
            return blogPostLike;
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            return await blogDB.BlogPostLike.Where(x => x.BlogPostId == blogPostId)
                .ToListAsync();
        }

        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
            return await blogDB.BlogPostLike
                .CountAsync(x => x.BlogPostId == blogPostId);
        }
    }
}
