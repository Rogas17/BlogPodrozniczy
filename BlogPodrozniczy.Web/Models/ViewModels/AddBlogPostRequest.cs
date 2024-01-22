using BlogPodrozniczy.Web.Models.Domena;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogPodrozniczy.Web.Models.ViewModels
{
    public class AddBlogPostRequest
    {
        public string Nagłówek { get; set; }
        public string TytułStrony { get; set; }
        public string Treść { get; set; }
        public string KrótkiOpis { get; set; }
        public string UrlZdjęcia { get; set; }
        public string UrlHandle { get; set; }
        public DateTime DataPublikacji { get; set; }
        public string Autor { get; set; }
        public bool Widoczność { get; set; }

        public IEnumerable<SelectListItem> Tagi { get; set; }
        public string[] SelectedTags { get; set; } = Array.Empty<string>();
    }
}
