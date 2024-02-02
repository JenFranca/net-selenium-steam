using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public static class HelloSelenium
{
    public static void Main()
    {
        var driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://store.steampowered.com/search/?filter=topsellers");

        IWebElement tableElement = driver
        .FindElement(By.Id("search_results"));

        Console.WriteLine(tableElement);

        driver.Quit();
    }
}