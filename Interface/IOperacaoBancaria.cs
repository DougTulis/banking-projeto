using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_MELHORADO.Interface {
    internal interface IOperacaoBancaria {

        void ConsultarSaldo();
        void Depositar(decimal Valor);
        void Sacar(decimal Valor);



    }
}
