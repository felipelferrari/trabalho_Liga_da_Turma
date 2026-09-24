partial class Program
{
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
}

