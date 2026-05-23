using SeleniumPractice.Framework.Helpers;
using SeleniumPractice.Framework.Pages;
using SeleniumPractice.Tests.Base;

namespace SeleniumPractice.Tests.Tests
{
    public class CartTests : BaseTest
    {
        private LoginPage _loginPage = null!;
        private ProductPage _productPage = null!;
        private CartPage _cartPage = null!;

        [SetUp]
        public void CartSetUp()
        {
            _loginPage = new LoginPage(BrowserDriver.Driver);
            _loginPage.NavigateTo();
            _loginPage.LoginWithValidCredentials();
            WaitHelper.WaitForUrlToContain(BrowserDriver.Driver, "/inventory");

            _productPage = new ProductPage(BrowserDriver.Driver);
            _cartPage = new CartPage(BrowserDriver.Driver);
        }

        [Test]
        public void Cart_AddBackpack_GoToCart_ShouldContainBackpack()
        {
            _productPage.AddBackpackToCart();
            _productPage.GoToCart();
            WaitHelper.WaitForUrlToContain(BrowserDriver.Driver, "/cart");

            Assert.That(_cartPage.ContainsItem("Sauce Labs Backpack"), Is.True);
        }

        [Test]
        public void Cart_AddBackpack_GoToCart_ShouldShowOneItem()
        {
            _productPage.AddBackpackToCart();
            _productPage.GoToCart();
            WaitHelper.WaitForUrlToContain(BrowserDriver.Driver, "/cart");

            Assert.That(_cartPage.GetCartItemCount(), Is.EqualTo(1));
        }
    }
}
