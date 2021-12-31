using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Service.DataModel;
using System;

namespace API.Helper
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (Permisssion)context.HttpContext.Items["UserAndPPermisssion"];
            var header = context.HttpContext.Request.Path.ToString().Substring(5);
            var index = header.LastIndexOf("/");
            var Controller = header.Substring(0,index);
            var isPermission = user.lst.FindIndex(x => x.Controller == Controller);
            if (isPermission == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
