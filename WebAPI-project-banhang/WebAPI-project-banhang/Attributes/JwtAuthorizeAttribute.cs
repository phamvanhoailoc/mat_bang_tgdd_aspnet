using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI_project_banhang.Filters;

namespace WebAPI_project_banhang.Attributes
{
    public class JwtAuthorizeAttribute : TypeFilterAttribute
    {
        public JwtAuthorizeAttribute(params string[] Permission)
            : base(typeof(JwtAuthorizeFilter))
        {
            Arguments = new object[] { Permission };
        }
    }
}
