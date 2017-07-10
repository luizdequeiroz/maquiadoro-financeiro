using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Financeiro.Models.Entidades
{
    public class ContaBanco
    {
        public virtual int Id { get; set; }
        [Required(ErrorMessage = "Insira o nome (de acordo com a conta bancária)!")]
        public virtual string Nome { get; set; }
        [Required(ErrorMessage = "Informe o banco!")]
        public virtual string NomeBanco { get; set; }
        [Required(ErrorMessage = "Informe o número da agência!")]
        public virtual string Agencia { get; set; }
        [Required(ErrorMessage = "Informe o número da conta!")]
        public virtual string Conta { get; set; }
        public virtual int DestinatarioId { get; set; }
    }
}