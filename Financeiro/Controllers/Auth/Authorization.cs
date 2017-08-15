using Financeiro.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financeiro.Controllers.Auth
{
    public class Authorization : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        public Authorization(params string[] roles)
        {
            this.allowedroles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (AuthenticationSession.IsSessionAtiva(httpContext.Session))
            {
                bool authorize = false;
                var setor = ((Funcionario)httpContext.Session["Funcionario"]).Setor;
                foreach (var r in allowedroles)
                    if (r == setor.Nome) authorize = true;

                return authorize;
            }
            else
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //filterContext.Result = new HttpUnauthorizedResult();
            filterContext.Result = new ViewResult { ViewName = "Unauthorized" };
            filterContext.HttpContext.Response.StatusCode = 403;
        }
    }
}