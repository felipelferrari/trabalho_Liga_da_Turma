class PartidaFutsal : Partida
{
    public int GolsA;
    public int GolsB;

    public PartidaFutsal(int id, Equipe equipeA, Equipe equipeB, int golsA, int golsB) 
        : base(id, equipeA, equipeB)
    {
        GolsA = golsA;
        GolsB = golsB;
    }

    public override string ObterResultado()
    {
        if (GolsA > GolsB)
        {
            return "Vitória de " + EquipeA.Nome;
        }
        else if (GolsB > GolsA)
        {
            return "Vitória de " + EquipeB.Nome;
        }
        else
        {
            return "Empate";
        }
    }

    public override string GerarCartao()
    {
        return "------------------------------\n" +
               "⚽ CARTÃO DE FUTSAL - JOGO #" + Id + "\n" +
               EquipeA.Nome + " " + GolsA + " x " + GolsB + " " + EquipeB.Nome + "\n" +
               "Resultado: " + ObterResultado() + "\n" +
               "------------------------------";
    }
}