using Financeiro.Controllers.Auth;
using Financeiro.Models.Dao;
using Financeiro.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financeiro.Controllers
{
    public partial class CadastrosController : Controller
    {
        // TipoDespesa
        [Authorization("Administrativo")]
        public ActionResult TiposDespesas()
        {
            var tiposDespesas = new List<TipoDespesa>().Selecionar();
            return View(tiposDespesas);
        }
        [HttpPost]
        public ActionResult CadastrarTipoDespesa(string Nome, string Descricao, int Categoria)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var d = new TipoDespesa { Nome = Nome, Descricao = Descricao, Categoria = Categoria };
                    d.Inserir();
                    return RedirectToAction("TiposDespesas");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("NewDescricao", "OPS! Erro inesperado. Entre em contato com o suporte! Erro: " + e.Message);
                    return View();
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult AlterarTipoDespesa(TipoDespesa d)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    d.Alterar();
                    return RedirectToAction("TiposDespesas");
                }
                catch (Exception e)
                {
                    ViewBag.ModelError = "<div class='validation-summary-errors'><ul><li>OPS! Erro inesperado. Entre em contato com o suporte! Erro: " + e.Message + "</li></ul></div>";
                    return View();
                }
            }
            return View();
        }
        [Authorization("Administrativo")]
        public ActionResult ExcluirTipoDespesa(int id)
        {
            var c = new TipoDespesa().SelecionarPorId(id);
            c.Excluir();
            return RedirectToAction("TiposDespesas");
        }
    }
}