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
        [Authorizations("Administrativo", "Compras")]
        public ActionResult InclusaoFornecedor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InclusaoFornecedor(ContaAPagar c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    c.CategoriaFavorecido = (int)ECategoria.Fornecedor;
                    c.UsuarioInclusao = (Funcionario)Session["Funcionario"];
                    c.UsuarioBaixaId = !string.IsNullOrEmpty(c.DataBaixa) ? (Session["Funcionario"] as Funcionario).Id : 0;
                    c.Inserir();
                    return RedirectToAction("PlanoContas");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "OPS! Erro inesperado. Entre em contato com o suporte! Erro: " + e.Message);
                    return View();
                }
            }
            return View();
        }

        [Authorizations("Administrativo", "Financeiro")]
        public ActionResult InclusaoFuncionario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InclusaoFuncionario(ContaAPagar c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    c.CategoriaFavorecido = (int)ECategoria.Funcionario;
                    c.UsuarioInclusao = (Funcionario)Session["Funcionario"];
                    c.UsuarioBaixaId = !string.IsNullOrEmpty(c.DataBaixa) ? (Session["Funcionario"] as Funcionario).Id : 0;
                    c.Inserir();
                    return RedirectToAction("PlanoContas");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "OPS! Erro inesperado. Entre em contato com o suporte! Erro: " + e.Message);
                    return View();
                }
            }
            return View();
        }

        [Authorizations("Administrativo", "Financeiro")]
        public ActionResult InclusaoTerceiro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InclusaoTerceiro(ContaAPagar c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    c.CategoriaFavorecido = (int)ECategoria.Terceiro;
                    c.UsuarioInclusao = (Funcionario)Session["Funcionario"];
                    c.UsuarioBaixaId = !string.IsNullOrEmpty(c.DataBaixa) ? (Session["Funcionario"] as Funcionario).Id : 0;
                    c.Inserir();
                    return RedirectToAction("PlanoContas");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "OPS! Erro inesperado. Entre em contato com o suporte! Erro: " + e.Message);
                    return View();
                }
            }
            return View();
        }
    }
}