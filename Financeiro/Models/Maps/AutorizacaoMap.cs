using Financeiro.Models.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Maps
{
    public class AutorizacaoMap : ClassMap<Autorizacao>
    {
        public AutorizacaoMap()
        {
            Id(a => a.Id);
            Map(a => a.MenuId);
            Map(a => a.SetorId);
            Table("Autorizacao");
        }
    }
}