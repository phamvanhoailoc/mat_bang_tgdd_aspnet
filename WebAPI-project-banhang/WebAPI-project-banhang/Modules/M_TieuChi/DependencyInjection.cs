
using Microsoft.Extensions.DependencyInjection;
using WebAPI_project_banhang.Modules.M_TieuChi.Models;
using WebAPI_project_banhang.Modules.M_TieuChi.Repositories;
using WebAPI_project_banhang.Modules.M_TieuChi.Services;

namespace WebAPI_project_banhang.Modules.M_TieuChi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTieuChi(this IServiceCollection services) {
            services.AddScoped<ITieuChiService, TieuChiService>();
            services.AddScoped<ITieuChiRepositories, TieuChiRepositories>();
            services.AddDbContext<TieuChiContext>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            return services;
        }
    }
}
