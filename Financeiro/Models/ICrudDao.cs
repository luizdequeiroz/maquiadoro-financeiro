using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Models
{
    interface ICrudDao<T>
    {
        void Inserir(T t);
        T SelecionarPorId(int id);
        List<T> Selecionar();
        void Alterar(T t);
        void Excluir(T t);
    }
}
