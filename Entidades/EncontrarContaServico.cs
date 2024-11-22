using BANK_MELHORADO.Entidades.Exceções;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_MELHORADO.Entidades {
    internal static class EncontrarContaServico {

        public static ContaGenerica? EncontrarConta(HashSet<ContaGenerica> Colecao, string Email, string Senha) {
            bool Contem = false;
            foreach (var item in Colecao) {
                if (Email.Trim().Equals(item.Email.Trim()) && Senha.Trim().Equals(item.Senha.Trim())) {
                    Console.WriteLine("Seja bem vindo de volta, " + item.Nome + "!");
                    Contem = true;
                    return item;
                }                
            }
            if (!Contem) {
                throw new ContaException("Conta não encontrada no sistema, tente novamente.");
               
            }
            return null;
        }

        public static ContaGenerica? EncontrarContaPorEmail(HashSet<ContaGenerica> Colecao, string Email) {
            bool Contem = false;
            foreach (var item in Colecao) {
                if (Email.Trim().Equals(item.Email.Trim())) {
                    Contem = true;
                    return item;
                }
            }
            if (!Contem) {
                throw new ContaException("Conta não encontrada no sistema, tente novamente.");
            }
            return null;
        }

    }
}