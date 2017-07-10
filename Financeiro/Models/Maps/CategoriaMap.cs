using Financeiro.Models.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Maps
{
    public class CategoriaMap : ClassMap<Categoria>
    {
        public CategoriaMap()
        {
            Id(c => c.Id);
            Map(c => c.Nome);
            Map(c => c.Descricao);
            Table("Categoria");
        }
    }
}