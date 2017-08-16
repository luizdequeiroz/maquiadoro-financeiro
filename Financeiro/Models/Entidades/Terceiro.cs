using Financeiro.Models.Dao;
using Financeiro.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Entidades
{
    public class Terceiro
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Fone1 { get; set; }
        public virtual string Fone2 { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string Vencimento { get; set; }
        public virtual double ValorMensal { get; set; }
        public virtual int TempoContrato { get; set; }

        public virtual List<ContaBancaria> ContasBancarias
        {
            get
            {
                return new List<ContaBancaria>().SelecionarPorFavorecidoId(Id, ECategoria.Terceiro);
            }
        }
    }
}