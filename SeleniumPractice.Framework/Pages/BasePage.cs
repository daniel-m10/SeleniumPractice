using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumPractice.Framework.Config;

namespace SeleniumPractice.Framework.Pages;

public abstract class BasePage(IWebDriver driver)
{
  protected readonly IWebDriver Driver = driver;
  protected readonly WebDriverWait Wait = new(driver, TimeSpan.FromSeconds(TestConfig.DefaultTimeoutSeconds));

  protected IWebElement WaitForElement(By locator) => Wait.Until(d => d.FindElement(locator));

  protected void Click(By locator) => WaitForElement(locator).Click();

  protected void TypeText(By locator, string text)
  {
    var element = WaitForElement(locator);
    element.Clear();
    element.SendKeys(text);
  }

  protected string GetText(By locator) => WaitForElement(locator).Text;

  protected bool IsDisplayed(By locator)
  {
    try
    {
      return WaitForElement(locator).Displayed;
    }
    catch (WebDriverException)
    {
      return false;
    }
  }
}