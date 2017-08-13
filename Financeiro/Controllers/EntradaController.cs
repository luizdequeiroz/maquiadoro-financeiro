using Financeiro.Controllers.Authentication;
using Financeiro.Models.Dao;
using Financeiro.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Financeiro.Controllers
{
    public class EntradaController : Controller
    {
        public ActionResult Entrar()
        {
            ViewBag.ScriptSession = AuthenticationSession.ScriptSession;
            AuthenticationSession.ScriptSession = "";
            if (Session["Funcionario"] == null)
                return View();
            else return RedirectToAction("Painel", "Desktop");
        }

        [HttpPost]
        public ActionResult Entrar(Funcionario f)
        {
            var Validade = 0;
            Validade += (string.IsNullOrEmpty(f.Usuario)) ? 1 : 0;
            Validade += (string.IsNullOrEmpty(f.Senha)) ? 2 : 0;

            if (Validade == 0)
            {
                try
                {
                    var fu = f.SelecionarPorUsuario();
                    if (fu != null)
                        if (f.Senha == fu.Senha)
                        {
                            AuthenticationSession.IdNameKey = "Funcionario";
                            Session["Funcionario"] = fu;
                            return RedirectToAction("Painel", "Desktop");
                        }
                        else
                        {
                            ModelState.AddModelError("Senha", "Senha incorreta!");
                            return View();
                        }
                    ModelState.AddModelError("", "Usuário não existe!");
                    return View();
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "OPS! Erro inesperado. Entre em contato com o suporte! Erro: " + e.Message);
                    return View();
                }
            }
            else if (Validade < 2)
                ModelState.AddModelError("Usuario", "Informe seu usuário de acesso!");
            else if (Validade < 3)
                ModelState.AddModelError("Senha", "Informe sua senha de acesso!");
            else
            {
                ModelState.AddModelError("Usuario", "Informe seu usuário de acesso!");
                ModelState.AddModelError("Senha", "Informe sua senha de acesso!");
            }
            return View();
        }
    }
}