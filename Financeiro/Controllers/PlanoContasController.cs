using Financeiro.Controllers.Authentication;
using Financeiro.Models.DAOs;
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
        // Inclusão
        [Normal]
        public ActionResult Inclusao()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inclusao(ContaPagar cp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    cp.DataInclusao = DateTime.Now;
                    cp.UsuarioId = (int)Session["id"];
                    if (cp.Modo == 2)
                    {
                        var venc = cp.Vencimento.Month;
                        while(venc <= 12)
                        {
                            var ncp = cp;
                            ncp.Vencimento = ncp.Vencimento.AddMonths(venc);
                            new ContaPagarDao().Inserir(ncp);
                            venc += 1;
                        }
                    }
                    else if (cp.Modo == 3)
                    {
                        var venc = cp.Vencimento.Month;
                        var qtd = cp.Qtd;
                        while(qtd > 0)
                        {
                            var ncp = cp;
                            ncp.Vencimento = ncp.Vencimento.AddMonths(venc);
                            new ContaPagarDao().Inserir(ncp);
                            venc += 1;
                            qtd -= 1;
                        }
                    }
                    else new ContaPagarDao().Inserir(cp);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "OPS! Erro inesperado. Entre em contato com o suporte! Erro: " + e.Message);
                    return View();
                }
            }
            ModelState.AddModelError("", "Campo obrigatório!");
            return View();
        }
    }
}