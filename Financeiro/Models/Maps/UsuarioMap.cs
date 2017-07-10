using Financeiro.Models.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Maps
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Id(u => u.Id);
            Map(u => u.Nome);
            Map(u => u.Apelido);
            Map(u => u.Senha);
            Map(u => u.Nivel);
            Map(u => u.DataCadastro);
            Map(u => u.Email);
            Map(u => u.Telefone);
            Map(u => u.Celular);
            Table("Usuario");
        }
    }
}