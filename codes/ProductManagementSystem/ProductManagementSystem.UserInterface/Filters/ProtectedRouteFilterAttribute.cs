using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductManagementSystem.UserInterface.Models;

namespace ProductManagementSystem.UserInterface.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ProtectedRouteFilterAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (string.IsNullOrEmpty(AuthToken.Token))
            {
                var action = context.ActionDescriptor.RouteValues["action"];
                var controller = context.ActionDescriptor.RouteValues["controller"];
                context.Result = new RedirectToRouteResult(new { controller = "Auth", action = "Login", redirectUrl = $"{controller}/{action}" });
            }
            else
                await next();
        }
    }
}
