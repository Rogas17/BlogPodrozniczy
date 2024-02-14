using BlogPodrozniczy.Web.Models.Domena;
using BlogPodrozniczy.Web.Models.ViewModels;
using BlogPodrozniczy.Web.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPodrozniczy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostLikeController : ControllerBase
    {
        private readonly IBlogPostLikeRepository blogPostLikeRepository;

        public BlogPostLikeController(IBlogPostLikeRepository blogPostLikeRepository)
        {
            this.blogPostLikeRepository = blogPostLikeRepository;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddLike([FromBody] AddLikeRequest addLikeRequest)
        {
            var model = new BlogPostLike
            {
                BlogPostId = addLikeRequest.BlogPostId,
                UserId = addLikeRequest.UserId,
            };

            await blogPostLikeRepository.AddLikeForBlog(model);
            return Ok();
        }

        [HttpGet]
        [Route("{blogPostId:Guid}/totalLikes")]
        public async Task<IActionResult> GetTotalLikesForBlog([FromRoute] Guid blogPostId)
        {
            var totalLikes = await blogPostLikeRepository.GetTotalLikes(blogPostId);

            return Ok(totalLikes);
        }
    }
}
