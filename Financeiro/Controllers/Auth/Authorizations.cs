using Financeiro.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financeiro.Controllers.Auth
{
    public class Authorizations : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        public Authorizations(params string[] roles)
        {
            this.allowedroles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (AuthenticationSession.IsSessionAtiva(httpContext.Session))
            {
                var authorize = false;
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

        public static bool Is(params string[] roles)
        {
            var authorize = false;
            var httpContext = AuthenticationSession.httpContext;
            var setor = ((Funcionario)httpContext.Session["Funcionario"]).Setor;
            foreach (var r in roles)
                if (r == setor.Nome) authorize = true;

            return authorize;
        }
    }
}