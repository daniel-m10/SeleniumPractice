using SeleniumPractice.Framework.Helpers;
using SeleniumPractice.Framework.Pages;
using SeleniumPractice.Tests.Base;

namespace SeleniumPractice.Tests.Tests
{
    public class ProductsTests : BaseTest
    {
        private LoginPage _logginPage = null!;
        private ProductPage _productPage = null!;

        [SetUp]
        public void ProductsSetup()
        {
            _logginPage = new LoginPage(BrowserDriver.Driver);
            _productPage = new ProductPage(BrowserDriver.Driver);
            _logginPage.NavigateTo();
        }

        [Test]
        public void Products_LoginShouldLand_OnProductsPage()
        {
            _logginPage.LoginWithValidCredentials();
            WaitHelper.WaitForUrlToContain(BrowserDriver.Driver, "/inventory");
            Assert.That(_productPage.IsOnProductsPage(), Is.True);
        }

        [Test]
        public void Products_AddBackpack_ToCart_ShouldShowBadgeCount()
        {
            _logginPage.LoginWithValidCredentials();
            WaitHelper.WaitForUrlToContain(BrowserDriver.Driver, "/inventory");

            _productPage.AddBackpackToCart();
            Assert.That(_productPage.GetCartBadgeCount(), Is.EqualTo("1"));
        }
    }
}
