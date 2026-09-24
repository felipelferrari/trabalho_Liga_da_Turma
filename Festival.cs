class Festival : ICartaoDivulgacao
{
    public string Nome;
    public string Local;
    public string Data;
    public string Horario;

    public Festival(string nome, string local, string data, string horario)
    {
        Nome = nome;
        Local = local;
        Data = data;
        Horario = horario;
    }

    public string GerarCartao()
    {
        return "==================================\n" +
               "      CONVITE DO FESTIVAL         \n" +
               "==================================\n" +
               "Evento: " + Nome + "\n" +
               "Local: " + Local + "\n" +
               "Data: " + Data + " às " + Horario + "\n" +
               "==================================";
    }
}