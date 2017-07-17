using Financeiro.Models.Entidades;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models
{
    public class CrudDao<T> : ICrudDao<T> where T : class
    {
        public void Inserir(T t)
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

        public T SelecionarPorId(int id)
        {
            using (var session = SessionFactory.AbrirSession())
            {
                return session.Get<T>(id);
            }
        }

        public List<T> Selecionar()
        {
            using (var session = SessionFactory.AbrirSession())
            {
                return (from t in session.Query<T>() select t).ToList();
            }
        }

        public void Alterar(T t)
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

        public void Excluir(T t)
        {
            using (var session = SessionFactory.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        int id = 0;
                        string dados = "";
                        var props = t.GetType().GetProperties();
                        var table = t.GetType().Name;

                        foreach (var p in props)
                            if (id == 0) id = int.Parse(p.GetValue(t, null).ToString());
                            else if (dados == "") dados += p.GetValue(t, null).ToString();
                            else if (p.GetValue(t,null) != null) dados += "|" + p.GetValue(t, null).ToString();

                        session.Save(new Inativo { IdInativo = id, Dados = dados, Tabela = table });

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