using Financeiro.Controllers.Auth;
using Financeiro.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financeiro.Controllers
{
    [AuthenticationSession]
    public class PlanoContasController : Controller
    {
        public ActionResult PlanoContas()
        {
            return View();
        }

        public ActionResult Inclusão()
        {
            return View();
        }

        public ActionResult Alteracao()
        {
            return View();
        }
    }
}