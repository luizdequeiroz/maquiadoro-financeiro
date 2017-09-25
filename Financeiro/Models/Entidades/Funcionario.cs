using Financeiro.Models.Dao;
using Financeiro.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Entidades
{
    public class Funcionario
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome!")]
        public virtual string NomeCompleto { get; set; }
        [Required(ErrorMessage = "Informe a data de nascimento!")]
        public virtual string DataNascimento
        {
            get
            {
                return DataNascimentoMap.ToString("dd/MM/yyyy");
            }
            set
            {
                DataNascimentoMap = DateTime.Parse(value);
            }
        }
        public virtual DateTime DataNascimentoMap { get; set; }

        public virtual string Email { get; set; }

        [Required(ErrorMessage = "Informe o fone 1!")]
        public virtual string Fone1 { get; set; }

        public virtual string Fone2 { get; set; }
        public virtual string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o usuário!")]
        public virtual string Usuario { get; set; }
        [Required(ErrorMessage = "Informe a senha!")]
        public virtual string Senha { get; set; }
        [Compare("Senha", ErrorMessage = "Senhas não conferem!")]
        public virtual string RepSenha { get; set; }

        [Required(ErrorMessage = "Informe o setor!")]
        public virtual int SetorId { get; set; }

        public virtual string DataCadastro
        {
            get
            {
                return DataCadastroMap.ToString("dd/MM/yyyy");
            }
            set
            {
                DataCadastroMap = DateTime.Parse(value);
            }
        }
        public virtual DateTime DataCadastroMap { get; set; }
        public virtual string DataAdmissao
        {
            get
            {
                return DataAdmissaoMap.ToString("dd/MM/yyyy");
            }
            set
            {
                DataAdmissaoMap = DateTime.Parse(value);
            }
        }
        public virtual DateTime DataAdmissaoMap { get; set; }
        public virtual string Logradouro { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Complemento { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Municipio { get; set; }
        public virtual string Estado { get; set; }

        public virtual Setor Setor
        {
            get
            {
                return new Setor().SelecionarPorId(SetorId);
            }
            set
            {
                SetorId = value.Id;
            }
        }

        public virtual List<ContaBancaria> ContasBancarias
        {
            get
            {
                return new List<ContaBancaria>().SelecionarPorFavorecidoId(Id, ECategoria.Funcionario);
            }
        }
    }
}