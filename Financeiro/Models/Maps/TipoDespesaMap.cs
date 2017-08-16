using Financeiro.Models.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Maps
{
    public class TipoDespesaMap : ClassMap<TipoDespesa>
    {
        public TipoDespesaMap()
        {
            Id(d => d.Id);
            Map(d => d.Nome);
            Map(d => d.Descricao);
            Map(d => d.Categoria);
            Table("TipoDespesa");
        }
    }
}