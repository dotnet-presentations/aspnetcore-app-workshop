using System.Threading.Tasks;

namespace FrontEnd.Services
{
    public interface IAdminService
    {
        long CreationKey { get; set; }

        Task<bool> AllowAdminUserCreationAsync();
    }
}