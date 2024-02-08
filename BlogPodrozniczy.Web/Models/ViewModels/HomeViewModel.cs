using BlogPodrozniczy.Web.Models.Domena;

namespace BlogPodrozniczy.Web.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<BlogPost> BlogPosts { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
    }
}
