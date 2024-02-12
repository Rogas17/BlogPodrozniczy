namespace BlogPodrozniczy.Web.Models.ViewModels
{
    public class LoginViewModel
    {
        public string NazwaUżytkownika { get; set; }
        public string Hasło { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
