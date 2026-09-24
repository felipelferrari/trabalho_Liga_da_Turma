    partial class Program
{
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
}
