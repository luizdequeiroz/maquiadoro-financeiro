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
            Id(f => f.Id);
            Map(f => f.Nome);
            Map(f => f.Email);
            Map(f => f.Fone1);
            Map(f => f.Fone2);
            Map(f => f.Descricao);
            Map(f => f.Vencimento);
            Map(f => f.ValorMensal);
            Map(f => f.TempoContrato);
            Table("Terceiro");
        }
    }
}