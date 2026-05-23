using SeleniumPractice.Framework.Core;

namespace SeleniumPractice.Tests.Base;

public abstract class BaseTest
{
    protected BaseDriver BrowserDriver { get; private set; } = null!;

    [SetUp]
    public void SetUp()
    {
        BrowserDriver = new BaseDriver(BrowserType.Chrome, headless: true);
    }

    [TearDown]
    public void TearDown()
    {
        BrowserDriver?.Dispose();
    }
}