using BANK_MELHORADO.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_MELHORADO.Entidades {
    internal abstract class ContaGenerica : IOperacaoBancaria {
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public decimal Saldo { get; set; } // Set livre pq ele vai ser alterado ao depositar/transferir
        public EnumConta TipoConta { get; set; }

        public ContaGenerica() { }

        public delegate ContaGenerica EncontrarConta(HashSet<ContaGenerica> Colecao, string Email);


        public ContaGenerica(string Nome, string Senha, string Email, EnumConta TipoConta) {
            this.Nome = Nome;
            this.Senha = Senha;
            this.Email = Email;
        }
       public void ConsultarSaldo() {
            Console.WriteLine("Saldo atual: " + Saldo.ToString("F2",CultureInfo.InvariantCulture));
        }

        public void Depositar(decimal Valor) {
            Saldo += Valor;
        }

        public void Sacar(decimal Valor) {
            Saldo -= Valor;
        }

        public virtual void Transferir(decimal Valor, ContaGenerica Origem, ContaGenerica Destino) {
            
            Origem.Sacar(Valor);
            Destino.Depositar(Valor);

        }

        public override bool Equals(object? obj) {
            return obj is ContaGenerica generica &&
                   Email == generica.Email;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Email);
        }
    }

}
