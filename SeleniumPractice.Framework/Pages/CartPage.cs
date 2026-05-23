using OpenQA.Selenium;

namespace SeleniumPractice.Framework.Pages;

public class CartPage(IWebDriver driver) : BasePage(driver)
{
  private static readonly By CartItems = By.CssSelector(".cart_item");
  private static readonly By ItemNames = By.CssSelector(".inventory_item_name");
  private static readonly By CheckoutButton = By.Id("checkout");

  public int GetCartItemCount()
  {
    return Driver.FindElements(CartItems).Count;
  }

  public bool ContainsItem(string itemName)
  {
    return Driver.FindElements(ItemNames).Any(e => e.Text == itemName);
  }

  public void ProceedToCheckout()
  {
    Click(CheckoutButton);
  }
}