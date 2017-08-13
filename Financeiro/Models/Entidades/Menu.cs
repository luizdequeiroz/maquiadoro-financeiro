using Financeiro.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Entidades
{
    public class Menu
    {
        public virtual int Id { get; set; }
        public virtual string Class { get; set; }
        public virtual string Href { get; set; }
        public virtual string Controller { get; set; }
        public virtual string IdHtml { get; set; }
        public virtual string Target { get; set; }
        public virtual string Texto { get; set; }

        public virtual List<Autorizacao> Autorizacoes
        {
            get
            {
                return new List<Autorizacao>().Selecionar().Where(a => a.MenuId == Id).ToList();
            }
        }
    }
}