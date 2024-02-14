using BlogPodrozniczy.Web.Models.Domena;

namespace BlogPodrozniczy.Web.Models.ViewModels
{
    public class BlogDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Nagłówek { get; set; }
        public string TytułStrony { get; set; }
        public string Treść { get; set; }
        public string KrótkiOpis { get; set; }
        public string UrlZdjęcia { get; set; }
        public string UrlHandle { get; set; }
        public DateTime DataPublikacji { get; set; }
        public string Autor { get; set; }
        public bool Widoczność { get; set; }
        public ICollection<Tag> Tagi { get; set; }

        public int TotalLikes { get; set; }

        public bool Liked { get; set; }
        public string CommentDescription { get; set; }
        public IEnumerable<BlogComment> Comments { get; set; }
    }
}
