using Financeiro.Controllers.Auth;
using Financeiro.Models.Dao;
using Financeiro.Models.Entidades;
using Financeiro.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financeiro.Controllers
{
    [AuthenticationSession]
    public partial class PlanoContasController : Controller
    {
        public ActionResult PlanoContas()
        {
            return View();
        }
        public ActionResult Inclusao()
        {
            return View();
        }
        /* implementar BaixaAlteracao */
        public ActionResult Consulta()
        {
            return View();
        }
    }
}