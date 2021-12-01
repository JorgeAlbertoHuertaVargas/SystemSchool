using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace Presentation.Filters
{
    public class AuthorizeUserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(context.HttpContext.Session.GetString(AllSession.RoleName))))
            {
                var roleValue = Convert.ToString(context.HttpContext.Session.GetString(AllSession.RoleName));

                if (roleValue != Convert.ToString("ADMIN"))
                {
                    if (context.Controller is Controller controller)
                    {
                        controller.ViewData["ErrorMessage"] = "Invalid User";
                        controller.HttpContext.Session.Clear();
                    }

                    context.Result = new RedirectResult("/Error/Error");
                }

            }
            else
            {
                ViewResult result = new ViewResult();
                result.ViewName = "Error";

                if (context.Controller is Controller controller)
                {
                    controller.ViewData["ErrorMessage"] = "You Session has been Expired";
                    controller.HttpContext.Session.Clear();
                }

                context.Result = new RedirectResult("/Login");

            }
        }
    }
}
