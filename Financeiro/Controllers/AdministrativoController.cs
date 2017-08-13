/*using Financeiro.Controllers.Authentication;
using Financeiro.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financeiro.Controllers
{
    [AuthenticationSession]
    public class AdministrativoController : Controller
    {
        // Usuário
        [Administrativo]
        public ActionResult Usuarios(string filtro = "")
        {
            List<Usuario> usuarios = new List<Usuario>();

            if (filtro == "")
                usuarios = new UsuarioDao().Selecionar();
            else usuarios = new UsuarioDao().SelecionarPorFiltro(filtro);

            return View(usuarios);
        }
        [Administrativo]
        public ActionResult NovoUsuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NovoUsuario(Usuario u)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    u.DataCadastro = DateTime.Now;
                    new UsuarioDao().Inserir(u);
                    return RedirectToAction("Usuarios");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "OPS! Erro inesperado. Entre em contato com o suporte! Erro: " + e.Message);
                    return View();
                }
            }
            return View();
        }
        [Administrativo]
        public ActionResult AlterarUsuario(int id)
        {
            var u = new UsuarioDao().SelecionarPorId(id);
            return View(u);
        }
        [HttpPost]
        public ActionResult AlterarUsuario(Usuario u)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var us = new UsuarioDao().SelecionarPorId(u.Id);
                    u.EmailAlteracao = us.Email;
                    u.DataCadastro = us.DataCadastro;
                    new UsuarioDao().Alterar(u);
                    return RedirectToAction("Usuarios");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "OPS! Erro inesperado. Entre em contato com o suporte! Erro: " + e.Message);
                    return View();
                }
            }
            return View();
        }
        [Administrativo]
        public ActionResult ExcluirUsuario(int id)
        {
            var u = new UsuarioDao().SelecionarPorId(id);
            new UsuarioDao().Excluir(u);
            return RedirectToAction("Usuarios");
        }

        // Categoria
        [Administrativo]
        public ActionResult Categorias(string filtro = "")
        {
            List<Categoria> categorias = new List<Categoria>();

            if (filtro == "")
                categorias = new CategoriaDao().Selecionar();
            else categorias = new CategoriaDao().SelecionarPorFiltro(filtro);

            return View(categorias);
        }
        [HttpPost]
        public ActionResult CadastrarCategoria(string Nome, string Descricao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var c = new Categoria { Nome = Nome, Descricao = Descricao };
                    new CategoriaDao().Inserir(c);
                    return RedirectToAction("Categorias");
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
        public ActionResult AlterarCategoria(Categoria c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    new CategoriaDao().Alterar(c);
                    return RedirectToAction("Categorias");
                }
                catch (Exception e)
                {
                    ViewBag.ModelError = "<div class='validation-summary-errors'><ul><li>OPS! Erro inesperado. Entre em contato com o suporte! Erro: " + e.Message + "</li></ul></div>";
                    return View();
                }
            }
            return View();
        }
        [Administrativo]
        public ActionResult ExcluirCategoria(int id)
        {
            var c = new CategoriaDao().SelecionarPorId(id);
            new CategoriaDao().Excluir(c);
            return RedirectToAction("Categorias");
        }
    }
}*/