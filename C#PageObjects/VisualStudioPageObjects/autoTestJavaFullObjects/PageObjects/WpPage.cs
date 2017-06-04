using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace autoTestJavaFullObjects.PageObjects
{
    abstract class WpPage
    {
        protected IWebDriver driver;
        public static readonly string URL_MAIN_PAGE = "http://autotestjava.wordpress.com";
        protected static readonly By LOCATOR_FOOTER = By.TagName("footer");

        public WpPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected static void WaitUntilElementIsClickable(By byLocator, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(byLocator));
        }

        protected static void WaitUntilElementIsVisible(By byLocator, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(byLocator));
        }

        protected static void WaitUntilElementIsHidden(By byLocator, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(byLocator));
        }

        protected static void WaitUntilFooterIsDisplayed(IWebDriver driver)
        {
            WaitUntilElementIsVisible(WpPage.LOCATOR_FOOTER, driver);
        }
    }
}
