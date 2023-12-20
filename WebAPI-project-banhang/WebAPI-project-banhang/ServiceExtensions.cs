namespace WebAPI_project_banhang
{
    using Microsoft.Extensions.DependencyInjection;
    using WebAPI_project_banhang.Modules.M_DanhGia;
    using WebAPI_project_banhang.Modules.M_File_System;
    using WebAPI_project_banhang.Modules.M_MatBang;
    using WebAPI_project_banhang.Modules.M_Sieu_Thi;
    using WebAPI_project_banhang.Modules.M_TieuChi;
    using WebAPI_project_banhang.Modules.M_User;

    public static class ServiceExtensions
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddUsers();
            services.AddFileSystem();
            services.AddMatBang();
            services.AddSieuThi();
            services.AddTieuChi();
            services.AddDanhGia();
            // Thêm các dịch vụ khác nếu cần
        }
    }
}
