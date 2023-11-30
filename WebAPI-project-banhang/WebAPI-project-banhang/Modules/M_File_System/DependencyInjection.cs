
using Microsoft.Extensions.DependencyInjection;
using WebAPI_project_banhang.Modules.M_File_System.Repositories;
using WebAPI_project_banhang.Modules.M_File_System.Services;

namespace WebAPI_project_banhang.Modules.M_File_System
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFileSystem(this IServiceCollection services) {
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IUploadRepository, UploadRepository>();
            //services.AddDbContext<UserContext>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            return services;
        }
    }
}
