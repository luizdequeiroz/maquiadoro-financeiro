using Financeiro.Models.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Maps
{
    public class DestinatarioMap : ClassMap<Destinatario>
    {
        public DestinatarioMap()
        {
            Id(d => d.Id);
            Map(d => d.Tipo);
            Map(d => d.NomeSocial);
            Map(d => d.ApelidoFantasia);
            Map(d => d.TipoPessoa);
            Map(d => d.CadastroPessoa);
            Map(d => d.Descricao);
            Map(d => d.Email);
            Map(d => d.Telefone);
            Map(d => d.Celular);
            Map(d => d.DataCadastro);
            Table("Destinatario");
        }
    }
}