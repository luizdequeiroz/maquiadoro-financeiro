using Financeiro.Controllers.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financeiro.Controllers
{
    [AuthenticationSession]
    public partial class CadastrosController : Controller
    {
        public ActionResult Cadastros()
        {
            return View();
        }
    }
}