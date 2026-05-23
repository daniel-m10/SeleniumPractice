using OpenQA.Selenium;

namespace SeleniumPractice.Framework.Pages;

public class ProductPage(IWebDriver driver) : BasePage(driver)
{
    private static readonly By PageTitle = By.CssSelector(".title");
    private static readonly By AddBackpackToCartButton = By.Id("add-to-cart-sauce-labs-backpack");
    private static readonly By CartBadge = By.CssSelector(".shopping_cart_badge");
    private static readonly By CartIcon = By.CssSelector(".shopping_cart_link");

    public bool IsOnProductsPage()
    {
        return GetText(PageTitle) == "Products";
    }

    public void AddBackpackToCart()
    {
        Click(AddBackpackToCartButton);
    }

    public string GetCartBadgeCount()
    {
        return GetText(CartBadge);
    }

    public void GoToCart()
    {
        Click(CartIcon);
    }
}