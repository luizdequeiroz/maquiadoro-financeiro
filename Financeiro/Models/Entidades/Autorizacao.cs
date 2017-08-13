using Financeiro.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Entidades
{
    public class Autorizacao
    {
        public virtual int Id { get; set; }

        public virtual int MenuId { get; set; }
        public virtual int SetorId { get; set; }

        public virtual Menu Menu
        {
            get
            {
                return new Menu().SelecionarPorId(MenuId);
            }
            set
            {
                MenuId = value.Id;
            }
        }
        public virtual Setor Setor
        {
            get
            {
                return new Setor().SelecionarPorId(SetorId);
            }
            set
            {
                SetorId = value.Id;
            }
        }

    }
}