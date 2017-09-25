using Financeiro.Models.Dao;
using Financeiro.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Entidades
{
    public class ContaAPagar
    {
        #region Genérico
        public virtual int Id { get; set; }

        public virtual string Vencimento
        {
            get
            {
                return VencimentoMap.ToString("dd/MM/yyyy");
            }
            set
            {
                VencimentoMap = DateTime.Parse(value);
            }
        }
        public virtual DateTime VencimentoMap { get; set; }
        public virtual double ValorPrevisto { get; set; }
        public virtual string Descricao { get; set; }
        public virtual int TipoDespesaId { get; set; }

        public virtual int CategoriaFavorecido { get; set; }
        public virtual int FavorecidoId { get; set; }

        public virtual TipoDespesa TipoDespesa
        {
            get
            {
                return new TipoDespesa().SelecionarPorId(TipoDespesaId);
            }
            set
            {
                TipoDespesaId = value.Id;
            }
        }
        #endregion

        #region Fornecedor
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

        public virtual int EhAVista { get; set; }
        public virtual int FormaDeEntrega { get; set; }
        public virtual int TransportadoraId { get; set; }

        public virtual Fornecedor Transportadora
        {
            get
            {
                return new Fornecedor().SelecionarPorId(TransportadoraId);
            }
            set
            {
                TransportadoraId = value.Id;
            }
        }
        #endregion

        #region Funcionario
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

        public virtual double ValeTransporte { get; set; }
        public virtual double ValeAlimentacao { get; set; }
        public virtual double Adicional { get; set; }
        public virtual double Bonus { get; set; }

        public virtual double Penalidade { get; set; }
        public virtual double PlanoDeSaudeFuncionario { get; set; }
        public virtual double PlanoDeSaudeCoparticipacao { get; set; }
        public virtual double ComprasInternas { get; set; }
        public virtual double Adiantamento { get; set; }
        #endregion

        #region Terceiro
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
        #endregion

        #region Auditoria
        public virtual string DataInclusao
        {
            get
            {
                return DataInclusaoMap.ToString("dd/MM/yyyy");
            }
            set
            {
                DataInclusaoMap = DateTime.Parse(value);
            }
        }
        public virtual DateTime DataInclusaoMap { get; set; }
        public virtual int UsuarioInclusaoId { get; set; }
        public virtual Funcionario UsuarioInclusao
        {
            get
            {
                return new Funcionario().SelecionarPorId(UsuarioInclusaoId);
            }
            set
            {
                UsuarioInclusaoId = value.Id;
            }
        }
        public virtual string DataAlteracao
        {
            get
            {
                return DataAlteracaoMap.ToString("dd/MM/yyyy");
            }
            set
            {
                DataAlteracaoMap = DateTime.Parse(value);
            }
        }
        public virtual DateTime DataAlteracaoMap { get; set; }
        public virtual int UsuarioAlteracaoId { get; set; }
        public virtual Funcionario UsuarioAlteracao
        {
            get
            {
                return new Funcionario().SelecionarPorId(UsuarioAlteracaoId);
            }
            set
            {
                UsuarioAlteracaoId = value.Id;
            }
        }
        public virtual string DataBaixa
        {
            get
            {
                return DataBaixaMap.ToString("dd/MM/yyyy");
            }
            set
            {
                DataBaixaMap = DateTime.Parse(value);
            }
        }
        public virtual DateTime DataBaixaMap { get; set; }
        public virtual int UsuarioBaixaId { get; set; }
        public virtual Funcionario UsuarioBaixa
        {
            get
            {
                return new Funcionario().SelecionarPorId(UsuarioBaixaId);
            }
            set
            {
                UsuarioBaixaId = value.Id;
            }
        }
        #endregion
    }
}