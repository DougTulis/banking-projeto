using BANK_MELHORADO.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_MELHORADO.Entidades {
    internal class ContaComum : ContaGenerica,IOperacaoBancaria {

        public string CPF { get; set; }

        public ContaComum() { }

        public ContaComum(string CPF, string Nome, string Senha, string Email, EnumConta TipoConta) : base(Nome, Senha, Email, TipoConta) {
            this.CPF = CPF;
            TipoConta = EnumConta.COMUM;

        }
        public override bool Equals(object? obj) {
            return base.Equals(obj);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override void Transferir(decimal Valor, ContaGenerica Origem, ContaGenerica Destino) {
            base.Transferir(Valor, Origem, Destino);
        }
    }
}
