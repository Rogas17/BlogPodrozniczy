using Microsoft.AspNetCore.Identity;

namespace BlogPodrozniczy.Web.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
