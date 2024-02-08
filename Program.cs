using System.Collections.ObjectModel;
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
                var name = tableRow
                    .FindElement(By.ClassName("title")).Text;
                Console.WriteLine($"Nome do jogo: {name}");
                
                var date = tableRow
                    .FindElement(By.ClassName("search_released")).Text;
                Console.WriteLine($"Data de lançamento: {date}");
                
                var rating = tableRow
                    .FindElement(By.ClassName("search_review_summary"))
                    .GetDomAttribute("class");
                Console.WriteLine($"Avaliação: {rating}");

                // if (rating != null) 
                // {
                //     rating = "search_review_summary positive"; 
                //     Console.WriteLine("Positivo");
                // }
                // else
                // {
                //     rating = "search_review_summary mixed"; 
                //     Console.WriteLine("neutro");
                // }

                var price = tableRow
                    .FindElement(By.ClassName("discount_original_price")).Text;
                Console.WriteLine($"Valor do jogo: {price}");

                var discount = tableRow
                    .FindElement(By.ClassName("discount_final_price")).Text;
                Console.WriteLine($"Valor do jogo com desconto: {discount}");
            }
            catch (System.Exception)
            {

            }

        }

        // Console.WriteLine(tableElement.First().Text);

        driver.Quit();
    }
}