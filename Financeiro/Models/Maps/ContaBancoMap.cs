using Financeiro.Models.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Maps
{
    public class ContaBancoMap : ClassMap<ContaBanco>
    {
        public ContaBancoMap()
        {
            Id(cb => cb.Id);
            Map(cb => cb.Nome);
            Map(cb => cb.NomeBanco);
            Map(cb => cb.Agencia);
            Map(cb => cb.Conta);
            Map(cb => cb.DestinatarioId);
            Table("ContaBanco");
        }
    }
}