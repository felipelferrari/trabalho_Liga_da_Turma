class PartidaESports : Partida
{
    public int MapasA;
    public int MapasB;

    public PartidaESports(int id, Equipe equipeA, Equipe equipeB, int mapasA, int mapasB) 
        : base(id, equipeA, equipeB)
    {
        MapasA = mapasA;
        MapasB = mapasB;
    }

    public override string ObterResultado()
    {
        if (MapasA > MapasB)
        {
            return "Vitória de " + EquipeA.Nome;
        }
        else
        {
            return "Vitória de " + EquipeB.Nome;
        }
    }

    public override string GerarCartao()
    {
        return "------------------------------\n" +
               "🎮 CARTÃO DE eSPORTS (MD3) - JOGO #" + Id + "\n" +
               EquipeA.Nome + " " + MapasA + " x " + MapasB + " " + EquipeB.Nome + "\n" +
               "Resultado: " + ObterResultado() + "\n" +
               "------------------------------";
    }
}