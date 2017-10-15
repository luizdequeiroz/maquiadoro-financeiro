using Financeiro.Models.Dao;
using Financeiro.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Entidades
{
    public class ContaBancaria
    {
        public virtual long Id { get; set; }
        public virtual string NomeTitular { get; set; }

        [Required(ErrorMessage = "Informe o nome do banco!")]
        public virtual string NomeBanco { get; set; }
        [Required(ErrorMessage = "Informe a agência!")]
        public virtual string Agencia { get; set; }
        [Required(ErrorMessage = "Informe a conta!")]
        public virtual string Conta { get; set; }

        public virtual string Op { get; set; }
        public virtual int CategoriaFavorecido { get; set; }
        public virtual long FavorecidoId { get; set; }

        public virtual Fornecedor Fornecedor
        {
            get
            {
                return new Fornecedor().SelecionarPorId(FavorecidoId);
            }
            set
            {
                CategoriaFavorecido = (int)ECategoria.Fornecedor;
                FavorecidoId = value.Id;
            }
        }
        public virtual Funcionario Funcionario
        {
            get
            {
                return new Funcionario().SelecionarPorId(FavorecidoId);
            }
            set
            {
                CategoriaFavorecido = (int)ECategoria.Funcionario;
                FavorecidoId = value.Id;
            }
        }
        public virtual Terceiro Terceiro
        {
            get
            {
                return new Terceiro().SelecionarPorId(FavorecidoId);
            }
            set
            {
                CategoriaFavorecido = (int)ECategoria.Terceiro;
                FavorecidoId = value.Id;
            }
        }
    }
}