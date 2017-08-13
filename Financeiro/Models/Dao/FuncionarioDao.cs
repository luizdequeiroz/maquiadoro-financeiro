using Financeiro.Models.Entidades;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Dao
{
    public static partial class CrudDao
    {
        public static Funcionario SelecionarPorUsuario(this Funcionario fun)
        {
            SessionFactory.CriarSession();
            using (var session = SessionFactory.AbrirSession())
            {                
                return session.Query<Funcionario>().Where(f => f.Usuario == fun.Usuario).SingleOrDefault();
            }
        }
    }
}