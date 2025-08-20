using System;
using CofreSonoroApp.Services;
using CofreSonoroApp.Utils;

namespace CofreSonoroApp
{
    class Program
    {
        static void Main()
        {
            string[] senhaCofre = ["DO", "RE", "MI", "FA"];
            var cofre = new CofreSonoro(senhaCofre);

            Console.WriteLine("Digite 4 notas separadas por espaço (ex: DO RE MI FA):");

            int tentativas = 0;
            const int maxTentativas = 3;
            bool aberto = false;

            while (tentativas < maxTentativas && !aberto)
            {
                Console.Write("> ");
                string input = Console.ReadLine();

                string[] notas = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (!Validador.ValidarNotas(notas) || notas.Length != 4)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida! Digite exatamente 4 notas.");
                    continue; 
                }

                if (cofre.TentarAbrir(notas))
                {
                    Console.Clear();
                    Console.WriteLine("Cofre aberto com sucesso!");
                    aberto = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Sequência incorreta.");
                    tentativas++;
                }
            }

            if (!aberto)
                Console.WriteLine("Número máximo de tentativas atingido.");

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}

