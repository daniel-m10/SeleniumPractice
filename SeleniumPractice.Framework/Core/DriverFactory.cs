using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumPractice.Framework.Core;

public enum BrowserType { Chrome, Firefox }

public static class DriverFactory
{
  public static IWebDriver CreateDriver(BrowserType browser = BrowserType.Chrome, bool headless = false)
  {
    return browser switch
    {
      BrowserType.Chrome => CreateChromeDriver(headless),
      BrowserType.Firefox => CreateFirefoxDriver(headless),
      _ => throw new ArgumentOutOfRangeException(nameof(browser), $"Browser not suppoted: {browser}")
    };
  }

  private static ChromeDriver CreateChromeDriver(bool headless)
  {
    new DriverManager().SetUpDriver(new ChromeConfig());
    var options = new ChromeOptions();
    if (headless) options.AddArgument("--headless=new");
    options.AddArgument("--no-sandbox");
    options.AddArgument("--disable-dev-shm-usage");
    return new ChromeDriver(options);
  }

  private static FirefoxDriver CreateFirefoxDriver(bool headless)
  {
    new DriverManager().SetUpDriver(new FirefoxConfig());
    var options = new FirefoxOptions();
    if (headless) options.AddArgument("--headless");
    return new FirefoxDriver(options);
  }
}