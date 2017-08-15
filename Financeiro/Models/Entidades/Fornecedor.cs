using Financeiro.Models.Dao;
using Financeiro.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Entidades
{
    public class Fornecedor
    {
        public virtual int Id { get; set; }
        public virtual int EhTransportador { get; set; }
        public virtual string NomeFantasia { get; set; }
        public virtual string RazaoSocial { get; set; }
        public virtual string CNPJ { get; set; }
        public virtual string DataCadastro { get; set; }
        public virtual string Email { get; set; }
        public virtual string Fone1 { get; set; }
        public virtual string Fone2 { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string Logradouro { get; set; }
        public virtual int Numero { get; set; }
        public virtual string Complemento { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Municipio { get; set; }
        public virtual string Estado { get; set; }

        public virtual List<ContaBancaria> ContasBancarias
        {
            get
            {
                return new List<ContaBancaria>().SelecionarPorFavorecidoId(Id, ECategoria.Fornecedor);
            }
        }
    }
}