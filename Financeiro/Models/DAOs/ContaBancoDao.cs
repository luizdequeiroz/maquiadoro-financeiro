using Financeiro.Models.Entidades;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.DAOs
{
    public class ContaBancoDao : CrudDao<ContaBanco>
    {
        public ContaBancoDao()
        {
            SessionFactory.CriarSession();
        }

        public List<ContaBanco> SelecionarPorFiltro(string filtro)
        {
            using (var session = SessionFactory.AbrirSession())
            {
                return (from b in session.Query<ContaBanco>()
                        where b.Nome.Contains(filtro) ||
                              b.NomeBanco.Contains(filtro) ||
                              b.Agencia.Contains(filtro) ||
                              b.Conta.Contains(filtro)
                        select b).ToList();
            }
        }

        public List<ContaBanco> SelecionarPorDestinatarioId(int destinatarioId)
        {
            using (var session = SessionFactory.AbrirSession())
            {
                return (from b in session.Query<ContaBanco>()
                        where b.DestinatarioId == destinatarioId
                        select b).ToList();
            }
        }

        public void ExcluirContasPorDestinatario(int destinatarioId)
        {
            using (var session = SessionFactory.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        var contas = SelecionarPorDestinatarioId(destinatarioId);
                        int id = 0;
                        string dados = "";

                        foreach (var cb in contas)
                        {
                            var props = cb.GetType().GetProperties();
                            var table = cb.GetType().Name;

                            foreach (var p in props)
                                if (id == 0) id = int.Parse(p.GetValue(cb, null).ToString());
                                else if (dados == "") dados += p.GetValue(cb, null).ToString();
                                else if (p.GetValue(cb, null) != null) dados += "|" + p.GetValue(cb, null).ToString();

                            session.Save(new Inativo { IdInativo = id, Dados = dados, Tabela = table });

                            session.Delete(cb);
                        }

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