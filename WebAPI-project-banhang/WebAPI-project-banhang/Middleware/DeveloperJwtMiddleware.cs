using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace WebAPI_project_banhang.Middleware
{
    public class DeveloperJwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;

        public DeveloperJwtMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task Invoke(HttpContext context)
        {
            // Thêm JWT vào header Authorization
            context.Request.Headers.Add("Authorization", _config["Jwt:keyDevelop"]);

            await _next(context);
        }
    }
}
