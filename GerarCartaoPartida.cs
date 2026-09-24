partial class Program
{
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