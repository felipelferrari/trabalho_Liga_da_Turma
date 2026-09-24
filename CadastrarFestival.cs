 partial class Program
{
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
}