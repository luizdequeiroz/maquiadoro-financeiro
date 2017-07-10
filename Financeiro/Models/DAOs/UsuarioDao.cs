using Financeiro.Models.Entidades;
using Financeiro.Models.Enums;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.DAOs
{
    public class UsuarioDao : CrudDao<Usuario>
    {
        public UsuarioDao()
        {
            SessionFactory.CriarSession();
        }

        public Usuario SelecionarPorEmail(string email)
        {
            using (var session = SessionFactory.AbrirSession())
            {
                return (from u in session.Query<Usuario>() where u.Email == email select u).SingleOrDefault();
            }
        }

        public List<Usuario> SelecionarPorFiltro(String filtro)
        {
            using (var session = SessionFactory.AbrirSession())
            {
                return (from u in session.Query<Usuario>()
                        where u.Nome.Contains(filtro) ||
                              u.Apelido.Contains(filtro) ||
                              u.DataCadastro.ToString().Contains(filtro)
                        select u).ToList();
            }
        }
    }
}