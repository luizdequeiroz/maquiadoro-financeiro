using Financeiro.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Entidades
{
    public class Destinatario
    {
        public virtual int Id { get; set; }

        public virtual ETipo ETipo
        {
            get
            {
                return (ETipo)Tipo;
            }
            set
            {
                Tipo = (int)value;
            }
        }
        public virtual int Tipo { get; set; }

        [Required(ErrorMessage = "Informe o nome do funcionário!")]
        public virtual string Nome
        {
            get
            {
                return NomeSocial;
            }
            set
            {
                NomeSocial = value;
            }
        }
        [Required(ErrorMessage = "Informe a razão social do fornecedor!")]
        public virtual string RazaoSocial
        {
            get
            {
                return NomeSocial;
            }
            set
            {
                NomeSocial = value;
            }
        }
        public virtual string NomeSocial { get; set; }

        [Required(ErrorMessage = "Informe o apelido do funcionário!")]
        public virtual string Apelido
        {
            get
            {
                return ApelidoFantasia;
            }
            set
            {
                ApelidoFantasia = value;
            }
        }
        [Required(ErrorMessage = "Informe o nome fantasia do fornecedor!")]
        public virtual string NomeFantasia
        {
            get
            {
                return ApelidoFantasia;
            }
            set
            {
                ApelidoFantasia = value;
            }
        }
        public virtual string ApelidoFantasia { get; set; }

        [Required(ErrorMessage = "Selecione o tipo de pessoa!")]
        public virtual ETipoPessoa ETipoPessoa
        {
            get
            {
                return (ETipoPessoa)TipoPessoa;
            }
            set
            {
                TipoPessoa = (int)value;
            }
        }
        public virtual int TipoPessoa { get; set; }

        [Required(ErrorMessage = "Informe o CPF!")]
        public virtual string CPF
        {
            get
            {
                return CadastroPessoa;
            }
            set
            {
                CadastroPessoa = value;
            }
        }
        [Required(ErrorMessage = "Informe o CNPJ!")]
        public virtual string CNPJ
        {
            get
            {
                return CadastroPessoa;
            }
            set
            {
                CadastroPessoa = value;
            }
        }
        public virtual string CadastroPessoa { get; set; }

        public virtual string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o e-mail desta pessoa!")]
        public virtual string Email { get; set; }

        [Required(ErrorMessage = "Informe o telefone ou marque como <i>\"Não Tem!\"</i>")]
        public virtual string Telefone { get; set; }
        [Required(ErrorMessage = "Informe o telefone do fornecedor!")]
        public virtual string TelefoneFornecedor
        {
            get
            {
                return Telefone;
            }
            set
            {
                Telefone = value;
            }
        }

        [Required(ErrorMessage = "Informe o celular ou marque como <i>\"Não Tem!\"</i>")]
        public virtual string Celular { get; set; }
        [Required(ErrorMessage = "Informe o celular do funcionário!")]
        public virtual string CelularFuncionario
        {
            get
            {
                return Celular;
            }
            set
            {
                Celular = value;
            }
        }

        public virtual DateTime DataCadastro { get; set; }
    }
}