using Financeiro.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financeiro.Controllers.Authentication
{
    public class AuthenticationSession : AuthorizeAttribute
    {
        public static string IdNameKey { get; set; }
        public static string ScriptSession { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session[IdNameKey] == null)
            {
                ScriptSession = "<script>window.open('../','_top');</script>";
                httpContext.Response.Redirect("~/");
            }
            return true;
        }

        public static bool IsSessionAtiva(HttpSessionStateBase Session)
        {
            return (Session[IdNameKey] == null) ? false : true;
        }
    }
}