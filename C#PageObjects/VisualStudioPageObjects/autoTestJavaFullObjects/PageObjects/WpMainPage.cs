using OpenQA.Selenium;

namespace autoTestJavaFullObjects.PageObjects
{
    class WpMainPage : WpPage
    {
        private static readonly By LOCATOR_POST_HEADER_LINK = By.ClassName("entry-header");

        public WpMainPage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            driver.Navigate().GoToUrl(WpPage.URL_MAIN_PAGE);
            WpPage.WaitUntilFooterIsDisplayed(driver);
        }

        public WpPostPage DisplayPost(int postNumber)
        {
            By postLocator = By.XPath("//article[" + postNumber + "]");
            IWebElement post = driver.FindElement(postLocator);
            IWebElement postLink = post.FindElement(LOCATOR_POST_HEADER_LINK);
            postLink.Click();
            WaitUntilFooterIsDisplayed(driver);
            return new WpPostPage(driver);
        }
    }
}
