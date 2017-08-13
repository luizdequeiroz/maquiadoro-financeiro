using Financeiro.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Entidades
{
    public class Setor
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }

        public virtual List<Funcionario> Funcionarios
        {
            get
            {
                return new List<Funcionario>().Selecionar().Where(f => f.SetorId == Id).ToList();
            }
        }
        public virtual List<Autorizacao> Autorizacoes
        {
            get
            {
                return new List<Autorizacao>().Selecionar().Where(a => a.SetorId == Id).ToList();
            }
        }
    }
}