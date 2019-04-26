using System.Threading.Tasks;

namespace FrontEnd.Services
{
    public interface IAdminService
    {
        long CreationKey { get; }

        Task<bool> AllowAdminUserCreationAsync();
    }
}