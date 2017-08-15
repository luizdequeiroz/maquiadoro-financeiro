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
                if (categoria == ECategoria.Fornecedor)
                {
                    var fornecedor = new Fornecedor();
                    return session.QueryOver<ContaBancaria>()
                        .Left.JoinAlias(c => c.Fornecedor, () => fornecedor)
                        .Where(c => c.FavorecidoId == favorecidoId).List().ToList();
                }
                else if (categoria == ECategoria.Funcionario)
                {
                    var funcionaro = new Funcionario();
                    return session.QueryOver<ContaBancaria>()
                        .Left.JoinAlias(c => c.Funcionario, () => funcionaro)
                        .Where(c => c.FavorecidoId == favorecidoId).List().ToList();
                }
                else
                {
                    var terceiro = new Terceiro();
                    return session.QueryOver<ContaBancaria>()
                        .Left.JoinAlias(c => c.Terceiro, () => terceiro)
                        .Where(c => c.FavorecidoId == favorecidoId).List().ToList();
                }
            }
        }
    }
}