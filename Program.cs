using OpenQA.Selenium.Chrome;

public static class HelloSelenium
{
    public static void Main()
    {
        var driver = new ChromeDriver();
            
        driver.Navigate().GoToUrl("https://store.steampowered.com/search/?filter=topsellers");
            
        //driver.Quit();
    }
}