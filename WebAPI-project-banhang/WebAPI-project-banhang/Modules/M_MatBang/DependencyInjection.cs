using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI_project_banhang.Modules.M_MatBang.Repositories;
using WebAPI_project_banhang.Modules.M_MatBang.Services;
using WebAPI_project_banhang.Modules.M_MatBang.Models;

namespace WebAPI_project_banhang.Modules.M_MatBang
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMatBang(this IServiceCollection services) {
            services.AddScoped<IMatBangService, MatBangService>();
            services.AddScoped<IGetMatBangListRepositories, GetMatBangListRepositories>();
            services.AddDbContext<MatBangContext>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            return services;
        }
    }
}
