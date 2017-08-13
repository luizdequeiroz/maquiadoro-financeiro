/*using Financeiro.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financeiro.Controllers.Authentication
{
    public class Administrativo : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (AuthenticationSession.IsSessionAtiva(httpContext.Session))
            {
                if ((ENivel)httpContext.Session["nivel"] != ENivel.Administrativo)
                    httpContext.Response.Redirect("~/");
            }
            else
            {
                httpContext.Response.Redirect("~/");
            }
            return true;
        }
    }
}*/