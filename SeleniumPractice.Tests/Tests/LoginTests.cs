using SeleniumPractice.Framework.Config;
using SeleniumPractice.Framework.Helpers;
using SeleniumPractice.Framework.Pages;
using SeleniumPractice.Tests.Base;

namespace SeleniumPractice.Tests.Tests;

public class LoginTests : BaseTest
{
    private LoginPage _loginPage = null!;

    [SetUp]
    public void LoginSetUp()
    {
        _loginPage = new LoginPage(BrowserDriver.Driver);
        _loginPage.NavigateTo();
    }

    [Test]
    public void Login_WithValidCredentials_ShouldNavigateProductsPage()
    {
        _loginPage.LoginWithValidCredentials();
        WaitHelper.WaitForUrlToContain(BrowserDriver.Driver, "/inventory");
        Assert.That(BrowserDriver.Driver.Url, Does.Contain("/inventory"));
    }

    [Test]
    public void Login_WithInvalidPassword_ShouldShowErrorMessage()
    {
        _loginPage.Login(TestConfig.ValidUsername, "wrong_password");

        Assert.Multiple(() =>
        {
            Assert.That(_loginPage.IsErrorDisplayed(), Is.True);
            Assert.That(_loginPage.GetErrorMessage(), Does.Contain("Username and password do not match"));
        });
    }

    [Test]
    public void Login_WithLockedUser_ShouldShowLockedErrorMessage()
    {
        _loginPage.Login(TestConfig.LockedUsername, TestConfig.ValidPassword);

        Assert.Multiple(() =>
        {
            Assert.That(_loginPage.IsErrorDisplayed(), Is.True);
            Assert.That(_loginPage.GetErrorMessage(), Does.Contain("locked out"));
        });
    }
}