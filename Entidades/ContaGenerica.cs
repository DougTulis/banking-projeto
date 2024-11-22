using BANK_MELHORADO.Entidades.Exceções;
using BANK_MELHORADO.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_MELHORADO.Entidades {
    internal abstract class ContaGenerica :  IOperacaoBancaria {
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public decimal Saldo { get; set; } // Set livre pq ele vai ser alterado ao depositar/transferir
        public EnumConta TipoConta { get; private set; }

        public ContaGenerica() {

        }

        public delegate ContaGenerica EncontrarConta(HashSet<ContaGenerica> Colecao, string Email);


        public ContaGenerica(string Nome, string Senha, string Email, EnumConta TipoConta) {
            this.Nome = Nome;
            this.Senha = Senha;
            this.Email = Email;
            this.TipoConta = TipoConta;
        }
       public void ConsultarSaldo() {
            Console.WriteLine("Saldo atual: R$" + Saldo.ToString("F2",CultureInfo.InvariantCulture));
        }

        public void Depositar(decimal Valor) {
            if (Valor <= 0) {
                throw new ContaException("Valor a ser depositado deve ser maior que zero.");
            }
            Saldo += Valor;
            
        }

        public void Sacar(decimal Valor) {
            if(Valor > Saldo) {
                throw new ContaException("Valor a ser sacado deve ser menor ou igual que o saldo.");
            }
            if (Valor <= 0 ) {
                throw new ContaException("O valor a sacar deve ser maior que zero");
            }
            Saldo -= Valor;
           

        }

        public virtual void Transferir(decimal Valor, ContaGenerica Origem, ContaGenerica Destino) {

            if(Valor <= 0) {
                throw new ContaException("Transferência deve ser maior que zero!");  
            }
            if (Valor > Origem.Saldo){
                throw new ContaException("Transferência deve ser menor que o saldo atual!");

            }

            Origem.Sacar(Valor);
            Destino.Depositar(Valor);
            Console.WriteLine("Transferência realizada!");
            Console.WriteLine("Saldo atual: R$" + Origem.Saldo.ToString("F2", CultureInfo.InvariantCulture));

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
