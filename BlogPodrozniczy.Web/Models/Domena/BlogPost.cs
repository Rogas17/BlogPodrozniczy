namespace BlogPodrozniczy.Web.Models.Domena
{
    public class BlogPost
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
    }
}
