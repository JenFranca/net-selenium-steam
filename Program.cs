using System.Collections.ObjectModel;
using net_selenium.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public static class HelloSelenium
{
    public static void Main()
    {
        var driver = new ChromeDriver();

        
        
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
                Console.WriteLine($"Nome do jogo: {name}");
                jogo.Nome = name;


                var date = tableRow
                    .FindElement(By.ClassName("search_released")).Text;
                Console.WriteLine($"Data de lançamento: {date}");
                jogo.Data = date;

                var rating = tableRow
                    .FindElement(By.ClassName("search_review_summary"))
                    .GetDomAttribute("class");

                if (rating.Contains("positive"))
                {
                    Console.WriteLine("Avaliação: Positivo");
                    jogo.Avaliacao = "Positivo";
                }
                else if (rating.Contains("mixed"))
                {
                    Console.WriteLine("Avaliação: Neutro");
                    jogo.Avaliacao = "Neutro";
                }
                else
                {
                    Console.WriteLine("Avaliação: Negativo");
                    jogo.Avaliacao = "Negativo";
                }
                

                var price = tableRow
                    .FindElement(By.ClassName("discount_block")).Text;
                
                    if (price.Contains("%"))
                    { // tem desconto
                        var data = price.Split('\n');
                        Console.WriteLine ($"Desconto: {data[0]}"); 
                        Console.WriteLine ($"Valor do jogo: {data[1]}"); 
                        Console.WriteLine ($"Valor com desconto: {data[2]}"); 
                        jogo.Desconto = int.Parse(data[0]);
                        jogo.ValorJogo = decimal.Parse(data[1]);
                        jogo.ValorDesconto = decimal.Parse(data[2]);
                    }
                    else if (price.Contains("Gratuito") || price.Contains("free"))
                    {
                        Console.WriteLine($"Valor do jogo: {price}");
                        jogo.Gratis = true;
                    }
                    else    
                    {
                        Console.WriteLine($"Valor do jogo: {price}");
                        jogo.Valor = price;
                    }

                 Console.WriteLine("----------------------------------------------------");

            }
            catch (System.Exception)
            {

            }
               

        }

        // Console.WriteLine(tableElement.First().Text);

        driver.Quit();
    }
}