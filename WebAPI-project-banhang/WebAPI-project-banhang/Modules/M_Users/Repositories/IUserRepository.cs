using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_User.Models;
using WebAPI_project_banhang.Modules.M_User.ViewModels;
using WebAPI_project_banhang.Modules.M_Users.ViewModels;

namespace WebAPI_project_banhang.Modules.M_User.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUser(RegisterViewModel registerViewModel);
        Task<User> GetByUsername(RegisterViewModel registerViewModel);
        Task<User> LoginUser(LoginViewModel loginViewModel);
    }
}
