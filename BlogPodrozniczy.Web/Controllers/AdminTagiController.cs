using BlogPodrozniczy.Web.Data;
using BlogPodrozniczy.Web.Models.Domena;
using BlogPodrozniczy.Web.Models.ViewModels;
using BlogPodrozniczy.Web.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogPodrozniczy.Web.Controllers
{
    public class AdminTagiController : Controller
    {
        private readonly ITagRepository tagRepository;

        public AdminTagiController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            // Mapping AddTagRequest to Tag domain model
            var tag = new Tag
            {
                Nazwa = addTagRequest.Nazwa,
                WyświetlanaNazwa = addTagRequest.WyświetlanaNazwa
            };

            await tagRepository.AddAsync(tag);

            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            var tagi = await tagRepository.GetAllAsync();



			return View(tagi);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id) 
        {
            var tag = await tagRepository.GetAsync(id);

            if(tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Nazwa = tag.Nazwa,
                    WyświetlanaNazwa = tag.WyświetlanaNazwa
                };

                return View(editTagRequest);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Nazwa = editTagRequest.Nazwa,
                WyświetlanaNazwa = editTagRequest.WyświetlanaNazwa
            };

            var updatedTag = await tagRepository.UpdateAsync(tag);

           
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
            var deletedTag = await tagRepository.DeleteAsync(editTagRequest.Id);

            if(deletedTag != null)
            {
                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }
    }
}
