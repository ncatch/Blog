using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Web
{
    public class AutherAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.Path.Contains("Login") && !filterContext.HttpContext.Request.Path.Contains("Register")
                && filterContext.HttpContext.Session["user"] == null)
            {
                filterContext.HttpContext.Response.Redirect("/Home/Login");
            }
        }
    }
}