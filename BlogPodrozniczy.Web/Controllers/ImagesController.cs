using BlogPodrozniczy.Web.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlogPodrozniczy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            var urlZdjęcia = await imageRepository.UploadAsync(file);
            if (urlZdjęcia == null)
            {
                return Problem("Coś poszło nie tak", null, (int)HttpStatusCode.InternalServerError);
            }

            return new JsonResult(new { link = urlZdjęcia });
        }
    }
}
