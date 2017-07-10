using Financeiro.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.DAOs
{
    public class DestinatarioDao : CrudDao<Destinatario>
    {
        public DestinatarioDao()
        {
            SessionFactory.CriarSession();
        }
    }
}