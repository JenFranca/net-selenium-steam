namespace net_selenium.Models;

public class Jogo
{
    public string Nome { get; set; }

    public string Data { get; set; }

    public string Avaliacao { get; set; }

    public string Valor { get; set; }

    public decimal ValorJogo { get; set; }

    public int Desconto { get; set; }

    public decimal ValorDesconto { get; set; }

    public bool Gratis { get; set; }

}