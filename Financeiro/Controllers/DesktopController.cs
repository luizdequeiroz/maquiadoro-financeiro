using Financeiro.Controllers.Authentication;
using Financeiro.Models.Dao;
using Financeiro.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financeiro.Controllers
{
    [AuthenticationSession]
    public class DesktopController : Controller
    {
        public ActionResult Painel()
        {
            var autorizacoes = ((Funcionario)Session["Funcionario"]).Setor.Autorizacoes;
            return View(autorizacoes);
        }

        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Sair()
        {
            Session.RemoveAll();
            return RedirectToAction("Entrar", "Entrada");
        }
    }
}