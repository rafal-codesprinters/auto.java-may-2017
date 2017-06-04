using OpenQA.Selenium;

namespace autoTestJavaStatics.PageObjects
{
    abstract class WpMainPage : WpPage
    {
        private static readonly By LOCATOR_POST_HEADER_LINK = By.ClassName("entry-header");

        public static void Open(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(WpPage.URL_MAIN_PAGE);
            WpPage.WaitUntilFooterIsDisplayed(driver);
        }

        public static void DisplayPost(int postNumber, IWebDriver driver)
        {
            By postLocator = By.XPath("//article[" + postNumber + "]");
            IWebElement post = driver.FindElement(postLocator);
            IWebElement postLink = post.FindElement(LOCATOR_POST_HEADER_LINK);
            postLink.Click();
            WaitUntilFooterIsDisplayed(driver);
        }
    }
}
