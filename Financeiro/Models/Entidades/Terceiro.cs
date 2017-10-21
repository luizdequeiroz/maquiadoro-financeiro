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
        public virtual long Id { get; set; }
        [Required(ErrorMessage = "Informe o nome!")]
        public virtual string Nome { get; set; }
        [Required(ErrorMessage = "Informe o e-mail!")]
        public virtual string Email { get; set; }
        [Required(ErrorMessage = "Informe o fone 1!")]
        public virtual string Fone1 { get; set; }
        public virtual string Fone2 { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string Vencimento { get; set; }
        public virtual string strValorMensal
        {
            get
            {
                return ValorMensal.ToString();
            }
            set
            {
                ValorMensal = double.Parse(value);
            }
        }
        public virtual double ValorMensal { get; set; }
        public virtual string TempoContrato { get; set; }
        public virtual string DataCadastro
        {
            get
            {
                return DataCadastroMap.ToString("dd/MM/yyyy");
            }
            set
            {
                DataCadastroMap = DateTime.Parse(value);
            }
        }
        public virtual DateTime DataCadastroMap { get; set; }

        public virtual List<ContaBancaria> ContasBancarias
        {
            get
            {
                //return new List<ContaBancaria>().SelecionarPorFavorecidoId(Id, ECategoria.Terceiro);
                return new List<ContaBancaria>().SelecionarOnde(cb => cb.CategoriaFavorecido == (int)ECategoria.Terceiro && cb.FavorecidoId == Id);
            }
        }
    }
}