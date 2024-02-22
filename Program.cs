using System.Collections.ObjectModel;
using net_selenium.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public static class HelloSelenium
{
    public static void Main()
    {

        var driver = new ChromeDriver();

        List<Jogo> lista = new List<Jogo>();

        driver.Navigate().GoToUrl("https://store.steampowered.com/search/?filter=topsellers");

        ReadOnlyCollection<IWebElement> tableElement = driver
        .FindElement(By.Id("search_resultsRows"))
        .FindElements(By.ClassName("responsive_search_name_combined"));

        foreach (var tableRow in tableElement)
        {
            try
            {
                // instancio a classe Jogo em memória
                // posso utilizar tudo que tem dentro da classe Jogo
                var jogo = new Jogo();

                var name = tableRow
                    .FindElement(By.ClassName("title")).Text;
                jogo.Nome = name;

                var date = tableRow
                    .FindElement(By.ClassName("search_released")).Text;
                jogo.Data = date;

                var rating = tableRow
                    .FindElement(By.ClassName("search_review_summary"))
                    .GetDomAttribute("class");

                if (rating.Contains("positive"))
                    jogo.Avaliacao = "Positivo";
                else if (rating.Contains("mixed"))
                    jogo.Avaliacao = "Neutro";
                else
                    jogo.Avaliacao = "Negativo";

                var price = tableRow
                    .FindElement(By.ClassName("discount_block")).Text;

                if (price.Contains("%"))
                { // tem desconto
                    var data = price.Split('\n');
                    jogo.Desconto = data[0];
                    jogo.ValorJogo = data[1];
                    jogo.ValorDesconto = data[2];
                }
                else if (price.Contains("Gratuito") || price.Contains("free"))
                    jogo.Gratis = true;
                else
                    jogo.Valor = price;

                lista.Add(jogo);
            }
            catch (System.Exception)
            {
            }
        }

        driver.Quit();

        ExibirInfo(lista);
    }

    static void ExibirInfo(List<Jogo> x)
    {
        foreach (var jogo in x)
        {
            Console.WriteLine($"Nome do Jogo: {jogo.Nome}");
            Console.WriteLine($"Data de lançamento: {jogo.Data}");
            Console.WriteLine($"Avaliação: {jogo.Avaliacao}");
            
            
            if (jogo.Valor != null)
                Console.WriteLine($"Valor Original: {jogo.Valor}");
            
            if (jogo.Desconto != null)
            {
                Console.WriteLine($"Desconto: {jogo.Desconto}");
                Console.WriteLine($"Valor sem desconto: {jogo.ValorJogo}");
                Console.WriteLine($"Valor com desconto: {jogo.ValorDesconto}");
            }

            if (jogo.Gratis)
               Console.WriteLine($"Gratuito");             

            Console.WriteLine("--------------------------------------------------");
        }
    } 
                

}