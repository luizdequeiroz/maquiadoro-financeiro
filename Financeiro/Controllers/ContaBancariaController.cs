using Financeiro.Controllers.Authentication;
using Financeiro.Models.DAOs;
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
    public partial class CadastrosController : Controller
    {
        public ActionResult ContasBancarias(int destinatarioId)
        {
            var destinatario = new DestinatarioDao().SelecionarPorId(destinatarioId);
            ViewBag.DestinatarioNome = destinatario.Apelido;
            ViewBag.DestinatarioId = destinatario.Id;
            var contas = new ContaBancoDao().SelecionarPorDestinatarioId(destinatarioId);
            return View(contas);
        }
        [Normal]
        public ActionResult NovaContaBancaria(int destinatarioId)
        {            
            ViewBag.DestinatarioId = destinatarioId;
            return View();
        }
        [HttpPost]
        public ActionResult NovaContaBancaria(ContaBanco cb)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    new ContaBancoDao().Inserir(cb);
                    return RedirectToAction("VerDestinatario", new { id = cb.DestinatarioId });
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "OPS! Erro inesperado. Entre em contato com o suporte! Erro: " + e.Message);
                    return View();
                }
            }
            return View();
        }
        [Normal]
        public ActionResult ExcluirContaBancaria(int id)
        {
            var cb = new ContaBancoDao().SelecionarPorId(id);
            var destinatarioId = cb.DestinatarioId;
            new ContaBancoDao().Excluir(cb);
            return RedirectToAction("VerDestinatario", new { id = destinatarioId });
        }
        public ActionResult VerDestinatario(int id)
        {
            var tipo = new DestinatarioDao().SelecionarPorId(id).ETipo;
            if (tipo == ETipo.Fornecedor) return RedirectToAction("VerFornecedor", new { id = id });
            else if (tipo == ETipo.Funcionario) return RedirectToAction("VerFuncionario", new { id = id });
            else return RedirectToAction("VerTerceiro", new { id = id });
        }
    }
}