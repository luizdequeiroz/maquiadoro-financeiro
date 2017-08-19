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
    public partial class CadastrosController : Controller
    {
        public ActionResult ContasBancarias(int favorecidoId, int categoria)
        {
            var contasBancarias = new List<ContaBancaria>().SelecionarPorFavorecidoId(favorecidoId, (ECategoria)categoria);
            return View(contasBancarias);
        }
        [Authorizations("Administrativo")]
        public ActionResult NovaContaBancaria(int favorecidoId, int categoria)
        {
            ViewBag.FavorecidoId = favorecidoId;
            ViewBag.CategoriaFavorecido = categoria;
            return View();
        }
        [HttpPost]
        public ActionResult NovaContaBancaria(ContaBancaria cb)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    cb.Inserir();
                    return RedirectToAction("VerFavorecido", new { id = cb.FavorecidoId, categoria = cb.CategoriaFavorecido });
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "OPS! Erro inesperado. Entre em contato com o suporte! Erro: " + e.Message);
                    return View();
                }
            }
            return View();
        }
        [Authorizations("Administrativo")]
        public ActionResult ExcluirContaBancaria(int id)
        {
            var cb = new ContaBancaria().SelecionarPorId(id);
            var favorecidoId = cb.FavorecidoId;
            var categoriaFavorecido = cb.CategoriaFavorecido;
            cb.Excluir();
            return RedirectToAction("VerFavorecido", new { id = favorecidoId, categoria = categoriaFavorecido });
        }
        public ActionResult VerFavorecido(int id, int categoria)
        {
            if ((ECategoria)categoria == ECategoria.Fornecedor)
                return RedirectToAction("VerFornecedor", new { id = id });
            else if ((ECategoria)categoria == ECategoria.Funcionario)
                return RedirectToAction("VerFuncionario", new { id = id });
            else
                return RedirectToAction("VerTerceiro", new { id = id });
        }
    }
}