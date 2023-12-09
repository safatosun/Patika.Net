using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PatikaRestfulApi.Entities.Models;
using PatikaRestfulApi.Services.Contracts;

namespace PatikaRestfulApi.Controllers.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class FakeUserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string name = context.HttpContext.Request.Query["name"];
            string password = context.HttpContext.Request.Query["password"];

            var userService = (IUserService)context.HttpContext.RequestServices.GetService(typeof(IUserService));

            User user = userService.Login(name, password);

            if (user == null)
            {
                context.Result = new UnauthorizedResult();
            }

            base.OnActionExecuting(context);
        }
    }
}
