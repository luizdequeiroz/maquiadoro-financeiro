﻿using Financeiro.Models.Dao;
using Financeiro.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Entidades
{
    public class Fornecedor
    {
        public virtual long Id { get; set; }
        public virtual int EhTransportador { get; set; }

        [Required(ErrorMessage = "Informe o nome fantasia!")]
        public virtual string NomeFantasia { get; set; }
        public virtual string RazaoSocial { get; set; }
        public virtual string CNPJ { get; set; }
        public virtual string Email { get; set; }
        public virtual string Fone1 { get; set; }
        public virtual string Fone2 { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string Logradouro { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Complemento { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Municipio { get; set; }
        public virtual string Estado { get; set; }
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
                //return new List<ContaBancaria>().SelecionarPorFavorecidoId(Id, ECategoria.Fornecedor);
                return new List<ContaBancaria>().SelecionarOnde(cb => cb.CategoriaFavorecido == (int)ECategoria.Fornecedor && cb.FavorecidoId == Id);
            }
        }
    }
}