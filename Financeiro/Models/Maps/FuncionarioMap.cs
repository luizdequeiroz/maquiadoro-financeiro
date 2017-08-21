using Financeiro.Models.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Maps
{
    public class FuncionarioMap : ClassMap<Funcionario>
    {
        public FuncionarioMap()
        {
            Id(f => f.Id);
            Map(f => f.NomeCompleto);
            Map(f => f.DataNascimento);
            Map(f => f.Email);
            Map(f => f.Fone1);
            Map(f => f.Fone2);
            Map(f => f.Descricao);
            Map(f => f.Usuario);
            Map(f => f.Senha);
            Map(f => f.SetorId);
            Map(f => f.DataCadastro);
            Map(f => f.DataAdmissao);
            Map(f => f.Logradouro);
            Map(f => f.Numero);
            Map(f => f.Complemento);
            Map(f => f.Bairro);
            Map(f => f.Municipio);
            Map(f => f.Estado);
            Table("Funcionario");
        }
    }
}