using Financeiro.Models.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Maps
{
    public class ContaBancariaMap : ClassMap<ContaBancaria>
    {
        public ContaBancariaMap()
        {
            Id(c => c.Id);
            Map(c => c.NomeTitular);
            Map(c => c.NomeBanco);
            Map(c => c.Agencia);
            Map(c => c.Conta);
            Map(c => c.Op);
            Map(c => c.CategoriaFavorecido);
            Map(c => c.FavorecidoId);
            Table("ContaBancaria");
        }
    }
}