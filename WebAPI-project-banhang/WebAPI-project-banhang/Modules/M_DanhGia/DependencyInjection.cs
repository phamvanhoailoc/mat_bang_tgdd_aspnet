
using Microsoft.Extensions.DependencyInjection;
using WebAPI_project_banhang.Modules.M_DanhGia.Models;
using WebAPI_project_banhang.Modules.M_DanhGia.Repositories;
using WebAPI_project_banhang.Modules.M_DanhGia.Services;

namespace WebAPI_project_banhang.Modules.M_DanhGia
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDanhGia(this IServiceCollection services) {
            services.AddScoped<IDanhGiaService, DanhGiaService>();
            services.AddScoped<IDanhGiaRepositories, DanhGiaRepositories>();
            services.AddDbContext<DanhGiaContext>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            return services;
        }
    }
}
