using Financeiro.Controllers.Authentication;
using Financeiro.Models.DAOs;
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
            if (Session["id"] == null)
                return View();
            else return RedirectToAction("Saguao", "Desktop");
        }

        [HttpPost]
        public ActionResult Entrar(Usuario u)
        {
            var Validade = 0;
            Validade += (string.IsNullOrEmpty(u.EmailEntrada)) ? 1 : 0;
            Validade += (string.IsNullOrEmpty(u.Senha)) ? 2 : 0;

            if (Validade == 0)
            {
                try
                {
                    var us = new UsuarioDao().SelecionarPorEmail(u.EmailEntrada);
                    if (us != null)
                        if (u.Senha == us.Senha)
                        {
                            AuthenticationSession.IdNameKey = "id";
                            Session["id"] = us.Id;
                            Session["nivel"] = us.Nivel;
                            Session["nome"] = us.Nome;
                            return RedirectToAction("Saguao", "Desktop");
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
                ModelState.AddModelError("EmailEntrada", "Informe seu apelido de acesso!");
            else if (Validade < 3)
                ModelState.AddModelError("Senha", "Informe sua senha de acesso!");
            else
            {
                ModelState.AddModelError("EmailEntrada", "Informe seu apelido de acesso!");
                ModelState.AddModelError("Senha", "Informe sua senha de acesso!");
            }
            return View();
        }
    }
}