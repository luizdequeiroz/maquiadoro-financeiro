using Financeiro.Models.Entidades;
using Financeiro.Models.Enums;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Dao
{
    public static partial class CrudDao
    {
        public static List<ContaBancaria> SelecionarPorFavorecidoId(this List<ContaBancaria> contasBancarias, int favorecidoId, ECategoria categoria)
        {
            SessionFactory.CriarSession();
            using (var session = SessionFactory.AbrirSession())
            {
                return session.Query<ContaBancaria>().Where(cb => cb.CategoriaFavorecido == (int)categoria && cb.FavorecidoId == favorecidoId).ToList();
            }
        }
    }
}