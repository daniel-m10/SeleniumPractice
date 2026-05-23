using OpenQA.Selenium;
using SeleniumPractice.Framework.Config;

namespace SeleniumPractice.Framework.Pages;

public class LoginPage(IWebDriver driver) : BasePage(driver)
{
  private static readonly By UsernameField = By.Id("user-name");
  private static readonly By PasswordField = By.Id("password");
  private static readonly By LoginButton = By.Id("login-button");
  private static readonly By ErrorMessage = By.CssSelector(".error-message-container h3");

  public void NavigateTo()
  {
    Driver.Navigate().GoToUrl(TestConfig.BaseUrl);
  }

  public void Login(string username, string password)
  {
    TypeText(UsernameField, username);
    TypeText(PasswordField, password);
    Click(LoginButton);
  }

  public void LoginWithValidCredentials()
  {
    Login(TestConfig.ValidUsername, TestConfig.ValidPassword);
  }

  public string GetErrorMessage()
  {
    return GetText(ErrorMessage);
  }

  public bool IsErrorDisplayed()
  {
    return IsDisplayed(ErrorMessage);
  }
}