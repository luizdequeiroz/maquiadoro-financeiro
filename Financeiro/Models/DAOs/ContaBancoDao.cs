using Financeiro.Models.Entidades;
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
    }
}