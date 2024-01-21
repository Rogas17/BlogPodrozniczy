namespace BlogPodrozniczy.Web.Models.Domena
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Nazwa { get; set; }
        public string PokazanaNazwa { get; set; }
        public ICollection<BlogPost> Posty { get; set; }
    }
}
