using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Entidades
{
    public class ContaPagar
    {
        public virtual int Id { get; set; }
        public virtual int Operacao { get; set; }
        public virtual string Descricao { get; set; }
        public virtual DateTime DataInclusao { get; set; }
        public virtual double ValorPrevisto { get; set; }
        public virtual DateTime DataBaixa { get; set; }
        public virtual double ValorBaixado { get; set; }
        public virtual int DestinatarioId { get; set; }
        public virtual int IdBanco { get; set; }
        public virtual int CategoriaId { get; set; }
        public virtual int UsuarioId { get; set; }
    }
}