using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Entidades
{
    public class Inativo
    {
        public virtual int Id { get; set; }
        public virtual int IdInativo { get; set; }
        public virtual string Dados { get; set; }
        public virtual string Tabela { get; set; }
    }
}