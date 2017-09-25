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

        public virtual string Vencimento { get; set; }
        public virtual double ValoPrevisto { get; set; }
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

        public virtual ESimOuNao EhAVista { get; set; }
        public virtual EFormaEntrega FormaDeEntrega { get; set; }
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
    }
}