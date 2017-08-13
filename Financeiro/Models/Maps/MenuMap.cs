using Financeiro.Models.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Maps
{
    public class MenuMap : ClassMap<Menu>
    {
        public MenuMap()
        {
            Id(m => m.Id);
            Map(m => m.Class);
            Map(m => m.Href);
            Map(m => m.Controller);
            Map(m => m.IdHtml);
            Map(m => m.Target);
            Map(m => m.Texto);
            Table("Menu");
        }
    }
}