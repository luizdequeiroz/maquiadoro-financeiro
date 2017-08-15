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
        // Fornecedor
        public ActionResult Fornecedores()
        {
            var fornecedores = new List<Fornecedor>().Selecionar();
            return View(fornecedores);
        }
        [Authorization("Administrativo", "Compras")]
        public ActionResult NovoFornecedor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NovoFornecedor(Fornecedor f)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //f.DataCadastro = DateTime.Now.ToString();
                    f.Inserir();
                    return RedirectToAction("Fornecedores");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "OPS! Erro inesperado. Entre em contato com o suporte! Erro: " + e.Message);
                    return View();
                }
            }
            return View();
        }
        public ActionResult VerFornecedor(int id)
        {
            var fornecedor = new Fornecedor().SelecionarPorId(id);
            return View(fornecedor);
        }
        [Authorization("Administrativo")]
        public ActionResult AlterarFornecedor(int id)
        {
            var fornecedor = new Fornecedor().SelecionarPorId(id);
            return View(fornecedor);
        }
        [HttpPost]
        public ActionResult AlterarFornecedor(Fornecedor f)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fo = new Fornecedor().SelecionarPorId(f.Id);
                    f.DataCadastro = fo.DataCadastro;
                    f.Alterar();
                    return RedirectToAction("Fornecedores");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "OPS! Erro inesperado. Entre em contato com o suporte! Erro: " + e.Message);
                    return View();
                }
            }
            return View();
        }
        [Authorization("Administrativo")]
        public ActionResult ExcluirFornecedor(int id)
        {
            var f = new Fornecedor().SelecionarPorId(id);
            f.Excluir();
            return RedirectToAction("Fornecedores");
        }

        // Funcionário
        public ActionResult Funcionarios()
        {
            var funcionarios = new List<Funcionario>().Selecionar();            
            return View(funcionarios);
        }
        [Authorization("Administrativo", "Financeiro")]
        public ActionResult NovoFuncionario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NovoFuncionario(Funcionario f)
        {
            if (ModelState.IsValid)
            {
                try
                {                    
                    //f.DataCadastro = DateTime.Now.ToString();
                    f.Inserir();
                    return RedirectToAction("Funcionarios");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "OPS! Erro inesperado. Entre em contato com o suporte! Erro: " + e.Message);
                    return View();
                }
            }
            return View();
        }
        public ActionResult VerFuncionario(int id)
        {
            var funcionario = new Funcionario().SelecionarPorId(id);
            return View(funcionario);
        }
        [Authorization("Administrativo")]
        public ActionResult AlterarFuncionario(int id)
        {
            var funcionario = new Funcionario().SelecionarPorId(id);
            return View(funcionario);
        }
        [HttpPost]
        public ActionResult AlterarFuncionario(Funcionario f)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fu = new Funcionario().SelecionarPorId(f.Id);
                    f.DataCadastro = fu.DataCadastro;                    
                    f.Alterar();
                    return RedirectToAction("Funcionarios");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "OPS! Erro inesperado. Entre em contato com o suporte! Erro: " + e.Message);
                    return View();
                }
            }
            return View();
        }
        [Authorization("Administrativo")]
        public ActionResult ExcluirFuncionario(int id)
        {
            var f = new Funcionario().SelecionarPorId(id);
            f.Excluir();
            return RedirectToAction("Funcionarios");
        }        

        // Terceiro
        public ActionResult Terceiros()
        {
            var terceiros = new List<Terceiro>().Selecionar();
            return View(terceiros);
        }
        [Authorization("Administrativo","Financeiro")]
        public ActionResult NovoTerceiro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NovoTerceiro(Terceiro t)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //t.DataCadastro = DateTime.Now.ToString();
                    t.Inserir();
                    return RedirectToAction("Terceiros");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "OPS! Erro inesperado. Entre em contato com o suporte! Erro: " + e.Message);
                    return View();
                }
            }
            return View();
        }
        public ActionResult VerTerceiro(int id)
        {
            var terceiro = new Terceiro().SelecionarPorId(id);
            return View(terceiro);
        }
        [Authorization("Administrativo")]
        public ActionResult AlterarTerceiro(int id)
        {
            var terceiro = new Terceiro().SelecionarPorId(id);
            return View(terceiro);
        }
        [HttpPost]
        public ActionResult AlterarTerceiro(Terceiro t)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var te = new Terceiro().SelecionarPorId(t.Id);
                    //t.DataCadastro = te.DataCadastro;
                    t.Alterar();
                    return RedirectToAction("Terceiros");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "OPS! Erro inesperado. Entre em contato com o suporte! Erro: " + e.Message);
                    return View();
                }
            }
            return View();
        }        
        [Authorization("Administrativo")]
        public ActionResult ExcluirTerceiro(int id)
        {
            var t = new Terceiro().SelecionarPorId(id);
            t.Excluir();
            return RedirectToAction("Terceiros");
        }
    }
}