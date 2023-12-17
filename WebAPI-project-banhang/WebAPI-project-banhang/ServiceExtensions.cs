namespace WebAPI_project_banhang
{
    using Microsoft.Extensions.DependencyInjection;
    using WebAPI_project_banhang.Modules.M_File_System;
    using WebAPI_project_banhang.Modules.M_Sieu_Thi;
    using WebAPI_project_banhang.Modules.M_User;

    public static class ServiceExtensions
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddUsers();
            services.AddFileSystem();
            services.AddSieuThi();
            // Thêm các dịch vụ khác nếu cần
        }
    }
}
