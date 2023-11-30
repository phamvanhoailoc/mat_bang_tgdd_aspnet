using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_User.Models;
using WebAPI_project_banhang.Modules.M_User.ViewModels;
using WebAPI_project_banhang.Modules.M_Users.Models;
using WebAPI_project_banhang.Modules.M_Users.ViewModels;

namespace WebAPI_project_banhang.Modules.M_User.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;  
        }

        //tạo mới 1 user
        public async Task<User> CreateUser(RegisterViewModel registerViewModel)
        {
            //đoạn này sẽ gọi procedure trong SQL
            string sql = "EXECUTE dbo.RegisterUser @user_name, @hash_password, @created_at";
            IEnumerable<User> result = await _context.Users.FromSqlRaw(sql,
                    new SqlParameter("@user_name", registerViewModel.UserName),
                    new SqlParameter("@hash_password", registerViewModel.HashPassword),
                    new SqlParameter("@created_at", registerViewModel.CreatedAt)
                ).ToListAsync();

            //gán kết quả cho modal user
            User user = result.FirstOrDefault();

            return user; //trả về đối tượng user

        }

        //kiểm tra tên đã tồn tại trong db chưa
        public async Task<User> GetByUsername(RegisterViewModel registerViewModel)
        {
            //đoạn này sẽ gọi procedure trong SQL
            string sql = "EXECUTE dbo.CheckUserNameExists @user_name";
            IEnumerable<User> result = await _context.Users.FromSqlRaw(sql,
                    new SqlParameter("@user_name", registerViewModel.UserName)
                ).ToListAsync();

            //gán kết quả cho modal user
            User user = result.FirstOrDefault();

            return user; //trả về đối tượng user

        }

        //kiểm tra đăng nhập
        public async Task<User> LoginUser(LoginViewModel loginViewModel)
        {
            //đoạn này sẽ gọi procedure trong SQL
            string sql = "EXECUTE dbo.CheckLogin @user_name, @hash_password";
            IEnumerable<User> result = await _context.Users.FromSqlRaw(sql,
                    new SqlParameter("@user_name", loginViewModel.UserName),
                    new SqlParameter("@hash_password", loginViewModel.HashPassword)
                ).ToListAsync();

            //gán kết quả cho modal user
            User user = result.FirstOrDefault();

            if (user == null) throw new ArgumentException("Wrong email or password");

            return user;

        }
    }
}
