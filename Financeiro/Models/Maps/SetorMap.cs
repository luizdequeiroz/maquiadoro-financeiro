using Financeiro.Models.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Maps
{
    public class SetorMap : ClassMap<Setor>
    {
        public SetorMap()
        {
            Id(s => s.Id);
            Map(s => s.Nome);
            Map(s => s.Descricao);
            Table("Setor");
        }
    }
}