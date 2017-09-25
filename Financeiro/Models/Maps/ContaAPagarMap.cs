using Financeiro.Models.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.MappingModel;
using Financeiro.Models.Enums;

namespace Financeiro.Models.Maps
{
    public class ContaAPagarMap : ClassMap<ContaAPagar>
    {
        public ContaAPagarMap()
        {
            Id(c => c.Id);

            Map(c => c.Vencimento);
            Map(c => c.ValorPrevisto);
            Map(c => c.Descricao);
            Map(c => c.TipoDespesaId);
            Map(c => c.CategoriaFavorecido);
            Map(c => c.FavorecidoId);

            Map(c => c.EhAVista);
            Map(c => c.FormaDeEntrega);
            Map(c => c.TransportadoraId);

            Map(c => c.ValeTransporte);
            Map(c => c.ValeAlimentacao);
            Map(c => c.Adicional);
            Map(c => c.Bonus);
            Map(c => c.Penalidade);
            Map(c => c.PlanoDeSaudeFuncionario);
            Map(c => c.PlanoDeSaudeCoparticipacao);
            Map(c => c.ComprasInternas);
            Map(c => c.Adiantamento);

            Map(c => c.DataInclusaoMap, "DataInclusao");
            Map(c => c.UsuarioInclusaoId);
            Map(c => c.DataAlteracaoMap, "DataAlteracao");
            Map(c => c.UsuarioAlteracaoId);
            Map(c => c.DataBaixaMap, "DataBaixa");
            Map(c => c.UsuarioBaixaId);

            Table("ContaAPagar");
        }
    }
}