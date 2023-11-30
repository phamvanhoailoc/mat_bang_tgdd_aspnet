using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI_project_banhang.Modules.M_User.Repositories;
using WebAPI_project_banhang.Modules.M_User.Services;
using WebAPI_project_banhang.Modules.M_Users.Models;

namespace WebAPI_project_banhang.Modules.M_User
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUsers(this IServiceCollection services) {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<UserContext>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            return services;
        }
    }
}
