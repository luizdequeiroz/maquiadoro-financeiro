using Financeiro.Models.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Maps
{
    public class InativoMap : ClassMap<Inativo>
    {
        public InativoMap()
        {
            Id(i => i.Id);
            Map(i => i.IdInativo);
            Map(i => i.Dados);
            Map(i => i.Tabela);
            Table("Inativo");
        }
    }
}