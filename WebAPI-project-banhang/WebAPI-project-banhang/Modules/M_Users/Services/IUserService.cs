using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_User.Models;
using WebAPI_project_banhang.Modules.M_User.ViewModels;
using WebAPI_project_banhang.Modules.M_Users.ViewModels;

namespace WebAPI_project_banhang.Modules.M_User.Services
{
    public interface IUserService
    {
        Task<User> RegisterUser(RegisterViewModel registerViewModel);
        Task<string> LoginUser(LoginViewModel loginViewModel);
    }
}
