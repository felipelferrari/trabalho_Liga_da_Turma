using System;
using System.Collections.Generic;

partial class Program
{
    static List<Equipe> listaEquipes = new List<Equipe>();
    static List<Partida> listaPartidas = new List<Partida>();
    static Festival? festivalAtual = null; 
    static int contadorId = 1; 

    static void Main()
    {
        bool rodando = true;

        while (rodando)
        {
            Console.Clear(); 

            Console.WriteLine("==================================");
            Console.WriteLine("        LIGA DA TURMA - MENU      ");
            Console.WriteLine("==================================");
            Console.WriteLine("1 - Cadastrar Equipe");
            Console.WriteLine("2 - Registrar Partida (Futsal ou eSports)");
            Console.WriteLine("3 - Consultar Histórico de Partidas");
            Console.WriteLine("4 - Cadastrar Festival / Gerar Convite");
            Console.WriteLine("5 - Gerar Cartão de Resultado da Partida");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("==================================");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine()!;

            if (opcao == "1")
            {
                CadastrarEquipe();
            }
            else if (opcao == "2")
            {
                RegistrarPartida();
            }
            else if (opcao == "3")
            {
                ConsultarHistorico();
            }
            else if (opcao == "4")
            {
                CadastrarFestival();
            }
            else if (opcao == "5")
            {
                GerarCartaoPartida();
            }
            else if (opcao == "0")
            {
                rodando = false;
                Console.WriteLine("\nSaindo do programa...");
            }
            else
            {
                Console.WriteLine("\n Opção inválida!");
                Pausar();
            }
        }
    }

}
