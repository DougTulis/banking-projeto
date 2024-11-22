using BANK_MELHORADO.Entidades;
using BANK_MELHORADO.Entidades.Exceções;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace BANK_MELHORADO {
    internal class Program {

        static HashSet<ContaGenerica> BancoDeContas = new HashSet<ContaGenerica>();
        static void Main(string[] args) {

            
            BancoDeContas.Add(new ContaLojista(EnumConta.LOJISTA, "48327703000155", "Olivia Enxovais", "123", "camila@gmail.com"));
            BancoDeContas.Add(new ContaLojista(EnumConta.LOJISTA, "00742862000190 ", "Cantinho da Roça", "1234", "cantinho@gmail.com"));
            BancoDeContas.Add(new ContaLojista(EnumConta.COMUM, "99999999999 ", "Douglas Aparecido", "120", "dotulis@gmail.com"));

            try {
                Console.Write("Já possui cadastro? (SIM/NÃO): ");
                string Resposta = Console.ReadLine();
                int Escolha;
                if (Resposta.Equals("NÃO", StringComparison.OrdinalIgnoreCase) || Resposta.Equals("Nao", StringComparison.OrdinalIgnoreCase)) {
                    Console.Write("Digite o nome completo: ");
                    string Nome = Console.ReadLine();

                    Console.Write("Conta Lojista ou Comum? ");
                    EnumConta Tipo = Enum.Parse<EnumConta>(Console.ReadLine().ToUpper());

                    if (Tipo == EnumConta.COMUM) {
                        Console.Write("Digite o CPF: ");
                    }
                    else {
                        Console.Write("Digite o CNPJ: ");
                    }
                    string Id = Console.ReadLine();
                    Console.Write("Digite o Email: ");
                    string Email = Console.ReadLine();
                    Console.Write("Digite sua nova senha: ");
                    string Senha = Console.ReadLine();
                    var ContaGenerica = FabricaMetodo.Fabrica(Tipo, Nome, Email, Senha, Id);  // upcasting

                    do {
                        MenuPrincipal();
                        Escolha = int.Parse(Console.ReadLine());
                        ImputarEscolha(Escolha, ContaGenerica);
                    } while (Escolha != 0);
                }
                else if (Resposta.Equals("SIM", StringComparison.OrdinalIgnoreCase)) {
                    ContaGenerica ContaGenerica;
                
                        Console.Write("Digite o Email: ");
                        string Email = Console.ReadLine();
                        Console.Write("Digite a senha: ");
                        string Senha = Console.ReadLine();
                        ContaGenerica = EncontrarContaServico.EncontrarConta(BancoDeContas, Email, Senha);
               
                    do {
                        MenuPrincipal();
                        Escolha = int.Parse(Console.ReadLine());
                        ImputarEscolha(Escolha, ContaGenerica);
                    } while (Escolha != 0);
                }
            } catch(ContaException ex) {
                Console.WriteLine(ex.Message);
            }catch (Exception e) {
                Console.WriteLine(e.StackTrace);
            }
        }
        static void MenuPrincipal() {
            Console.WriteLine("########### M  E  N  U     P  R  I  N  C  I  P  A  L  ###########");
            Console.WriteLine("Escolha uma opção: ");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Deposito");
            Console.WriteLine("3. Sacar");
            Console.WriteLine("4. Transferir");
            Console.Write("Escolha a opção desejada: ");

        }
        static void ImputarEscolha(int Escolha, ContaGenerica Conta) {
        
            try { 
                switch (Escolha) {
               
                    case 1:
                        Conta.ConsultarSaldo();
                        break;
                    case 2:
                        Console.Write("Informe o valor para Depositar: ");
                        decimal Dep = decimal.Parse(Console.ReadLine());
                        Conta.Depositar(Dep);
                        break;
                    case 3:
                        Console.Write("Informe o valor para Sacar: ");
                        decimal Valor = decimal.Parse(Console.ReadLine());
                        Conta.Sacar(Valor);
                        break;
                    case 4:
                        ContaGenerica Destino;
                        Console.Write("Informe o valor para Transferência: ");
                        decimal Transf = decimal.Parse(Console.ReadLine());
                        Console.Write("Chave pix (email) da conta recebente: ");
                        string Chave = Console.ReadLine();
                        Destino = EncontrarContaServico.EncontrarContaPorEmail(BancoDeContas, Chave);
                        if (Destino != null) {
                            Conta.Transferir(Transf, Conta, Destino);
                        }
                        break;
                }
            }catch (ContaException ex)  {
                Console.WriteLine(ex.Message);
               
            }
        }
    }
}

