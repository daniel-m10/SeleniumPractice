namespace SeleniumPractice.Framework.Config;

public static class TestConfig
{
  public static string BaseUrl => "https://www.saucedemo.com";

  public static string ValidUsername => "standard_user";
  public static string ValidPassword => "secret_sauce";
  public static string LockedUsername => "locked_out_user";

  public static int DefaultTimeoutSeconds => 10;
  public static int ShortTimeoutSeconds => 3;
}