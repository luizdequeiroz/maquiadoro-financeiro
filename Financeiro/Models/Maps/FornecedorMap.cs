using Financeiro.Models.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Maps
{
    public class FornecedorMap : ClassMap<Fornecedor>
    {
        public FornecedorMap()
        {
            Id(f => f.Id);
            Map(f => f.Id);
            Map(f => f.EhTransportador);
            Map(f => f.NomeFantasia);
            Map(f => f.RazaoSocial);
            Map(f => f.CNPJ);
            Map(f => f.DataCadastro);
            Map(f => f.Email);
            Map(f => f.Fone1);
            Map(f => f.Fone2);
            Map(f => f.Descricao);
            Map(f => f.Logradouro);
            Map(f => f.Numero);
            Map(f => f.Complemento);
            Map(f => f.Bairro);
            Map(f => f.Municipio);
            Map(f => f.Estado);
            Table("Fornecedor");
        }
    }
}