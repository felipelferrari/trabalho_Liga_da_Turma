using System;
using System.Collections.Generic;

class Program
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
                Console.WriteLine("\n⚠️ Opção inválida!");
                Pausar();
            }
        }
    }

    static void CadastrarEquipe()
    {
        Console.Clear();
        Console.WriteLine("--- CADASTRO DE EQUIPE ---\n");

        Console.Write("Digite o nome da equipe: ");
        string nome = Console.ReadLine()!;

        if (nome != "")
        {
            Equipe novaEquipe = new Equipe(nome);
            listaEquipes.Add(novaEquipe);
            Console.WriteLine("\n✅ Equipe '" + nome + "' cadastrada com sucesso!");
        }
        else
        {
            Console.WriteLine("\n⚠️ O nome não pode ser vazio!");
        }

        Pausar();
    }

    static void RegistrarPartida()
    {
        Console.Clear();
        Console.WriteLine("--- REGISTRO DE PARTIDA ---\n");

        if (listaEquipes.Count < 2)
        {
            Console.WriteLine("⚠️ Você precisa de pelo menos 2 equipes cadastradas para registrar um jogo.");
            Pausar();
            return;
        }

        Console.WriteLine("Equipes disponíveis:");
        for (int i = 0; i < listaEquipes.Count; i++)
        {
            Console.WriteLine((i + 1) + " - " + listaEquipes[i].Nome);
        }

        Console.Write("\nEscolha o número do Time A: ");
        int idxA = int.Parse(Console.ReadLine()!) - 1;

        Console.Write("Escolha o número do Time B: ");
        int idxB = int.Parse(Console.ReadLine()!) - 1;

        Equipe timeA = listaEquipes[idxA];
        Equipe timeB = listaEquipes[idxB];

        Console.Write("\nQual a modalidade? (1 - Futsal | 2 - eSports): ");
        string tipo = Console.ReadLine()!;

        if (tipo == "1")
        {
            Console.Write("Gols do " + timeA.Nome + ": ");
            int golsA = int.Parse(Console.ReadLine()!);

            Console.Write("Gols do " + timeB.Nome + ": ");
            int golsB = int.Parse(Console.ReadLine()!);

            PartidaFutsal jogoFutsal = new PartidaFutsal(contadorId, timeA, timeB, golsA, golsB);
            listaPartidas.Add(jogoFutsal);
            contadorId++;

            Console.WriteLine("\n✅ Partida de Futsal registrada com sucesso!");
        }
        else if (tipo == "2")
        {
            int mapasA = 0;
            int mapasB = 0;
            bool placarValido = false;

            while (placarValido == false)
            {
                Console.Write("Mapas vencidos pelo " + timeA.Nome + ": ");
                mapasA = int.Parse(Console.ReadLine()!);

                Console.Write("Mapas vencidos pelo " + timeB.Nome + ": ");
                mapasB = int.Parse(Console.ReadLine()!);

                // Validação da MD3
                if ((mapasA == 2 && mapasB == 0) || (mapasA == 2 && mapasB == 1) ||
                    (mapasA == 0 && mapasB == 2) || (mapasA == 1 && mapasB == 2))
                {
                    placarValido = true;
                }
                else
                {
                    Console.WriteLine("\n⚠️ Placar inválido para MD3! Aceito apenas: 2x0, 2x1, 0x2 ou 1x2. Tente de novo.\n");
                }
            }

            PartidaESports jogoESports = new PartidaESports(contadorId, timeA, timeB, mapasA, mapasB);
            listaPartidas.Add(jogoESports);
            contadorId++;

            Console.WriteLine("\n✅ Partida de eSports registrada com sucesso!");
        }

        Pausar();
    }

    static void ConsultarHistorico()
    {
        Console.Clear();
        Console.WriteLine("--- HISTÓRICO DE PARTIDAS ---\n");

        if (listaPartidas.Count == 0)
        {
            Console.WriteLine("Nenhuma partida registrada até o momento.");
        }
        else
        {
            for (int i = 0; i < listaPartidas.Count; i++)
            {
                Partida p = listaPartidas[i];
                Console.WriteLine("Jogo #" + p.Id + " | " + p.EquipeA.Nome + " vs " + p.EquipeB.Nome + " | Resultado: " + p.ObterResultado());
            }
        }

        Pausar();
    }

    static void CadastrarFestival()
    {
        Console.Clear();
        Console.WriteLine("--- CADASTRO DO FESTIVAL ---\n");

        Console.Write("Nome do Festival: ");
        string nome = Console.ReadLine()!;

        Console.Write("Local: ");
        string local = Console.ReadLine()!;

        Console.Write("Data: ");
        string data = Console.ReadLine()!;

        Console.Write("Horário: ");
        string horario = Console.ReadLine()!;

        festivalAtual = new Festival(nome, local, data, horario);

        Console.WriteLine("\nConvite Gerado:");
        Console.WriteLine(festivalAtual.GerarCartao());

        Pausar();
    }

    static void GerarCartaoPartida()
    {
        Console.Clear();
        Console.WriteLine("--- GERAR CARTÃO DE RESULTADO ---\n");

        if (listaPartidas.Count == 0)
        {
            Console.WriteLine("⚠️ Nenhuma partida cadastrada.");
            Pausar();
            return;
        }

        Console.Write("Digite o número (ID) da partida: ");
        int idProcurado = int.Parse(Console.ReadLine()!);

        bool achou = false;
        for (int i = 0; i < listaPartidas.Count; i++)
        {
            if (listaPartidas[i].Id == idProcurado)
            {
                Console.WriteLine("\n" + listaPartidas[i].GerarCartao());
                achou = true;
                break;
            }
        }

        if (achou == false)
        {
            Console.WriteLine("⚠️ Partida não encontrada!");
        }

        Pausar();
    }

    static void Pausar()
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}