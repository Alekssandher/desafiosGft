using InventarioCriaturas.Models;
using InventarioCriaturas.Services;

namespace InventarioCriaturas
{
    class Program
    {
        static void Main()
        {
            var inventario = new Inventario();
            bool continuar = true;

            Console.WriteLine("=== Sistema de Inventário de Criaturas ===");

            while (continuar)
            {
                Console.WriteLine("\nEscolha o tipo de criatura para adicionar:");
                Console.WriteLine("1 - Dragão");
                Console.WriteLine("2 - Fênix");
                Console.WriteLine("3 - Grifo");
                Console.WriteLine("0 - Finalizar cadastro");

                string opcao = Console.ReadLine()?.Trim() ?? "";

                Criatura? criatura = opcao switch
                {
                    "1" => CriarCriatura("Dragao"),
                    "2" => CriarCriatura("Fenix"),
                    "3" => CriarCriatura("Grifo"),
                    "0" => null,
                    _ => null
                };

                if (criatura != null)
                {
                    inventario.Adicionar(criatura);
                    Console.WriteLine($"{criatura.Nome} adicionada ao inventário!");
                }
                else if (opcao == "0")
                {
                    continuar = false;
                }
                else
                {
                    Console.WriteLine("Opção inválida!");
                }
            }

            var maisPoderosa = inventario.CriaturaMaisPoderosa();
            if (maisPoderosa != null)
            {
                Console.WriteLine($"\nCriatura mais poderosa: {maisPoderosa.Nome} " +
                                  $"(Poder: {maisPoderosa.Poder}, Força Total: {maisPoderosa.ForcaTotal()})");
            }
            else
            {
                Console.WriteLine("\nNenhuma criatura cadastrada.");
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
        
        static Criatura? CriarCriatura(string tipo)
        {
            string nome;
            do
            {
                Console.Clear();
                Console.Write("Digite o nome da criatura: ");
                nome = Console.ReadLine()?.Trim() ?? "";
                if (string.IsNullOrEmpty(nome))
                    Console.WriteLine("Nome não pode ser vazio!");
            } while (string.IsNullOrEmpty(nome));

            string poder;
            do
            {
                Console.Write("Digite o poder da criatura: ");
                poder = Console.ReadLine()?.Trim() ?? "";
                if (string.IsNullOrEmpty(poder))
                    Console.WriteLine("Poder não pode ser vazio!");
            } while (string.IsNullOrEmpty(poder));

            int forcaBase;
            while (true)
            {
                Console.Write("Digite a força base (número inteiro): ");
                string input = Console.ReadLine()?.Trim() ?? "";
                if (int.TryParse(input, out forcaBase)) break;
                Console.WriteLine("Valor inválido! Digite um número inteiro válido.");
            }

            return tipo switch
            {
                "Dragao" => new Dragao(nome, poder, forcaBase),
                "Fenix" => new Fenix(nome, poder, forcaBase),
                "Grifo" => new Grifo(nome, poder, forcaBase),
                _ => null
            };
        }
    }
}