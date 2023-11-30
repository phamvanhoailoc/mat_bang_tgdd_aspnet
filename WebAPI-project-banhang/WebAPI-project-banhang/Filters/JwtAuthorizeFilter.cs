using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System;
using System.Linq;
using System.Security.Claims;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebAPI_project_banhang.Filters
{
    public class JwtAuthorizeFilter : IAuthorizationFilter
    {
        private readonly IConfiguration _config;
        private readonly string[] _requiredPermissions;
        public JwtAuthorizeFilter(IConfiguration config, params string[] requiredPermissions)
        {
            _config = config;
            _requiredPermissions = requiredPermissions;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var token = context.HttpContext.Request
                .Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("Jwt:SecretKey") ?? "");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    //Nếu token hết hạn,
                    //thì khi gọi phương thức ValidateToken,
                    //mã lỗi SecurityTokenExpiredException sẽ được throw ra
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                if (jwtToken.ValidTo < DateTime.UtcNow)
                {
                    // Token đã hết hạn
                    // Xử lý lỗi hoặc đăng nhập lại để tạo mới token
                    context.Result = new UnauthorizedResult();
                    return;
                }

                //lấy danh sách role
                var rolesClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value;
                if (!string.IsNullOrEmpty(rolesClaim))
                {
                    // Giải mã chuỗi JSON thành danh sách role
                    List<string> roles = JsonConvert.DeserializeObject<List<string>>(rolesClaim);

                    if (_requiredPermissions.Any() && !_requiredPermissions.All(roles.Contains))
                    {
                        // Người dùng không có tất cả các mã quyền cần thiết
                        context.Result = new ForbidResult();
                        return;
                    }
                }
                var userId = int.Parse(jwtToken.Claims.First().Value);
                context.HttpContext.Items["UserId"] = userId;
            }
            catch (Exception)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
