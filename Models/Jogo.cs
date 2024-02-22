namespace net_selenium.Models;

public class Jogo
{
    public string Nome { get; set; }

    public string Data { get; set; }

    public string Avaliacao { get; set; }

    public string Valor { get; set; }

    public string ValorJogo { get; set; }

    public string Desconto { get; set; }

    public string ValorDesconto { get; set; }

    public bool Gratis { get; set; }

    internal static void Add(Jogo jogo)
    {
        throw new NotImplementedException();
    }
}