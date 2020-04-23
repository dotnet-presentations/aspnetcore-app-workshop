using System.Threading.Tasks;

namespace BlazorFrontEnd.Services
{
    public interface IAdminService
    {
        Task<bool> AllowAdminUserCreationAsync();
    }
}