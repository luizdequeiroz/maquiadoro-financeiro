using Financeiro.Models.Dao;
using Financeiro.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Entidades
{
    public class Terceiro
    {
        public virtual int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome!")]
        public virtual string Nome { get; set; }
        [Required(ErrorMessage = "Informe o e-mail!")]
        public virtual string Email { get; set; }
        [Required(ErrorMessage = "Informe o fone 1!")]
        public virtual string Fone1 { get; set; }
        public virtual string Fone2 { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string Vencimento { get; set; }
        public virtual string ValorMensal { get; set; }
        public virtual string TempoContrato { get; set; }
        public virtual string DataCadastro { get; set; }

        public virtual List<ContaBancaria> ContasBancarias
        {
            get
            {
                return new List<ContaBancaria>().SelecionarPorFavorecidoId(Id, ECategoria.Terceiro);
            }
        }
    }
}