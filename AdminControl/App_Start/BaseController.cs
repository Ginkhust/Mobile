using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminControl.Models;

namespace AdminControl.App_Start
{
    public class BaseController: Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (LoginViewModel) Session["login"];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    System.Web.Routing.RouteValueDictionary(new { controller = "Account", action = "Login" }));
            }

            base.OnActionExecuted(filterContext);
        }
    }
}