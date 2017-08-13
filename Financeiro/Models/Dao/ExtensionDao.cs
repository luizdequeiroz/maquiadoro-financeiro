using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Financeiro.Models.Dao
{
    public static partial class CrudDao
    {
        public static void Inserir<T>(this T t)
        {
            using (var session = SessionFactory.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(t);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir dados: " + e.Message);
                    }
                }
            }
        }
        public static T SelecionarPorId<T>(this T t, int id)
        {
            using (var session = SessionFactory.AbrirSession())
            {
                t = session.Get<T>(id);
                return t;
            }
        }
        public static List<T> Selecionar<T>(this List<T> ts)
        {
            using (var session = SessionFactory.AbrirSession())
            {
                ts = (from t in session.Query<T>() select t).ToList();
                return ts;
            }
        }
        public static void Alterar<T>(this T t)
        {
            using (var session = SessionFactory.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(t);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao alterar dados: " + e.Message);
                    }
                }
            }
        }
        public static void Excluir<T>(this T t)
        {
            using (var session = SessionFactory.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(t);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao excluir dados: " + e.Message);
                    }
                }
            }
        }
    }
}