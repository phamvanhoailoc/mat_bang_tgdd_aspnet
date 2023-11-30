using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
using WebAPI_project_banhang.Middleware;
using WebAPI_project_banhang.Modules.M_File_System;
using WebAPI_project_banhang.Modules.M_User;


namespace WebAPI_project_banhang
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var stringConnectdb = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BanhangContext>(options => options.UseSqlServer(stringConnectdb));
            //khai báo services, repositories vào group
            services.AddUsers();
            services.AddFileSystem();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI_project_banhang", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseMiddleware<DeveloperJwtMiddleware>();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI_project_banhang v1"));
            }
            
            app.UseHttpsRedirection();

            app.UseStaticFiles(); // cho phép đọc file tĩnh bao gồm ảnh 

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
