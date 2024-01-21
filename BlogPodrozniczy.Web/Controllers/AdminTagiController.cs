using BlogPodrozniczy.Web.Data;
using BlogPodrozniczy.Web.Models.Domena;
using BlogPodrozniczy.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogPodrozniczy.Web.Controllers
{
    public class AdminTagiController : Controller
    {
        private readonly BlogDB blogDB;

        public AdminTagiController(BlogDB blogDB)
        {
            this.blogDB = blogDB;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            // Mapping AddTagRequest to Tag domain model
            var tag = new Tag
            {
                Nazwa = addTagRequest.Nazwa,
                WyświetlanaNazwa = addTagRequest.WyświetlanaNazwa
            };

            blogDB.Tagi.Add(tag);
            blogDB.SaveChanges();

            return View("Add");
        }
    }
}
