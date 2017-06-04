using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace autoTestJavaFullObjects
{
    abstract public class BaseTests : IDisposable
    {
        protected IWebDriver driver;

        public BaseTests()
        {
            driver = new ChromeDriver();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(3000);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        protected string GenerateRandomText()
        {
            string text = "";
            for (int i=0; i<5; i++)
            {
                text = Guid.NewGuid().ToString() + " " + text;
            }
            return text.Trim();
        }

        protected string GenerateRandomEmail()
        {
            return Guid.NewGuid().ToString() + "@test.com";
        }

        protected string GenerateRandomName()
        {
            return Guid.NewGuid().ToString();
        }

        public void Dispose()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
