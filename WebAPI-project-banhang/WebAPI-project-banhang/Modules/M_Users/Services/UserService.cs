using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_User.Models;
using WebAPI_project_banhang.Modules.M_User.ViewModels;
using WebAPI_project_banhang.Modules.M_Users.Commands;
using WebAPI_project_banhang.Modules.M_Users.Queries;
using WebAPI_project_banhang.Modules.M_Users.ViewModels;

namespace WebAPI_project_banhang.Modules.M_User.Services
{
    public class UserService : IUserService
    {
        private readonly ISender _sender;

        public UserService(ISender sender)
        {
            _sender = sender;
        }

        public async Task<User> RegisterUser([FromBody]RegisterViewModel registerViewModel)
        { 
            return await _sender.Send(new RegisterCommand(registerViewModel));
        }

        public async Task<string> LoginUser([FromBody] LoginViewModel loginViewModel)
        {
            return await _sender.Send(new LoginQuery(loginViewModel));
        }
    }
}
