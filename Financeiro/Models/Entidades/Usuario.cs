using Financeiro.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//using System.Web.Mvc;

namespace Financeiro.Models.Entidades
{
    public class Usuario
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório!")]
        public virtual string Nome { get; set; }

        [Required(ErrorMessage = "O apelido é obrigatório!")]
        public virtual string Apelido { get; set; }

        [Required(ErrorMessage = "Insira sua senha de acesso!")]
        public virtual string Senha { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória!")]
        public virtual string SenhaAlteracao
        {
            get
            {
                return Senha;
            }
            set
            {
                Senha = value;
                RepSenha = value;
            }
        }
        [Required(ErrorMessage = "A senha é obrigatória!")]
        public virtual string SenhaCadastro
        {
            get
            {
                return Senha;
            }
            set
            {
                Senha = value;
            }
        }
        [Compare("SenhaCadastro", ErrorMessage = "Senhas não conferem!")]
        public virtual string RepSenha { get; set; }

        public virtual int Nivel { get; set; }
        [Required(ErrorMessage = "Escolha um nível para usuário!")]
        public virtual ENivel ENivel
        {
            get
            {
                return (ENivel)Nivel;
            }
            set
            {
                Nivel = (int)value;
            }
        }

        [Required(ErrorMessage = "O e-mail é obrigatório! Ele é usado para entrar no sistema.")]
        [System.Web.Mvc.Remote("EmailUnico", "Uteis", ErrorMessage = "Alguém já está usando este e-mail!")]
        public virtual string Email { get; set; }
        [Required(ErrorMessage = "Insira seu e-mail de acesso!")]
        public virtual string EmailEntrada
        {
            get
            {
                return Email;
            }
            set
            {
                Email = value;
            }
        }
        public virtual string EmailAlteracao
        {
            get
            {
                return Email;
            }
            set
            {
                Email = value;
            }
        }

        public virtual string Telefone { get; set; }

        [Required(ErrorMessage = "O celular é obrigatório!")]
        public virtual string Celular { get; set; }

        public virtual DateTime DataCadastro { get; set; }
    }
}