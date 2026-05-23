using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumPractice.Framework.Config;

namespace SeleniumPractice.Framework.Helpers;

public static class ElementHelper
{
  public static void ScrollIntoView(IWebDriver driver, IWebElement element)
  {
    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
  }

  public static string GetAttribute(IWebDriver driver, By locator, string attribute)
  {
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TestConfig.DefaultTimeoutSeconds));
    return wait.Until(d => d.FindElement(locator)).GetAttribute(attribute) ?? string.Empty;
  }

  public static void SelectByText(IWebDriver driver, By locator, string text)
  {
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TestConfig.DefaultTimeoutSeconds));
    var element = wait.Until(d => d.FindElement(locator));
    new SelectElement(element).SelectByText(text);
  }
}