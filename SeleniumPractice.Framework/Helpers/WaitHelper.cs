using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumPractice.Framework.Config;

namespace SeleniumPractice.Framework.Helpers;

public static class WaitHelper
{
  public static void WaitForUrlToContain(IWebDriver driver, string urlFragment)
  {
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TestConfig.DefaultTimeoutSeconds));
    wait.Until(d => d.Url.Contains(urlFragment));
  }

  public static void WaitForElementToDisappear(IWebDriver driver, By locator)
  {
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TestConfig.DefaultTimeoutSeconds));
    wait.Until(d =>
    {
      try { return !d.FindElement(locator).Displayed; }
      catch (NoSuchElementException) { return true; }
    });
  }

  public static bool WaitForTextToBePresentInElement(IWebDriver driver, By locator, string text)
  {
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TestConfig.ShortTimeoutSeconds));
    try
    {
      return wait.Until(d => d.FindElement(locator).Text.Contains(text));
    }
    catch (WebDriverTimeoutException)
    {
      return false;
    }
  }
}