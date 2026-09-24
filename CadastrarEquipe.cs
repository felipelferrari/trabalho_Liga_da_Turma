partial class Program
{

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
}