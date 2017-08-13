using Financeiro.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Entidades
{
    public class Funcionario
    {
        public virtual int Id { get; set; }
        public virtual string NomeCompleto { get; set; }
        public virtual string DataNascimento { get; set; }
        public virtual string Fone1 { get; set; }
        public virtual string Fone2 { get; set; }
        public virtual string DataCadastro { get; set; }
        public virtual string DataAdmissao { get; set; }
        public virtual string Email { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string Usuario { get; set; }
        public virtual string Senha { get; set; }
        public virtual string Logradouro { get; set; }
        public virtual int Numero { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Municipio { get; set; }
        public virtual string Estado { get; set; }
        public virtual int SetorId { get; set; }

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