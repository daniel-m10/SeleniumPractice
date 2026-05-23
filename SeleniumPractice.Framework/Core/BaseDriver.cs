using OpenQA.Selenium;

namespace SeleniumPractice.Framework.Core;

public class BaseDriver : IDisposable
{
  public IWebDriver Driver { get; private set; }

  public BaseDriver(BrowserType browser = BrowserType.Chrome, bool headless = false)
  {
    Driver = DriverFactory.CreateDriver(browser, headless);
    Driver.Manage().Window.Maximize();
    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
  }

  public void Dispose()
  {
    Driver?.Quit();
    Driver?.Dispose();
  }
}