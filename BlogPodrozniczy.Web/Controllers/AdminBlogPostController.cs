using BlogPodrozniczy.Web.Models.Domena;
using BlogPodrozniczy.Web.Models.ViewModels;
using BlogPodrozniczy.Web.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.OutputCaching;

namespace BlogPodrozniczy.Web.Controllers
{
    public class AdminBlogPostController : Controller
    {
        private readonly ITagRepository tagRepository;
        private readonly IBlogPostRepository blogPostRepository;

        public AdminBlogPostController(ITagRepository tagRepository, IBlogPostRepository blogPostRepository)
        {
            this.tagRepository = tagRepository;
            this.blogPostRepository = blogPostRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var tagi = await tagRepository.GetAllAsync();

            var model = new AddBlogPostRequest
            {
                Tagi = tagi.Select(x => new SelectListItem { Text = x.Nazwa, Value = x.Id.ToString() })
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBlogPostRequest addBlogPostRequest)
        {

            var blogPost = new BlogPost
            {
                Nagłówek = addBlogPostRequest.Nagłówek,
                TytułStrony = addBlogPostRequest.TytułStrony,
                Treść = addBlogPostRequest.Treść,
                KrótkiOpis = addBlogPostRequest.KrótkiOpis,
                UrlZdjęcia = addBlogPostRequest.UrlZdjęcia,
                UrlHandle = addBlogPostRequest.UrlHandle,
                DataPublikacji = addBlogPostRequest.DataPublikacji,
                Autor = addBlogPostRequest.Autor,
                Widoczność = addBlogPostRequest.Widoczność,
            };

            var selectedTags = new List<Tag>();
            foreach (var selectedTagId in addBlogPostRequest.SelectedTags)
            {
                var selectedTagAsGuid = Guid.Parse(selectedTagId);
                var existingTag = await tagRepository.GetAsync(selectedTagAsGuid);

                if (existingTag != null) 
                {
                    selectedTags.Add(existingTag);
                }
            }

            blogPost.Tagi = selectedTags;

            await blogPostRepository.AddAsync(blogPost);

            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> List() 
        {
            var posty = await blogPostRepository.GetAllAsync();

            return View(posty);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var blogPost = await blogPostRepository.GetAsync(id);
            var tagsDomainModel = await tagRepository.GetAllAsync();

            if (blogPost != null) 
            {
                var model = new EditBlogPostRequest
                {
                    Id = blogPost.Id,
                    Nagłówek = blogPost.Nagłówek,
                    TytułStrony = blogPost.TytułStrony,
                    Treść = blogPost.Treść,
                    Autor = blogPost.Autor,
                    UrlZdjęcia = blogPost.UrlZdjęcia,
                    UrlHandle = blogPost.UrlHandle,
                    KrótkiOpis = blogPost.KrótkiOpis,
                    DataPublikacji = blogPost.DataPublikacji,
                    Widoczność = blogPost.Widoczność,
                    Tagi = tagsDomainModel.Select(x => new SelectListItem
                    {
                        Text = x.Nazwa,
                        Value = x.Id.ToString()
                    }),
                    SelectedTags = blogPost.Tagi.Select(x => x.Id.ToString()).ToArray()
                };

                return View(model);
            }

            

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBlogPostRequest editBlogPostRequest)
        {
            var blogPostDomainModel = new BlogPost
            {
                Id = editBlogPostRequest.Id,
                Nagłówek = editBlogPostRequest.Nagłówek,
                TytułStrony = editBlogPostRequest.TytułStrony,
                Treść = editBlogPostRequest.Treść,
                Autor = editBlogPostRequest.Autor,
                KrótkiOpis = editBlogPostRequest.KrótkiOpis,
                UrlZdjęcia = editBlogPostRequest.UrlZdjęcia,
                UrlHandle = editBlogPostRequest.UrlHandle,
                DataPublikacji = editBlogPostRequest.DataPublikacji,
                Widoczność = editBlogPostRequest.Widoczność
            };

            var selectedTags = new List<Tag>();
            foreach (var selectedTag in editBlogPostRequest.SelectedTags)
            {
                if (Guid.TryParse(selectedTag, out var tag)) 
                {
                    var foundTag = await tagRepository.GetAsync(tag);
                    if (foundTag != null)
                    {
                        selectedTags.Add(foundTag);
                    }
                }
            }

            blogPostDomainModel.Tagi = selectedTags;

            var updatedBlog = await blogPostRepository.UpdateAsync(blogPostDomainModel);

            if (updatedBlog != null)
            {
                return RedirectToAction("Edit");
            }
            return RedirectToAction("Edit");
        }

        public async Task<IActionResult> Delete(EditBlogPostRequest editBlogPostRequest)
        {
            var deletedBlogPost = await blogPostRepository.DeleteAsync(editBlogPostRequest.Id);

            if (deletedBlogPost != null)
            {
                return RedirectToAction("List");
            }
            return RedirectToAction("Edit", new { id = editBlogPostRequest.Id });
        }
    }
}
