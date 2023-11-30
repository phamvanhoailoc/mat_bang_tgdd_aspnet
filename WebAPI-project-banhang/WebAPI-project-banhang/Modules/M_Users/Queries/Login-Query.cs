using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using WebAPI_project_banhang.Modules.M_User.Models;
using WebAPI_project_banhang.Modules.M_User.Repositories;
using WebAPI_project_banhang.Modules.M_User.ViewModels;
using WebAPI_project_banhang.Modules.M_Users.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebAPI_project_banhang.Modules.M_Users.Queries
{
    public class LoginQuery : IRequest<string>
    {
        public LoginViewModel _loginViewModel { get; set; }

        public LoginQuery(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
        }
    }
    public class LoginQueryHandler : IRequestHandler<LoginQuery, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public LoginQueryHandler(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }
        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {

            User user = await _userRepository.LoginUser(request._loginViewModel);
            if (user != null)
            {
                //tạo ra jwt string để gửi cho client
                //Nếu xác thực thành công, tạo JWT token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config["Jwt:SecretKey"] ?? "");
                var roles = new List<string> { "100", "102", "103" }; // Danh sách các role mặc định
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Role,JsonConvert.SerializeObject(roles)),
                    }),
                    Expires = DateTime.UtcNow.AddDays(30),
                    SigningCredentials = new SigningCredentials
                        (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                return jwtToken;
            }
            else
            {
                throw new ArgumentException("Wrong email or password");
            }
        }
    }
}
