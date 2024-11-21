using BANK_MELHORADO.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_MELHORADO.Entidades {
    internal class ContaLojista : ContaGenerica {

        public string CNPJ { get; private set; }

        public ContaLojista() {
        }

        public ContaLojista(EnumConta Enum, string CNPJ, string Nome, string Senha, string Email) : base(Nome, Senha, Email,Enum){
            this.CNPJ = CNPJ;
            Enum = EnumConta.LOJISTA;
        
        }

        public override bool Equals(object? obj) {
            return base.Equals(obj);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}
