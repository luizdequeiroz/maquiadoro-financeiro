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
        public virtual long Id { get; set; }

        public virtual int Situacao { get; set; }

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
        public virtual DateTime VencimentoMap { get; set; } = DateTime.Now.AddDays(1);

        public virtual string strValorPrevisto
        {
            get
            {
                return ValorPrevisto.ToString();
            }
            set
            {
                ValorPrevisto = double.Parse(value);
            }
        }
        public virtual double ValorPrevisto { get; set; }
        public virtual string Descricao { get; set; }
        public virtual long TipoDespesaId { get; set; }

        public virtual int CategoriaFavorecido { get; set; }
        public virtual long FavorecidoId { get; set; }

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
        public virtual long TransportadoraId { get; set; } = -1;

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

        #region Funcionário
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

        public virtual string strValeTransporte
        {
            get
            {
                return ValeTransporte.ToString();
            }
            set
            {
                ValeTransporte = double.Parse(value);
            }
        }        
        public virtual double ValeTransporte { get; set; }
        public virtual string strValeAlimentacao
        {
            get
            {
                return ValeAlimentacao.ToString();
            }
            set
            {
                ValeAlimentacao = double.Parse(value);
            }
        }
        public virtual double ValeAlimentacao { get; set; }
        public virtual string strAdicional
        {
            get
            {
                return Adicional.ToString();
            }
            set
            {
                Adicional = double.Parse(value);
            }
        }
        public virtual double Adicional { get; set; }
        public virtual string strBonus
        {
            get
            {
                return Bonus.ToString();
            }
            set
            {
                Bonus = double.Parse(value);
            }
        }
        public virtual double Bonus { get; set; }

        public virtual string strPenalidade
        {
            get
            {
                return Penalidade.ToString();
            }
            set
            {
                Penalidade = double.Parse(value);
            }
        }
        public virtual double Penalidade { get; set; }
        public virtual string strPlanoDeSaudeFuncionario
        {
            get
            {
                return PlanoDeSaudeFuncionario.ToString();
            }
            set
            {
                PlanoDeSaudeFuncionario = double.Parse(value);
            }
        }
        public virtual double PlanoDeSaudeFuncionario { get; set; }
        public virtual string strPlanoDeSaudeCoparticipacao
        {
            get
            {
                return PlanoDeSaudeCoparticipacao.ToString();
            }
            set
            {
                PlanoDeSaudeCoparticipacao = double.Parse(value);
            }
        }
        public virtual double PlanoDeSaudeCoparticipacao { get; set; }
        public virtual string strComprasInternas
        {
            get
            {
                return ComprasInternas.ToString();
            }
            set
            {
                ComprasInternas = double.Parse(value);
            }
        }
        public virtual double ComprasInternas { get; set; }
        public virtual string strAdiantamento
        {
            get
            {
                return Adiantamento.ToString();
            }
            set
            {
                Adiantamento = double.Parse(value);
            }
        }
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
        public virtual DateTime DataInclusaoMap { get; set; } = DateTime.Now;
        public virtual long UsuarioInclusaoId { get; set; }
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
                return DataAlteracaoMap?.ToString("dd/MM/yyyy") ?? null;
            }
            set
            {
                DataAlteracaoMap = DateTime.Parse(value);
            }
        }
        public virtual DateTime? DataAlteracaoMap { get; set; }
        public virtual long UsuarioAlteracaoId { get; set; }
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
                return DataBaixaMap?.ToString("dd/MM/yyyy") ?? null;
            }
            set
            {
                DataBaixaMap = DateTime.Parse(value);
            }
        }
        public virtual DateTime? DataBaixaMap { get; set; }
        public virtual long UsuarioBaixaId { get; set; }
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