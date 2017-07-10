using Financeiro.Models.Entidades;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.DAOs
{
    public class CategoriaDao : CrudDao<Categoria>
    {
        public CategoriaDao()
        {
            SessionFactory.CriarSession();
        }

        public List<Categoria> SelecionarPorFiltro(string filtro)
        {
            using (var session = SessionFactory.AbrirSession())
            {
                return (from c in session.Query<Categoria>()
                        where c.Descricao.Contains(filtro)
                        select c).ToList();
            }
        }
    }
}