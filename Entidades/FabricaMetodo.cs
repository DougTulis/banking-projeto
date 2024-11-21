using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_MELHORADO.Entidades {
    internal class FabricaMetodo {

        public static ContaGenerica? Fabrica(EnumConta TipoConta, string Nome, string Email,string Senha,string Id) {
            switch (TipoConta) {
                case EnumConta.COMUM:
                    Console.WriteLine("Conta Comum criada! Seja Bem vindo " + Nome +"!");
                    return new ContaComum(Id, Nome, Senha, Email, TipoConta);

                case EnumConta.LOJISTA:
                    Console.WriteLine("Conta Lojista criada! Seja Bem vindo " + Nome + "!");
                    return new ContaLojista(TipoConta, Id, Nome, Senha, Email);
            }
            return null;
        }
    }
}
