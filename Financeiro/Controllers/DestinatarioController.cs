﻿/*using Financeiro.Controllers.Authentication;
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
        // Funcionário
        public ActionResult Funcionarios()
        {
            List<Destinatario> funcionarios = new List<Destinatario>();
            var destinatarios = new DestinatarioDao().Selecionar();

            foreach (var d in destinatarios)
                if (d.ETipo == ECategoria.Funcionario)
                    funcionarios.Add(d);

            return View(funcionarios);
        }
        [Normal]
        public ActionResult NovoFuncionario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NovoFuncionario(Destinatario f)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    f.ETipo = ECategoria.Funcionario;
                    f.ETipoPessoa = ETipoPessoa.Fisica;
                    f.DataCadastro = DateTime.Now;
                    new DestinatarioDao().Inserir(f);
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
            var funcionario = new DestinatarioDao().SelecionarPorId(id);
            return View(funcionario);
        }
        [Normal]
        public ActionResult AlterarFuncionario(int id)
        {
            var funcionario = new DestinatarioDao().SelecionarPorId(id);

            if (funcionario.Telefone == "0000000000") ViewBag.Checked = "checked";
            else ViewBag.Checked = "";

            return View(funcionario);
        }
        [HttpPost]
        public ActionResult AlterarFuncionario(Destinatario f)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fu = new DestinatarioDao().SelecionarPorId(f.Id);
                    f.DataCadastro = fu.DataCadastro;
                    f.ETipo = fu.ETipo;
                    f.ETipoPessoa = fu.ETipoPessoa;
                    new DestinatarioDao().Alterar(f);
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
        [Normal]
        public ActionResult ExcluirFuncionario(int id)
        {
            var f = new DestinatarioDao().SelecionarPorId(id);
            new ContaBancoDao().ExcluirContasPorDestinatario(id);
            new DestinatarioDao().Excluir(f);
            return RedirectToAction("Funcionarios");
        }

        // Fornecedor
        public ActionResult Fornecedores()
        {
            List<Destinatario> fornecedores = new List<Destinatario>();
            var destinatarios = new DestinatarioDao().Selecionar();

            foreach (var d in destinatarios)
                if (d.ETipo == ECategoria.Fornecedor)
                    fornecedores.Add(d);

            return View(fornecedores);
        }
        [Normal]
        public ActionResult NovoFornecedor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NovoFornecedor(Destinatario f)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    f.ETipo = ECategoria.Fornecedor;
                    f.ETipoPessoa = ETipoPessoa.Juridica;
                    f.DataCadastro = DateTime.Now;
                    new DestinatarioDao().Inserir(f);
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
            var fornecedor = new DestinatarioDao().SelecionarPorId(id);
            return View(fornecedor);
        }
        [Normal]
        public ActionResult AlterarFornecedor(int id)
        {
            var fornecedor = new DestinatarioDao().SelecionarPorId(id);

            if (fornecedor.Celular == "0000000000") ViewBag.Checked = "checked";
            else ViewBag.Checked = "";

            return View(fornecedor);
        }
        [HttpPost]
        public ActionResult AlterarFornecedor(Destinatario f)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fo = new DestinatarioDao().SelecionarPorId(f.Id);
                    f.DataCadastro = fo.DataCadastro;
                    f.ETipo = fo.ETipo;
                    f.ETipoPessoa = fo.ETipoPessoa;
                    new DestinatarioDao().Alterar(f);
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
        [Normal]
        public ActionResult ExcluirFornecedor(int id)
        {
            var f = new DestinatarioDao().SelecionarPorId(id);
            new ContaBancoDao().ExcluirContasPorDestinatario(id);
            new DestinatarioDao().Excluir(f);
            return RedirectToAction("Fornecedores");
        }

        // Terceiro
        public ActionResult Terceiros()
        {
            List<Destinatario> terceiros = new List<Destinatario>();
            var destinatarios = new DestinatarioDao().Selecionar();

            foreach (var d in destinatarios)
                if (d.ETipo == ECategoria.Terceiro)
                    terceiros.Add(d);

            return View(terceiros);
        }
        [Normal]
        public ActionResult NovoTerceiro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NovoTerceiro(Destinatario t)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    t.ETipo = ECategoria.Terceiro;
                    t.DataCadastro = DateTime.Now;
                    new DestinatarioDao().Inserir(t);
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
            var terceiro = new DestinatarioDao().SelecionarPorId(id);
            return View(terceiro);
        }
        [Normal]
        public ActionResult AlterarTerceiro(int id)
        {
            var terceiro = new DestinatarioDao().SelecionarPorId(id);
            return View(terceiro);
        }
        [HttpPost]
        public ActionResult AlterarTerceiro(Destinatario t)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var te = new DestinatarioDao().SelecionarPorId(t.Id);
                    t.DataCadastro = te.DataCadastro;
                    t.ETipo = te.ETipo;
                    new DestinatarioDao().Alterar(t);
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
        public ActionResult FormTerceiro(ETipoPessoa eTipoPessoa, int id = 0)
        {
            if (id > 0)
            {
                var destinarario = new DestinatarioDao().SelecionarPorId(id);

                if ((destinarario.ETipoPessoa == ETipoPessoa.Juridica && destinarario.Celular == "0000000000") || 
                    (destinarario.ETipoPessoa == ETipoPessoa.Fisica && destinarario.Telefone == "0000000000")) ViewBag.Checked = "checked";
                else ViewBag.Checked = "";

                destinarario.ETipoPessoa = eTipoPessoa;

                return View(destinarario);
            }
            else
            {
                return View(new Destinatario { Id = id, ETipoPessoa = eTipoPessoa });
            }
        }
        [Normal]
        public ActionResult ExcluirTerceiro(int id)
        {
            var t = new DestinatarioDao().SelecionarPorId(id);
            new ContaBancoDao().ExcluirContasPorDestinatario(id);
            new DestinatarioDao().Excluir(t);
            return RedirectToAction("Terceiros");
        }
    }
}*/