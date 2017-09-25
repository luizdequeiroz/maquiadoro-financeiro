using Financeiro.Models.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Maps
{
    public class TerceiroMap : ClassMap<Terceiro>
    {
        public TerceiroMap()
        {
            Id(t => t.Id);
            Map(t => t.Nome);
            Map(t => t.Email);
            Map(t => t.Fone1);
            Map(t => t.Fone2);
            Map(t => t.Descricao);
            Map(t => t.Vencimento);
            Map(t => t.ValorMensal);
            Map(t => t.TempoContrato);
            Map(t => t.DataCadastroMap, "DataCadastro");
            Table("Terceiro");
        }
    }
}