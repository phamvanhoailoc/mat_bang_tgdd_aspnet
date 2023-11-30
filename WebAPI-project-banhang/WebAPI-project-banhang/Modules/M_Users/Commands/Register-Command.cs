using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_User.Models;
using WebAPI_project_banhang.Modules.M_User.Repositories;
using WebAPI_project_banhang.Modules.M_User.ViewModels;

namespace WebAPI_project_banhang.Modules.M_Users.Commands
{

    public class RegisterCommand : IRequest<User>
    {
        public RegisterViewModel _registerViewModel { get; set; }

        public RegisterCommand(RegisterViewModel registerViewModel)
        {
            _registerViewModel = registerViewModel;
        }
    }

    public class RegisterCommandHandler: IRequestHandler<RegisterCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existingUserByUsername = await _userRepository.GetByUsername(request._registerViewModel);
            if (existingUserByUsername != null)
            {
                throw new ArgumentException("Username already exists");
            }

            // Add additional logic here if needed, such as role assignment

            return await _userRepository.CreateUser(request._registerViewModel);
        }
        
    }
}
