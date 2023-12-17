
using Microsoft.Extensions.DependencyInjection;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.Models;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.Repositories;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.Services;

namespace WebAPI_project_banhang.Modules.M_Sieu_Thi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSieuThi(this IServiceCollection services) {
            services.AddScoped<ISieuThiService, SieuThiService>();
            services.AddScoped<ISieuThiRepositories, SieuThiRepositories>();
            services.AddDbContext<SieuThiContext>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            return services;
        }
    }
}
