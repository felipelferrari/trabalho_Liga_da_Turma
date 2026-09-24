abstract class Partida : ICartaoDivulgacao
{
    public int Id;
    public Equipe EquipeA;
    public Equipe EquipeB;

    public Partida(int id, Equipe equipeA, Equipe equipeB)
    {
        Id = id;
        EquipeA = equipeA;
        EquipeB = equipeB;
    }

    public abstract string ObterResultado();

    public abstract string GerarCartao();
}